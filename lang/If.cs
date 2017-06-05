using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLanguage.kalk;
namespace MyLanguage.lang {
    class If : IInstruction {
        IInstruction branchThen, branchElse;
        IExpression condition;

        public If(IExpression condition,IInstruction branchThen, IInstruction branchElse) {
            this.condition = condition;
            this.branchThen = branchThen;
            this.branchElse = branchElse;
        }

        public void eval() {
            if(condition.eval() != 0) {
                branchThen.eval();
            }
            else {
                branchElse.eval();
            }
        }
    }
}
