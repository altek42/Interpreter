using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLanguage.lang {
    class Composition : IInstruction{
        IInstruction left, right;
        public Composition(IInstruction a,IInstruction b) {
            this.left = a;
            this.right = b;
        }

        public void eval() {
            left.eval();
            right.eval();
        }
    }
}
