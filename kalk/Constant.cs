namespace MyLanguage.kalk {
    class Constant : IExpression {
        int value;

        public Constant(int value) {
            this.value = value;
        }

        public int eval() {
            return value;
        }

    }
}
