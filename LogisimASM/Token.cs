using System.Collections.Generic;

namespace LogisimASM {
    class Token {

        private int value;

        public Token(int value) {
            this.value = value;
        }

        public virtual int GetValue(Dictionary<string, int> labels) {
            return this.value;
        }
    }
}
