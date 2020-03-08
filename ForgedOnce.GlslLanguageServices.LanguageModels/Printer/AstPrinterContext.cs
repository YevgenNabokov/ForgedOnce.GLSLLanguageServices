using System;
using System.Collections.Generic;
using System.Text;

namespace ForgedOnce.GlslLanguageServices.LanguageModels.Printer
{
    public class AstPrinterContext
    {
        public string NewLineMarker = Environment.NewLine;

        public int NextLineIndent;

        public StringBuilder Output = new StringBuilder();

        public StringBuilder CurrentLine = new StringBuilder();

        public void Write(string text)
        {
            this.CurrentLine.Append(text);
        }

        public void StartNewLine()
        {
            this.CurrentLine.Append(this.NewLineMarker);
            if (this.CurrentLine.Length > 0)
            {
                this.Output.Append(this.CurrentLine);
            }

            this.CurrentLine.Clear();
            this.CurrentLine.Append(new string('\t', this.NextLineIndent));
        }

        public void IncreaseNextLineIndent()
        {
            this.NextLineIndent++;
        }

        public void DecreaseNextLineIndent()
        {
            if (this.NextLineIndent < 1)
            {
                throw new InvalidOperationException("Indent cannot be less than zero.");
            }

            this.NextLineIndent--;
        }
    }
}
