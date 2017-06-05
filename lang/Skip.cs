using System;

namespace MyLanguage.lang {
    class Skip : IInstruction {
        public Skip() {
        }

        public void eval() {
            return;
        }
    }
}
