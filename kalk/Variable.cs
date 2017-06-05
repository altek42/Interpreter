
namespace MyLanguage.kalk {
    class Variable : IExpression{
        string name;

        public Variable(string name) {
            this.name = name;
        }

        public int eval() {
            int v;
            if (!Memory.variables.TryGetValue(this.name,out v))
                throw new VariableNotFoundException($"Nie odnaleziono zmiennej '{this.name}' w pamieci.");
            return v;
        }
    }
}
