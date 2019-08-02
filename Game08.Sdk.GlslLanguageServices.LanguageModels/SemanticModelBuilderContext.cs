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

        public void AddSymbol(string name, AstNode node)
        {
            if (this.CurrentScope == null)
            {
                throw new InvalidOperationException("No current scope defined.");
            }

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
                    AstNodes = new List<AstNode>() { node }
                };

                this.CurrentScope.Symbols.Add(name, result);
            }
        }
    }
}
