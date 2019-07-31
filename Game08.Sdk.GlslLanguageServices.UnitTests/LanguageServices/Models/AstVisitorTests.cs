using Game08.Sdk.GlslLanguageServices.LanguageModels;
using Game08.Sdk.GlslLanguageServices.LanguageModels.Ast;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game08.Sdk.GlslLanguageServices.UnitTests.LanguageServices.Models
{
    [TestFixture]
    public class AstVisitorTests
    {
        [Test]
        public void AstVisitorCanVisitAllAstNodes()
        {
            var subject = new AstVisitor<int>();

            var ns = typeof(Root).Namespace;
            var nodeTypes = 
                typeof(Root)
                .Assembly.GetTypes()
                .Where(t => t.Namespace == ns && !t.IsAbstract && typeof(AstNode).IsAssignableFrom(t))
                .ToList();

            foreach (var t in nodeTypes)
            {
                var node = (AstNode)Activator.CreateInstance(t);

                Assert.DoesNotThrow(() => subject.Visit(node, 0));
            }
        }
    }
}
