namespace Profane
{
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp.Scripting;
    using Microsoft.CodeAnalysis.Scripting;
    using Microsoft.CSharp.RuntimeBinder;
    using Profane.Core.Transpile;
    using System;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Diagnostics;

    class Program
    {
        private static readonly MetadataReference[] References =
{
            MetadataReference.CreateFromFile(typeof(object).GetTypeInfo().Assembly.Location),
            MetadataReference.CreateFromFile(typeof(RuntimeBinderException).GetTypeInfo().Assembly.Location),
            MetadataReference.CreateFromFile(typeof(System.Runtime.CompilerServices.DynamicAttribute).GetTypeInfo().Assembly.Location),
            MetadataReference.CreateFromFile(typeof(ExpressionType).GetTypeInfo().Assembly.Location),
            MetadataReference.CreateFromFile(Assembly.Load(new AssemblyName("mscorlib")).Location),
            MetadataReference.CreateFromFile(Assembly.Load(new AssemblyName("System.Runtime")).Location)
        };

        static void Main(string[] args)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            try
            {
                ScriptOptions scriptOptions = ScriptOptions.Default;
                scriptOptions = scriptOptions.AddReferences(References);
                scriptOptions = scriptOptions.AddImports("System");

                var walker = new ProfaneTranspiler();
                var sampleCode = @"derp some = 2 :) 
                                   dump some :) ";


                var resultCode = walker.GenerateTranspiledCode(sampleCode);
                var result = CSharpScript.RunAsync(resultCode, scriptOptions).GetAwaiter().GetResult();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                watch.Stop();

                Console.WriteLine($"Executed in {watch.Elapsed.ToString()}");
                Console.WriteLine("NerdCats Profane");
                Console.ReadKey();
            }

        }
    }
}