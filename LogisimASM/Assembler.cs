using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace LogisimASM {
    class Assembler {

        public static List<Operation> operations = new List<Operation>() {
            new Operation("and\\s*r([0-3])\\s*,\\s*r([0-3])", 0x0, Operation.RIGHT_HAND),
            new Operation("or\\s*r([0-3])\\s*,\\s*r([0-3])", 0x1, Operation.RIGHT_HAND),
            new Operation("add\\s*r([0-3])\\s*,\\s*r([0-3])", 0x2, Operation.RIGHT_HAND),
            new Operation("sub\\s*r([0-3])\\s*,\\s*r([0-3])", 0x3, Operation.RIGHT_HAND),

            new Operation("lw\\s*r([0-3])\\s*,\\s*\\(r\\s*([0-3])\\s*\\)", 0x4, Operation.RIGHT_HAND | Operation.PARANTHESES),
            new Operation("sw\\s*r([0-3])\\s*,\\s*\\(r\\s*([0-3])\\s*\\)", 0x5, Operation.RIGHT_HAND | Operation.PARANTHESES),

            new Operation("mov\\s*r([0-3])\\s*,\\s*r([0-3])", 0x6, Operation.RIGHT_HAND),

            new Operation("inp\\s*r([0-3])\\s*", 0x7, Operation.NONE),

            new Operation("jeq\\s*r([0-3])\\s*,\\s*(0x[0-9a-f]{2}|[0-9a-z]+)", 0x8, Operation.LABELED_IMMEDIATE),
            new Operation("jne\\s*r([0-3])\\s*,\\s*(0x[0-9a-f]{2}|[0-9a-z]+)", 0x9, Operation.LABELED_IMMEDIATE),
            new Operation("jgt\\s*r([0-3])\\s*,\\s*(0x[0-9a-f]{2}|[0-9a-z]+)", 0xa, Operation.LABELED_IMMEDIATE),
            new Operation("jlt\\s*r([0-3])\\s*,\\s*(0x[0-9a-f]{2}|[0-9a-z]+)", 0xb, Operation.LABELED_IMMEDIATE),

            new Operation("lw\\s*r([0-3])\\s*,\\s*(0x[0-9a-f]{2}|[0-9a-z]+)", 0xc, Operation.RIGHT_HAND | Operation.HAS_IMMEDIATE),
            new Operation("sw\\s*r([0-3])\\s*,\\s*(0x[0-9a-f]{2}|[0-9a-z]+)", 0xd, Operation.RIGHT_HAND | Operation.HAS_IMMEDIATE),
            new Operation("li\\s*r([0-3])\\s*,\\s*(0x[0-9a-f]{2}|[0-9a-z]+)", 0xe, Operation.RIGHT_HAND | Operation.HAS_IMMEDIATE),

            new Operation("jmp\\s*(0x[0-9a-f]{2}|[0-9a-z]+)", 0xf, Operation.HAS_IMMEDIATE | Operation.LABELED)
        };

        public static List<Token> PackArguments(int operation, string lhs, string rhs, string im) {
            List<Token> tokens = new List<Token>();

            tokens.Add(new Token(
                (operation << 4) |
                ((Int32.Parse(lhs) & 0b11) << 2) |
                (((Int32.Parse(rhs) & 0b11) << 0) & 0xff)
            ));

            if (!String.IsNullOrEmpty(im)) {
                if (Regex.Match(im, "0x[0-9a-f]{2}", RegexOptions.IgnoreCase).Success) {
                    tokens.Add(new Token(Convert.ToInt32(im, 16) & 0xff));
                } else {
                    tokens.Add(new Label(im));
                }
            }

            return tokens;
        }

        public static List<Token> Assemble(string asm) {
            asm = Regex.Replace(asm, "[ ]*([;#].*)?$", "", RegexOptions.Multiline);
            asm = Regex.Replace(asm, ":", ":\n", RegexOptions.Multiline); // move labels to new lines
            asm = Regex.Replace(asm, "^\\s+", "", RegexOptions.Multiline); // remove blank lines and useless spaces
            asm = asm.Replace("\r", "");

            string[] lines = asm.Split('\n');
            List<Token> tokens = new List<Token>();

            foreach (string line in lines) {
                if (line.Length == 0) {
                    continue;
                }

                bool found = false;

                foreach (Operation operation in operations) {
                    Match match = Regex.Match(line, operation.GetPattern(), RegexOptions.IgnoreCase);

                    if (match.Success) {
                        tokens.AddRange(operation.Run(match.Groups));
                        found = true;
                        break;
                    }
                }

                if (!found) {
                    Match match = Regex.Match(line, "([0-9a-z]+):", RegexOptions.IgnoreCase);

                    if (match.Success) {
                        Label.RegisterLabel(match.Groups[1].Value, tokens.Count);
                        found = true;
                    }
                }

                if (!found) {
                    throw new Exception("Unknown syntax \"" + line + "\"");
                }
            }

            return tokens;
        }

        public static string AssembleToRAM(string asm) {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("v2.0 raw");

            foreach (Token token in Assemble(asm)) {
                builder.Append(token.GetValue().ToString("x2"));
                builder.Append(" ");
            }

            builder.Remove(builder.Length - 1, 1);
            return builder.ToString();
        }

        public static List<string> Disassemble(string line) {
            List<Opcode> opcodes = new List<Opcode>();
            List<int> labels = new List<int>();
            string[] codes = line.Split(null);

            // Collect opcodes and labels first

            for (int i = 0; i < codes.Length; i++) {
                string hexCode = codes[i];

                if (hexCode.Length != 2) {
                    continue;
                }

                Opcode opcode = new Opcode(i, hexCode);
                Operation operation = opcode.GetOperation();

                if (operation.HasImmediate()) {
                    opcode.SetImmediate(codes[i + 1]);

                    // Collect label
                    if (operation.IsLabeled() && opcode.HasImmediate() && !labels.Contains(opcode.GetImmediate())) {
                        labels.Add(opcode.GetImmediate());
                    }

                    i++;
                }

                opcodes.Add(opcode);
            }

            // Add all opcodes now
            List<string> tokens = new List<string>();

            foreach (Opcode opcode in opcodes) {
                // Add labels
                if (labels.Contains(opcode.GetPosition())) {
                    tokens.Add("");
                    tokens.Add(String.Format("LOOP{0}:", labels.IndexOf(opcode.GetPosition()) + 1));
                }

                tokens.Add(opcode.GetToken(labels));
            }

            return tokens;
        }

        public static string DisassembleFromRAM(string asm) {
            asm = Regex.Replace(asm, "^\\s+", "", RegexOptions.Multiline); // remove blank lines and useless spaces
            asm = asm.Replace("\r", "");

            StringBuilder builder = new StringBuilder();

            foreach (string line in asm.Split('\n')) {
                foreach (string token in Disassemble(line)) {
                    builder.AppendLine(token);
                }
            }

            return builder.ToString();
        }
    }
}