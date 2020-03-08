using ForgedOnce.GlslLanguageServices.LanguageModels.Ast;
using ForgedOnce.GlslLanguageServices.LanguageModels.Semantic;
using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.GlslLanguageServices.Builder.SemanticAnalysis
{
    public class SemanticModelBuilderContext
    {
        public Model Result = new Model();

        public Scope CurrentScope;

        public void EnterNewScope(AstNode node, bool isolated = false)
        {
            var scope = new Scope()
            {
                AstNode = node,
                Isolated = isolated
            };

            if (this.CurrentScope == null)
            {
                this.Result.RootScope = scope;
            }
            else
            {
                scope.Parent = this.CurrentScope;
                this.CurrentScope.Scopes.Add(scope);
            }

            this.CurrentScope = scope;
        }

        public void ExitScope()
        {
            if (this.CurrentScope != null)
            {
                this.CurrentScope = this.CurrentScope.Parent;
            }
        }

        public void AddSymbol(string name, AstNode node, SymbolKind kind)
        {
            this.EnsureCurrentScopeDefined();

            if (this.Result.NodeSymbols.ContainsKey(node))
            {
                throw new InvalidOperationException("AstNode cannot have more than one symbol.");
            }

            if (this.CurrentScope.Symbols.ContainsKey(name))
            {
                if (this.CurrentScope.Symbols[name].Kind != kind)
                {
                    throw new InvalidOperationException($"Symbol with different kind ({this.CurrentScope.Symbols[name].Kind}) already present in the scope.");
                }

                this.CurrentScope.Symbols[name].AstNodes.Add(node);
                this.Result.NodeSymbols.Add(node, this.CurrentScope.Symbols[name]);
            }
            else
            {
                var result = new Symbol()
                {
                    Name = name,
                    Parent = this.CurrentScope,
                    AstNodes = new List<AstNode>() { node },
                    Kind = kind
                };

                this.CurrentScope.Symbols.Add(name, result);
                this.Result.NodeSymbols.Add(node, result);
            }
        }

        public void AddSymbolReference(Identifier identifier, AstNode ownerNode)
        {
            this.EnsureCurrentScopeDefined();

            var newRef = new SymbolReference()
            {
                Name = identifier.Name,
                IdentifierNode = identifier,
                OwnerNode = ownerNode
            };

            if (!this.CurrentScope.References.ContainsKey(identifier.Name))
            {
                this.CurrentScope.References.Add(identifier.Name, new List<SymbolReference>());
            }

            this.CurrentScope.References[identifier.Name].Add(newRef);
        }

        private void EnsureCurrentScopeDefined()
        {
            if (this.CurrentScope == null)
            {
                throw new InvalidOperationException("No current scope defined.");
            }
        }
    }
}
