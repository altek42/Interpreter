using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLanguage.lang {
    class Write :IInstruction{
        string var;
        public Write(string var) {
            this.var = var;
        }

        public void eval() {
            int v;
            if (!Memory.variables.TryGetValue(this.var, out v))
                throw new VariableNotFoundException($"Nie odnaleziono zmiennej '{this.var}' w pamieci.");
            Console.WriteLine(v);
        }
    }
}
