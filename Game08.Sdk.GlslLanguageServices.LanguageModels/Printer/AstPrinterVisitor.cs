using Game08.Sdk.GlslLanguageServices.LanguageModels.Ast;
using System;
using System.Collections.Generic;
using System.Text;

namespace Game08.Sdk.GlslLanguageServices.LanguageModels.Printer
{
    public class AstPrinterVisitor : AstVisitor<AstPrinterContext>
    {
        public string Print(AstNode startNode)
        {
            var context = new AstPrinterContext()
            {                
            };

            this.Visit(startNode, context);

            return context.Output.ToString();
        }

        private void WithIndent(AstPrinterContext context, Action action)
        {
            context.IncreaseNextLineIndent();
            action();
            context.DecreaseNextLineIndent();
        }
    }
}
