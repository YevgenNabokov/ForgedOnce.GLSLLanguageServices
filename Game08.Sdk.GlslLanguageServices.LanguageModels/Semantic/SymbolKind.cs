using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.GlslLanguageServices.LanguageModels.Semantic
{
    [Flags]
    public enum SymbolKind
    {
        Type =                    0b0000_0001,
        Function =                0b0000_0010,
        Variable =                0b0000_0100,
        TypeMember =              0b0000_1000,
        FunctionParameter =       0b0001_0000
    }
}
