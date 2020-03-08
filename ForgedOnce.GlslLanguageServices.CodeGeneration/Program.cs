using ForgedOnce.CodeMixer.Launcher.MSBuild.WithDefaultAdapters;
using System;

namespace ForgedOnce.GlslLanguageServices.CodeGeneration
{
    class Program
    {
        static void Main(string[] args)
        {
            Launcher launcher = new Launcher();
            launcher.Launch(args[0], args[1]);
        }
    }
}
