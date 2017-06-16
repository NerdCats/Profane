namespace Profane.Core.Transpile
{
    using Antlr4.Runtime.Misc;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System;

    public class ProfaneListener : ProfaneBaseListener
    {
        public ProfaneListener()
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

        private dynamic ResolveExpression(ProfaneParser.ExprContext exprContext)
        {
            var opExpression = exprContext.opExpression();
            if (opExpression != null)
            {
                return resolvePlusExpression(opExpression);
            }
            else
            {
                return ResolveTerm(exprContext.term());
            }
        }

        private dynamic resolvePlusExpression(ProfaneParser.OpExpressionContext plusContext)
        {
            var leftTerm = plusContext.term().First();
            var rightTerm = plusContext.term().Last();

            var left = ResolveTerm(leftTerm);
            var right = ResolveTerm(rightTerm);

            return left + plusContext.op().GetText() + right;
        }

        private dynamic ResolveTerm(ProfaneParser.TermContext termContext)
        {
            if (termContext.number() != null)
            {
                return termContext.number().GetText();
            }
            else if (termContext.ID() != null)
            {
                return termContext.ID().GetText();
            }
            else if (termContext.STRING() != null)
            {
                Regex regex = new Regex("/\\$\\{([^\\}]+)\\}/g");
                var contextText = termContext.GetText();
                var replacedString = regex.Replace(contextText, "$1");
                return replacedString;
            }
            else return default(dynamic);
        }
    }
}
