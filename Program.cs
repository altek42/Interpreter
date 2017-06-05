using MyLanguage.parser;
using MyLanguage.lang;
using System;

namespace MyLanguage {
    class Program {
        static void Main(string[] args) {
            string s = @"
i = 0
while 20 - i
{
  if i % 2 - 1
    write i
  else
    skip
  i = i + 1
}
";
            try {
                Parser parser = new Parser(s);
                IInstruction p = parser.parse_Program();
                p.eval();
            }
            catch (NotParsedException e) {
                Console.WriteLine($"Błąd: wyrażenie sie nie parsuje. \nMessage: {e.Message}");
            }
            catch (VariableNotFoundException e) {
                Console.WriteLine($"Błąd: Kalkulator nie uzywa zmiennych. \nMessage: {e.Message}");
            }
            
            Console.ReadKey();
        }
    }
}
