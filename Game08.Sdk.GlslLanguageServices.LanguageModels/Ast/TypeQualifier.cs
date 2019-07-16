using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.GlslLanguageServices.LanguageModels.Ast
{
    public class TypeQualifier : AstNode
    {
        public bool Invariant;

        public InterpolationQualifier? Interpolation;

        public StorageQualifier? Storage;

        public PrecisionQualifier? Precision;

        public List<LayoutIdQualifier> Layout = new List<LayoutIdQualifier>();
    }
}
