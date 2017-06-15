namespace Profane.Core.Transpile
{
    using Antlr4.Runtime;
    using Antlr4.Runtime.Tree;

    public class ProfaneTranspiler
    {
        private ProfaneListener listener;

        public ProfaneTranspiler()
        {
            this.listener = new ProfaneListener();
        }

        public ProfaneParser.CompilationUnitContext GenerateAST(string input)
        {
            var inputStream = new AntlrInputStream(input);
            var lexer = new ProfaneLexer(inputStream);
            var tokens = new CommonTokenStream(lexer);
            var parser = new ProfaneParser(tokens);
            parser.ErrorHandler = new BailErrorStrategy();

            return parser.compilationUnit();
        }

        public string GenerateTranspiledCode(string inputText)
        {
            try
            {
                var astree = this.GenerateAST(inputText);
                ParseTreeWalker.Default.Walk(listener, astree);
                return listener.Output;
            }
            catch
            {
                return null;
            }
        }
    }
}
