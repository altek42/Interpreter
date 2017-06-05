using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLanguage.lang {
    class Read : IInstruction{
        string var;
        public Read(string var) {
            this.var = var;
        }

        public void eval() {
            int n = int.Parse(Console.ReadLine());
            Memory.variables.Add(var, n);
        }
    }
}
