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
                this.SetAsParentFor(this.left, value);
                this.left = value;
            }
        }

        public Identifier Identifier
        {

            get => identifier;

            set
            {
                this.SetAsParentFor(this.identifier, value);
                this.identifier = value;
            }
        }

        public AstNodeCollection<Expression> Parameters { get; private set; }

        public override int GetChildIndex(AstNode child)
        {
            if (child == null)
            {
                return -1;
            }

            if (child == this.left)
            {
                return 0;
            }

            if (child == this.identifier)
            {
                return 1;
            }

            if (child is Expression && this.Parameters.Contains((Expression)child))
            {
                return 2 + this.Parameters.IndexOf((Expression)child);
            }

            return -1;
        }
    }
}
