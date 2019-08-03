using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.GlslLanguageServices.LanguageModels.Ast
{
    public class ExpressionSequence : Expression
    {
        public ExpressionSequence()
        {
            this.Expressions = new AstNodeCollection<Expression>(this);
        }

        public AstNodeCollection<Expression> Expressions { get; private set; }
    }
}
