using MyLanguage.kalk;

namespace MyLanguage.lang {
    class While : IInstruction{
        IInstruction body;
        IExpression condition;
             
        public While(IExpression condition,IInstruction body) {
            this.body = body;
            this.condition = condition;
        }

        public void eval() {
            if(condition.eval() != 0) {
                body.eval();
                this.eval();
            }
        }
    }
}
