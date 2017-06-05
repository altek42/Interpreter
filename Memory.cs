using System.Collections.Generic;

namespace MyLanguage {
    static class Memory {
        static public Dictionary<string, int> variables;

        static Memory() {
            variables = new Dictionary<string, int>();
        }
    }
}
