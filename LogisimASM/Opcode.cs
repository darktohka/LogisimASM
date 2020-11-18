using System;
using System.Collections.Generic;

namespace LogisimASM {
    class Opcode {

        private int position;
        private int opcode;
        private int immediate = -1;

        public Opcode(int position, int opcode) {
            this.position = position;
            this.opcode = opcode;
        }

        public Opcode(int position, string opcode) : this(position, int.Parse(opcode, System.Globalization.NumberStyles.HexNumber)) {
        }

        public int GetPosition() {
            return position;
        }
        public int GetImmediate() {
            return this.immediate;
        }

        public bool HasImmediate() {
            return this.immediate != -1;
        }

        public void SetImmediate(int immediate) {
            this.immediate = immediate;
        }

        public void SetImmediate(string immediate) {
            this.immediate = int.Parse(immediate, System.Globalization.NumberStyles.HexNumber);
        }

        public Operation GetOperation() {
            return Assembler.operations[opcode >> 4];
        }

        public int GetLeftHand() {
            return (opcode & 15) >> 2;
        }

        public int GetRightHand() {
            return opcode & 3;
        }

        public string GetToken(List<int> labels) {
            Operation operation = GetOperation();

            if (operation.HasImmediate()) {
                string immediate;

                if (operation.IsLabeled()) {
                    immediate = String.Format("LOOP{0}", labels.IndexOf(GetImmediate()) + 1);
                } else {
                    immediate = String.Format("0x{0}", GetImmediate().ToString("X2"));
                }

                if (operation.IsRightHand()) {
                    return String.Format("  {0} R{1}, {2}", operation.GetOpcode(), GetLeftHand(), immediate);
                } else {
                    return String.Format("  {0} {1}", operation.GetOpcode(), immediate);
                }
            } else if (operation.IsInput()) {
                return String.Format("  {0} R{1}", operation.GetOpcode(), GetLeftHand());
            } else if (operation.HasParantheses()) {
                return String.Format("  {0} R{1}, (R{2})", operation.GetOpcode(), GetLeftHand(), GetRightHand());
            } else {
                return String.Format("  {0} R{1}, R{2}", operation.GetOpcode(), GetLeftHand(), GetRightHand());
            }
        }
    }
}
