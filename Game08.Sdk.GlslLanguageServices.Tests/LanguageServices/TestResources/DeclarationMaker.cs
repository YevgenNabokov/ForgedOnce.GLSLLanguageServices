using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.GlslLanguageServices.Tests.LanguageServices.TestResources
{
    public static class DeclarationMaker
    {
        public static string SimpleIntVar(string name = "a")
        {
            return MakeVarDeclaration(name, "int");
        }

        private static string MakeVarDeclaration(string name, string type)
        {
            return $"{type} {name};";
        }
    }
}
