using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace LogisimASM {
    class Operation {

        private string pattern;
        private Func<GroupCollection, List<Token>> action;

        public Operation(string pattern, Func<GroupCollection, List<Token>> action) {
            this.pattern = pattern;
            this.action = action;
        }

        public string GetPattern() {
            return pattern;
        }

        public List<Token> Run(GroupCollection matches) {
            return action.Invoke(matches);
        }
    }
}
