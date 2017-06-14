namespace Profane.Core.Transpile
{
    using Antlr4.Runtime;
    using Antlr4.Runtime.Tree;

    public class ProfaneWalker
    {
        private ProfaneTranspiler transpiler;

        public ProfaneWalker()
        {
            this.transpiler = new ProfaneTranspiler();
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
                ParseTreeWalker.Default.Walk(transpiler, astree);
                return transpiler.Output;
            }
            catch
            {
                return null;
            }
        }
    }
}
