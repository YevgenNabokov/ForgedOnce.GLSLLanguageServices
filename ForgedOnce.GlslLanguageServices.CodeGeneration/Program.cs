using L = ForgedOnce.Launcher.MSBuild.Default;
using System;

namespace ForgedOnce.GlslLanguageServices.CodeGeneration
{
    class Program
    {
        static void Main(string[] args)
        {
            L.Launcher launcher = new L.Launcher();
            launcher.Launch(args[0], args[1]);
        }
    }
}
