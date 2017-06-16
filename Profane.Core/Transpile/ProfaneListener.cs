namespace Profane.Core.Transpile
{
    using Antlr4.Runtime.Misc;
    using System.Linq;
    using System.Text.RegularExpressions;

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
            var op = exprContext.OP().GetText();
            if (op != null)
            {
                var leftTerm = exprContext.term().First();
                var rightTerm = exprContext.term().Last();

                var left = ResolveTerm(leftTerm);
                var right = ResolveTerm(rightTerm);

                return left + " " | op + " " + right;
            }
            else
            {
                return ResolveTerm(exprContext.term().First());
            }
        }

        private dynamic ResolveTerm(ProfaneParser.TermContext termContext)
        {
            if (termContext.number() != null)
            {
                return termContext.number().GetText();
            }
            else if (termContext.identifier() != null)
            {
                return termContext.identifier().GetText();
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
