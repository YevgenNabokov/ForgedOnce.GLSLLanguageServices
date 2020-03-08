using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.GlslLanguageServices.LanguageModels.Ast
{
    public class TypeQualifier : AstNode
    {
        private bool invariant;

        private InterpolationQualifier? interpolation;

        private StorageQualifier? storage;

        private PrecisionQualifier? precision;

        public TypeQualifier()
        {
            this.Layout = new AstNodeCollection<LayoutIdQualifier>(this);
        }

        public AstNodeCollection<LayoutIdQualifier> Layout { get; private set; }
        public bool Invariant { get => invariant; set { this.EnsureIsEditable(); invariant = value; } }

        public InterpolationQualifier? Interpolation { get => interpolation; set { this.EnsureIsEditable(); interpolation = value; } }

        public StorageQualifier? Storage { get => storage; set { this.EnsureIsEditable(); storage = value; } }

        public PrecisionQualifier? Precision { get => precision; set { this.EnsureIsEditable(); precision = value; } }

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

        public bool HasAnyMembers()
        {
            return this.Invariant 
                || this.Interpolation != null
                || this.Storage != null
                || this.Precision != null
                || (this.Layout != null && this.Layout.Count > 0);
        }
    }
}
