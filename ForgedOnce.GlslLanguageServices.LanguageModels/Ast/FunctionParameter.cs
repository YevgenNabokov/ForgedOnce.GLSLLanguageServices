﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.GlslLanguageServices.LanguageModels.Ast
{
    public class FunctionParameter : AstNode
    {
        private bool isConst;

        private ParameterQualifier? parameterQualifier;

        private TypeSpecifier typeSpecifier;

        private ArraySpecifier arraySpecifier;

        private Identifier name;

        public TypeSpecifier TypeSpecifier
        {

            get => typeSpecifier;

            set
            {
                this.SetAsParentFor(this.typeSpecifier, value);
                this.typeSpecifier = value;
            }
        }

        public ArraySpecifier ArraySpecifier
        {

            get => arraySpecifier;

            set
            {
                this.SetAsParentFor(this.arraySpecifier, value);
                this.arraySpecifier = value;
            }
        }

        public Identifier Name
        {

            get => name;

            set
            {
                this.SetAsParentFor(this.name, value);
                this.name = value;
            }
        }

        public ParameterQualifier? ParameterQualifier { get => parameterQualifier; set { this.EnsureIsEditable(); parameterQualifier = value; } }

        public bool IsConst { get => isConst; set { this.EnsureIsEditable(); isConst = value; } }

        public override int GetChildIndex(AstNode child)
        {
            if (child == null)
            {
                return -1;
            }

            if (child == this.typeSpecifier)
            {
                return 0;
            }

            if (child == this.arraySpecifier)
            {
                return 1;
            }

            if (child == this.name)
            {
                return 2;
            }

            return -1;
        }
    }
}
