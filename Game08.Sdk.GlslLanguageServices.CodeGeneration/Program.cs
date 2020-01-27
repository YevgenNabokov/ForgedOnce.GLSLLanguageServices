using Game08.Sdk.CodeMixer.Launcher.MSBuild.WithDefaultAdapters;
using System;

namespace Game08.Sdk.GlslLanguageServices.CodeGeneration
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
