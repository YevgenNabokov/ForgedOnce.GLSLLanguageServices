﻿using FluentAssertions;
using ForgedOnce.GlslLanguageServices.Builder;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.GlslLanguageServices.Tests.LanguageServices.Builder.SemanticAnalysis
{
    [TestFixture]
    public class ShaderFileTests
    {
        [Test]
        public void CanDoSemanticAnalysisForVariableDeclaration()
        {
            var shaderText = @"in vec3 var1, var2;";

            ShaderFile file = ShaderFile.CreateFromText(shaderText);

            file.SemanticContext.Should().NotBeNull();
            file.SemanticContext.Model.NodeSymbols.Should().HaveCount(2);
        }

        [Test]
        public void CanDoSemanticAnalysisForUnresolvedSymbol()
        {
            var shaderText = @"void main() { float a = unres; }";

            ShaderFile file = ShaderFile.CreateFromText(shaderText);

            file.SemanticContext.Should().NotBeNull();
            file.SemanticContext.Model.NodeSymbols.Should().HaveCount(2);
        }
    }
}
