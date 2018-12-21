using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CSharp;
using System.CodeDom.Compiler;

class Program
{
    static void Main(string[] args)
    {
        var csc = new CSharpCodeProvider(new Dictionary<string, string>() { { "CompilerVersion", "v3.5" } });
        var parameters = new CompilerParameters(new[] { "mscorlib.dll", "System.Core.dll" }, "foo.exe", true);
        parameters.GenerateExecutable = true;

        Console.WriteLine("iveskite pasisveikinima");
        var hey = Console.ReadLine();

        CompilerResults results = csc.CompileAssemblyFromSource(parameters,
        @"using System.Linq;
          using System;
            class Program {
              public static void Main(string[] args)
              {
               Console.WriteLine(""" + hey + @""");
                Console.ReadKey();
              }
            }");
        results.Errors.Cast<CompilerError>().ToList().ForEach(error => Console.WriteLine(error.ErrorText));
    }
}
