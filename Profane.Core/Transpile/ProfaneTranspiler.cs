namespace Profane.Core.Transpile
{
    using Antlr4.Runtime.Misc;
    using System;
    using System.Text.RegularExpressions;

    public class ProfaneTranspiler : ProfaneBaseListener
    {
        public ProfaneTranspiler()
        {
            this.Output = string.Empty;
        }

        public string Output { get; private set; }

        public override void EnterAssignstmt([NotNull] ProfaneParser.AssignstmtContext context)
        {
            string target = context.ID().GetText();
            dynamic value = this.ResolveExpression(context.expr());
            this.Output += "dynamic " + target + " = " + value + ";\n";
        }

        public override void EnterPrintstmt([NotNull] ProfaneParser.PrintstmtContext context)
        {
            var resolvedExp = context.expr() == null ? string.Empty : this.ResolveExpression(context.expr());
            this.Output += $"System.Console.WriteLine({resolvedExp});\n";
        }

        // TODO: Shouldn't we do anything about the expressions? May be, this will get clear when we start writing the REPL I guess

        private dynamic ResolveExpression(ProfaneParser.ExprContext exprContext)
        {
            if (exprContext.number() != null)
            {
                return exprContext.number().GetText();
            }
            else if (exprContext.identifier() != null)
            {
                return exprContext.identifier().GetText();
            }
            else if (exprContext.STRING() != null)
            {
                Regex regex = new Regex("/\\$\\{([^\\}]+)\\}/g");
                var contextText = exprContext.GetText();
                var replacedString = regex.Replace(contextText, "$1");
                return replacedString;
            }
            else return default(dynamic);
        }
    }
}
