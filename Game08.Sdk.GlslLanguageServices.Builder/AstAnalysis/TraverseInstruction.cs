using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.GlslLanguageServices.Builder.AstAnalysis
{
    [Flags]
    public enum TraverseInstruction
    {
        Continue =      0b0000,
        Match =         0b0001,
        ExitBranch =    0b0010,
    }
}
