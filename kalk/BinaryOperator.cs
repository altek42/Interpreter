using System;

namespace MyLanguage.kalk {
    class BinaryOperator : IExpression {
        char symbol;
        IExpression left, right;

        public BinaryOperator(char symbol,IExpression left, IExpression right) {
            this.symbol = symbol;
            this.left = left;
            this.right = right;
        }

        public int eval() {
            switch (symbol) {
                case '+':
                    return left.eval() + right.eval();
                case '-':
                    return left.eval() - right.eval();
                case '*':
                    return left.eval() * right.eval();
                case '%':
                    return left.eval() % right.eval();
                default:
                    throw new ArgumentException($"{nameof(symbol)} = {symbol}.");
            }
        }
    }
}
