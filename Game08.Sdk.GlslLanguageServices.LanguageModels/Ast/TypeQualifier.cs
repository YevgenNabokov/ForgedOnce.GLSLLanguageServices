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

        public TypeQualifier()
        {
            this.Layout = new AstNodeCollection<LayoutIdQualifier>(this);
        }

        public AstNodeCollection<LayoutIdQualifier> Layout { get; private set; }

        public override int GetChildIndex(AstNode child)
        {
            if (child == null)
            {
                return -1;
            }

            if (child is LayoutIdQualifier && this.Layout.Contains((LayoutIdQualifier)child))
            {
                return this.Layout.IndexOf((LayoutIdQualifier)child);
            }

            return -1;
        }
    }
}
