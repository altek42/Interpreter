using MyLanguage.kalk;

namespace MyLanguage.lang {
    class Assign : IInstruction{
        string name;
        IExpression expresion;

        public Assign(string name, IExpression e) {
            this.name = name;
            this.expresion = e;
        }

        public void eval() {
            if (Memory.variables.ContainsKey(this.name)) {
                Memory.variables[this.name] = expresion.eval();
            }
            else {
                Memory.variables.Add(name, expresion.eval());
            }
        }
    }
}
