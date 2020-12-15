using System;
using System.Collections.Generic;

namespace LogisimASM {
    class Label : Token {

        private string name;

        public Label(string name) : base(-1) {
            this.name = name;
        }

        public override int GetValue(Dictionary<string, int> labels) {
            try {
                return labels[name];
            } catch {
                throw new Exception("Undefined label \"" + name + "\"");
            }
        }
    }
}
