namespace BinaryConverter
{
    class ParseDecimal {
        public string initial, final;
        public ParseDecimal(string number) {
            string[] toString = number.Split('.');

            this.initial = toString[0];

            try {
                this.final = toString[1];
            }
            catch {
                this.final = null;
            }
        }
    }
}