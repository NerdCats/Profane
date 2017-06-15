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
            var walker = new ProfaneTranspiler();
            var sampleCode = @"derp some = 2 :)
                               dump some :) ";


            var resultCode = walker.GenerateTranspiledCode(sampleCode);

            ScriptOptions scriptOptions = ScriptOptions.Default;

            scriptOptions = scriptOptions.AddReferences(References);
            //Add namespaces
            scriptOptions = scriptOptions.AddImports("System");

            var result = CSharpScript.EvaluateAsync("dynamic something = 2;", scriptOptions)
                .GetAwaiter().GetResult();

            Console.WriteLine(result);

            Console.WriteLine(resultCode);
            Console.ReadKey();
        }
    }
}