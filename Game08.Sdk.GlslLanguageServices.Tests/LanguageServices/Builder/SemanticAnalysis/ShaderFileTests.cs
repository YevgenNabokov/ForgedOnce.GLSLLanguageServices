using Game08.Sdk.GlslLanguageServices.Builder;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.GlslLanguageServices.Tests.LanguageServices.Builder.SemanticAnalysis
{
    [TestFixture]
    public class ShaderFileTests
    {
        [Test]
        public void CanDoSemanticAnalysisForVariableDeclaration()
        {
            var shaderText = @"in vec3 var1, var2;";

            ShaderFile file = ShaderFile.CreateFromText(shaderText);

            Assert.IsNotNull(file.SemanticContext);
            Assert.AreEqual(2, file.SemanticContext.Model.NodeSymbols.Count);
        }

        [Test]
        public void CanDoSemanticAnalysisForUnresolvedSymbol()
        {
            var shaderText = @"void main() { float a = unres; }";

            ShaderFile file = ShaderFile.CreateFromText(shaderText);

            Assert.IsNotNull(file.SemanticContext);
            Assert.AreEqual(2, file.SemanticContext.Model.NodeSymbols.Count);
        }
    }
}
