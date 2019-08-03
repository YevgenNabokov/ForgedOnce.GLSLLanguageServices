using Game08.Sdk.GlslLanguageServices.LanguageModels.Ast;
using Game08.Sdk.GlslLanguageServices.LanguageModels.Semantic;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.GlslLanguageServices.LanguageModels
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

        public void AddSymbol(string name, AstNode node, bool isType = false)
        {
            this.EnsureCurrentScopeDefined();

            if (this.CurrentScope.Symbols.ContainsKey(name))
            {
                this.CurrentScope.Symbols[name].AstNodes.Add(node);
            }
            else
            {
                var result = new Symbol()
                {
                    Name = name,
                    Parent = this.CurrentScope,
                    AstNodes = new List<AstNode>() { node },
                    IsType = isType
                };

                this.CurrentScope.Symbols.Add(name, result);
            }
        }

        public void AddSymbolReference(string name, AstNode node)
        {
            this.EnsureCurrentScopeDefined();

            var newRef = new SymbolReference()
            {
                Name = name,
                Node = node
            };

            if (!this.CurrentScope.References.ContainsKey(name))
            {
                this.CurrentScope.References.Add(name, new List<SymbolReference>());
            }

            this.CurrentScope.References[name].Add(newRef);
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
