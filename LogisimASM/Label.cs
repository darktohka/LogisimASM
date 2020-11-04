using System;
using System.Collections.Generic;

namespace LogisimASM {
    class Label : Token {

        private static Dictionary<string, int> labels = new Dictionary<string, int>();
        private string name;

        public Label(string name) : base(-1) {
            this.name = name;
        }

        public static void RegisterLabel(string name, int value) {
            labels[name] = value;
        }

        public override int GetValue() {
            try {
                return labels[name];
            } catch {
                throw new Exception("Undefined label \"" + name + "\"");
            }
        }
    }
}
