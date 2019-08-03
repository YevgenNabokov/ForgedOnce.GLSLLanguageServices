using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.GlslLanguageServices.LanguageModels.Ast
{
    public class ExpressionFunctionCall : Expression
    {
        private Expression left;

        private Identifier identifier;

        public ExpressionFunctionCall()
        {
            this.Parameters = new AstNodeCollection<Expression>(this);
        }

        public Expression Left
        {

            get => left;

            set
            {
                this.SetParent(this.left, value);
                this.left = value;
            }
        }

        public Identifier Identifier
        {

            get => identifier;

            set
            {
                this.SetParent(this.identifier, value);
                this.identifier = value;
            }
        }

        public AstNodeCollection<Expression> Parameters { get; private set; }
    }
}
