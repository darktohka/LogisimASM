using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace LogisimASM {
    class Operation {

        public const int RIGHT_HAND = (1 << 1);
        public const int HAS_IMMEDIATE = (1 << 2);
        public const int LABELED = (1 << 3);
        public const int PARANTHESES = (1 << 4);
        public const int NONE = 0;
        public const int LABELED_IMMEDIATE = RIGHT_HAND | HAS_IMMEDIATE | LABELED;
        public const int ALL = RIGHT_HAND | HAS_IMMEDIATE | LABELED | PARANTHESES;

        private string pattern;
        private int opcode;
        private int flags;

        public Operation(string pattern, int opcode, int flags) {
            this.pattern = pattern;
            this.opcode = opcode;
            this.flags = flags;
        }

        public string GetPattern() {
            return pattern;
        }

        public string GetOpcode() {
            return pattern.Substring(0, pattern.IndexOf('\\')).ToUpper();
        }

        public bool IsRightHand() {
            return (this.flags & RIGHT_HAND) != 0;
        }

        public bool HasImmediate() {
            return (this.flags & HAS_IMMEDIATE) != 0;
        }

        public bool IsLabeled() {
            return (this.flags & LABELED) != 0;
        }
        public bool HasParantheses() {
            return (this.flags & PARANTHESES) != 0;
        }

        public bool IsInput() {
            return this.flags == 0;
        }

        public List<Token> Run(GroupCollection matches) {
            if (IsRightHand()) {
                if (HasImmediate()) {
                    return Assembler.PackArguments(this.opcode, matches[1].Value, "0", matches[2].Value);
                } else {
                    return Assembler.PackArguments(this.opcode, matches[1].Value, matches[2].Value, null);
                }
            } else {
                if (HasImmediate()) {
                    return Assembler.PackArguments(this.opcode, "0", "0", matches[1].Value);
                } else {
                    return Assembler.PackArguments(this.opcode, matches[1].Value, "0", null);
                }
            }
        }
    }
}
