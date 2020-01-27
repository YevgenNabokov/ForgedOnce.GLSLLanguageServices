using FluentAssertions;
using Game08.Sdk.GlslLanguageServices.LanguageModels.Ast;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.GlslLanguageServices.Tests.LanguageServices.Models
{
    [TestFixture]
    public class AstTests
    {
        [Test]
        public void NewIdentifier_IsEditable()
        {
            var testName = "TheName";
            var subject = new Identifier();

            subject.Name = testName;

            subject.Name.Should().Be(testName);
        }

        [Test]
        public void ReadonlyIdentifier_IsNotEditable()
        {
            var subject = new Identifier();
            subject.MakeReadonly();

            Action action = () => subject.Name = "NewValue";

            action.Should().Throw<InvalidOperationException>();
        }

        [Test]
        public void ReadonlyNodeCollection_IsNotEditable()
        {
            var subject = new VariableDeclarationList();
            subject.MakeReadonly();

            Action action = () => subject.Declarations.Add(new VariableDeclaration());

            action.Should().Throw<InvalidOperationException>();
        }

        [Test]
        public void ParentNodeReadonlyMode_WillPropagateToChildNodes()
        {
            var subjectIdentifier = new Identifier();
            var subject = new VariableDeclarationList();
            var declaration =  new VariableDeclaration();
            declaration.Name = subjectIdentifier;
            subject.Declarations.Add(declaration);

            subject.MakeReadonly();

            Action action = () => subjectIdentifier.Name = "NewValue";

            action.Should().Throw<InvalidOperationException>();
        }
    }
}
