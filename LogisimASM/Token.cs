namespace LogisimASM {
    class Token {

        private int value;

        public Token(int value) {
            this.value = value;
        }

        public virtual int GetValue() {
            return this.value;
        }
    }
}
