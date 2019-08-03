using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.GlslLanguageServices.LanguageModels.Ast
{
    public class FunctionDeclaration : Declaration
    {
        private TypeSpecifier typeSpecifier;

        private Identifier name;

        private StatementCompound statement;

        public FunctionDeclaration()
        {
            this.Parameters = new AstNodeCollection<FunctionParameter>(this);
        }

        public TypeSpecifier TypeSpecifier
        {

            get => typeSpecifier;

            set
            {
                this.SetParent(this.typeSpecifier, value);
                this.typeSpecifier = value;
            }
        }

        public Identifier Name
        {

            get => name;

            set
            {
                this.SetParent(this.name, value);
                this.name = value;
            }
        }

        public StatementCompound Statement
        {

            get => statement;

            set
            {
                this.SetParent(this.statement, value);
                this.statement = value;
            }
        }

        public AstNodeCollection<FunctionParameter> Parameters { get; private set; }
    }
}
