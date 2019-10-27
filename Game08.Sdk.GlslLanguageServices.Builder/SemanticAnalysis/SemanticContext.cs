using Game08.Sdk.GlslLanguageServices.LanguageModels.Ast;
using Game08.Sdk.GlslLanguageServices.LanguageModels.Semantic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.GlslLanguageServices.Builder.SemanticAnalysis
{
    public class SemanticContext
    {        
        public SemanticContext(Model model, Scope globalScope)
        {
            this.Model = model;
            this.GlobalScope = globalScope;
        }

        public Scope GlobalScope { get; private set; }

        public Model Model { get; private set; }

        public void ResolveSymbolReferences(bool renewAll = false)
        {
            this.ResolveSymbolReferencesInScope(this.Model.RootScope, renewAll);
        }

        private void ResolveSymbolReferencesInScope(Scope scope, bool renewAll = false)
        {
            foreach (var group in scope.References)
            {
                foreach(var reference in group.Value)
                {
                    if (reference.ResolvedSymbol == null || renewAll)
                    {
                        this.ResolveSymbolReference(reference, scope);
                    }
                }

                foreach (var subScope in scope.Scopes)
                {
                    this.ResolveSymbolReferencesInScope(subScope, renewAll);
                }
            }
        }

        private void ResolveSymbolReference(SymbolReference reference, Scope containingScope)
        {
            if (reference.OwnerNode is ExpressionFieldSelection)
            {
                //// Not implemented at the moment, requires to solve left side type.
                return;
            }

            if (reference.OwnerNode is ExpressionFunctionCall)
            {
                ExpressionFunctionCall call = reference.OwnerNode as ExpressionFunctionCall;
                if (call.Left != null)
                {
                    //// Not implemented at the moment, requires to solve left side type.
                    return;
                }

                reference.ResolvedSymbol = this.LookupSymbol(reference.Name, SymbolKind.Function | SymbolKind.Type, containingScope, reference.OwnerNode);
                return;
            }

            if (reference.OwnerNode is ExpressionVariableIdentifier)
            {                
                reference.ResolvedSymbol = this.LookupSymbol(reference.Name, SymbolKind.Variable | SymbolKind.FunctionParameter, containingScope, reference.OwnerNode);
                return;
            }

            if (reference.OwnerNode is LayoutIdQualifier)
            {
                //// Not implemented at the moment, requires to solve which type this qualifier is for.
                return;
            }

            if (reference.OwnerNode is TypeNameSpecifier)
            {
                reference.ResolvedSymbol = this.LookupSymbol(reference.Name, SymbolKind.Type, containingScope, reference.OwnerNode);
                return;
            }

            throw new NotImplementedException($"Cannot resolve symbol reference for {reference.OwnerNode.GetType()}.");
        }

        private Symbol LookupSymbol(string name, SymbolKind kind, Scope scope, AstNode shouldPreceedThisNode = null)
        {
            var currentScope = scope;
            while (currentScope != null)
            {
                if (currentScope.Symbols.ContainsKey(name))
                {
                    var symbol = currentScope.Symbols[name];
                    if (shouldPreceedThisNode != null)
                    {
                        foreach (var node in symbol.AstNodes)
                        {
                            if (this.VerifyNodePrecendence(node, shouldPreceedThisNode))
                            {
                                return symbol;
                            }
                        }
                    }
                    else
                    {
                        return symbol;
                    }
                }

                if (currentScope.Parent != null)
                {
                    currentScope = currentScope.Parent;
                }
                else
                {
                    if (this.GlobalScope != null && currentScope != this.GlobalScope)
                    {
                        currentScope = this.GlobalScope;
                    }
                    else
                    {
                        currentScope = null;
                    }
                }
            }

            return null;
        }

        private bool VerifyNodePrecendence(AstNode firstNode, AstNode secondNode)
        {
            if (firstNode == secondNode)
            {
                return true;
            }

            List<AstNode> firstPath = new List<AstNode>() { firstNode };
            var f = firstNode;
            while (f.Parent != null)
            {
                firstPath.Add(f.Parent);
                f = f.Parent;
            }

            List<AstNode> secondPath = new List<AstNode>() { secondNode };
            var s = secondNode;
            while (s.Parent != null)
            {
                secondPath.Add(s.Parent);
                s = s.Parent;
            }

            for (var n = 0; n < firstPath.Count; n++)
            {
                for (var n2 = 0; n2 < secondPath.Count; n2++)
                {
                    if (firstPath[n] == secondPath[n2])
                    {
                        var commonNode = firstPath[n];
                        return commonNode.GetChildIndex(firstPath[n - 1]) <= commonNode.GetChildIndex(secondPath[n2 - 1]);
                    }
                }
            }
            
            return true;
        }
    }
}
