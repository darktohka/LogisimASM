using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace LogisimASM {
    class Operation {

        private string pattern;
        private int opcode;
        private bool rightHand;
        private bool immediate;
        private bool labeled;

        public Operation(string pattern, int opcode, bool rightHand, bool immediate, bool labeled) {
            this.pattern = pattern;
            this.opcode = opcode;
            this.rightHand = rightHand;
            this.immediate = immediate;
            this.labeled = labeled;
        }

        public string GetPattern() {
            return pattern;
        }

        public string GetOpcode() {
            return pattern.Substring(0, pattern.IndexOf('\\')).ToUpper();
        }

        public bool IsRightHand() {
            return rightHand;
        }

        public bool HasImmediate() {
            return immediate;
        }

        public bool IsLabeled() {
            return labeled;
        }

        public bool IsInput() {
            return !rightHand && !immediate && !labeled;
        }

        public List<Token> Run(GroupCollection matches) {
            if (rightHand) {
                if (immediate) {
                    return Assembler.PackArguments(this.opcode, matches[1].Value, "0", matches[2].Value);
                } else {
                    return Assembler.PackArguments(this.opcode, matches[1].Value, matches[2].Value, null);
                }
            } else {
                if (immediate) {
                    return Assembler.PackArguments(this.opcode, "0", "0", matches[1].Value);
                } else {
                    return Assembler.PackArguments(this.opcode, matches[1].Value, "0", null);
                }
            }
        }
    }
}
