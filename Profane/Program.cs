namespace Profane
{
    using Profane.Core.Transpile;
    using System;

    class Program
    {
        static void Main(string[] args)

        {
            var walker = new ProfaneWalker();
            var sampleCode = @"derp some = 2 :)
                               dump some :) ";


            var resultCode = walker.GenerateTranspiledCode(sampleCode);
            
            Console.WriteLine(resultCode);
            Console.ReadKey();
        }
    }
}