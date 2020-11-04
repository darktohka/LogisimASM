using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace LogisimASM {
    class Assembler {

        private static List<Operation> operations = new List<Operation>() {
            new Operation("and\\s*r([0-3])\\s*,\\s*r([0-3])", (GroupCollection r) => PackArguments(0x0, r[1].Value, r[2].Value)),
            new Operation("or\\s*r([0-3])\\s*,\\s*r([0-3])", (GroupCollection r) => PackArguments(0x1, r[1].Value, r[2].Value)),
            new Operation("add\\s*r([0-3])\\s*,\\s*r([0-3])", (GroupCollection r) => PackArguments(0x2, r[1].Value, r[2].Value)),
            new Operation("sub\\s*r([0-3])\\s*,\\s*r([0-3])", (GroupCollection r) => PackArguments(0x3, r[1].Value, r[2].Value)),

            new Operation("lw\\s*r([0-3])\\s*,\\s*\\(r\\s*([0-3])\\s*\\)", (GroupCollection r) => PackArguments(0x4, r[1].Value, r[2].Value)),
            new Operation("sw\\s*r([0-3])\\s*,\\s*\\(r\\s*([0-3])\\s*\\)", (GroupCollection r) => PackArguments(0x5, r[1].Value, r[2].Value)),

            new Operation("mov\\s*r([0-3])\\s*,\\s*r([0-3])", (GroupCollection r) => PackArguments(0x6, r[1].Value, r[2].Value)),

            new Operation("inp\\s*r([0-3])\\s*", (GroupCollection r) => PackArguments(0x7, r[1].Value)),

            new Operation("jeq\\s*r([0-3])\\s*,\\s*(0x[0-9a-f]{2}|[a-z]+)", (GroupCollection r) => PackImArguments(0x8, r[1].Value, r[2].Value)),
            new Operation("jne\\s*r([0-3])\\s*,\\s*(0x[0-9a-f]{2}|[a-z]+)", (GroupCollection r) => PackImArguments(0x9, r[1].Value, r[2].Value)),
            new Operation("jgt\\s*r([0-3])\\s*,\\s*(0x[0-9a-f]{2}|[a-z]+)", (GroupCollection r) => PackImArguments(0xa, r[1].Value, r[2].Value)),
            new Operation("jlt\\s*r([0-3])\\s*,\\s*(0x[0-9a-f]{2}|[a-z]+)", (GroupCollection r) => PackImArguments(0xb, r[1].Value, r[2].Value)),

            new Operation("lw\\s*r([0-3])\\s*,\\s*(0x[0-9a-f]{2}|[a-z]+)", (GroupCollection r) => PackImArguments(0xc, r[1].Value, r[2].Value)),
            new Operation("sw\\s*r([0-3])\\s*,\\s*(0x[0-9a-f]{2}|[a-z]+)", (GroupCollection r) => PackImArguments(0xd, r[1].Value, r[2].Value)),
            new Operation("li\\s*r([0-3])\\s*,\\s*(0x[0-9a-f]{2}|[a-z]+)", (GroupCollection r) => PackImArguments(0xe, r[1].Value, r[2].Value)),

            new Operation("jmp\\s*(0x[0-9a-f]{2}|[a-z]+)", (GroupCollection r) => PackImArguments(0xf, r[1].Value))
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

        public static List<Token> PackArguments(int operation, string lhs) {
            return PackArguments(operation, lhs, "0", null);
        }

        public static List<Token> PackArguments(int operation, string lhs, string rhs) {
            return PackArguments(operation, lhs, rhs, null);
        }

        public static List<Token> PackImArguments(int operation, string im) {
            return PackArguments(operation, "0", "0", im);
        }

        public static List<Token> PackImArguments(int operation, string register, string im) {
            return PackArguments(operation, register, "0", im);
        }

        public static List<Token> Assemble(string asm) {
            asm = Regex.Replace(asm, "[ ]*([;#].*)?$", "", RegexOptions.Multiline);
            asm = Regex.Replace(asm, ":", ":\n", RegexOptions.Multiline); // move labels to new lines
            asm = Regex.Replace(asm, "^\\s+", "", RegexOptions.Multiline); // remove blank lines ans useless spaces
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
                    Match match = Regex.Match(line, "([a-z]+):", RegexOptions.IgnoreCase);

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
    }
}