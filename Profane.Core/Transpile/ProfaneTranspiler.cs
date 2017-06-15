namespace Profane.Core.Transpile
{
    using Antlr4.Runtime;
    using Antlr4.Runtime.Tree;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp.Scripting;
    using Microsoft.CodeAnalysis.Scripting;
    using Microsoft.CSharp.RuntimeBinder;
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;

    public class ProfaneTranspiler
    {
        private ProfaneListener listener;
        private static readonly MetadataReference[] References =
        {
            MetadataReference.CreateFromFile(typeof(object).GetTypeInfo().Assembly.Location),
            MetadataReference.CreateFromFile(typeof(RuntimeBinderException).GetTypeInfo().Assembly.Location),
            MetadataReference.CreateFromFile(typeof(System.Runtime.CompilerServices.DynamicAttribute).GetTypeInfo().Assembly.Location),
            MetadataReference.CreateFromFile(typeof(ExpressionType).GetTypeInfo().Assembly.Location),
            MetadataReference.CreateFromFile(Assembly.Load(new AssemblyName("mscorlib")).Location),
            MetadataReference.CreateFromFile(Assembly.Load(new AssemblyName("System.Runtime")).Location)
        };

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

        public async Task<TranspileResult> RunAsync(string code)
        {
            var result = new TranspileResult();

            if (string.IsNullOrEmpty(code))
                return result;

            Stopwatch watch = new Stopwatch();
            watch.Start();

            try
            {
                ScriptOptions scriptOptions = ScriptOptions.Default;
                scriptOptions = scriptOptions.AddReferences(References);
                scriptOptions = scriptOptions.AddImports("System");

                var resultCode = this.GenerateTranspiledCode(code);
                if (resultCode == null)
                {
                    watch.Stop();
                    result.TimeElapsed = watch.Elapsed.ToString();
                    return result;
                }

                var outputStrBuilder = new StringBuilder();
                using (var writer = new StringWriter(outputStrBuilder))
                {
                    Console.SetOut(writer);
                    var scriptState = await CSharpScript.RunAsync(resultCode, scriptOptions);
                    result.output = outputStrBuilder.ToString();
                }
            }
            catch (CompilationErrorException ex)
            {
                result.output = ex.Message;
            }
            finally
            {
                watch.Stop();
                result.TimeElapsed = watch.Elapsed.ToString();             
            }
            return result;
        }
    }
}
