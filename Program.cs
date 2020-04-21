using System;

namespace BinaryConverter {
    class Program {
        string message;

        static void Main(string[] args) {
            new Program().StartApp();
        }

        /* -- APP ENTRY POINT -- */
        void StartApp() {
            string result = "";
            Input binary = new Input("To convert from Binary to Decimal, press 1\nTo convert from Decimal to Binary, press 2\n", typeof(int));
            Input number = (binary.result == "1" || binary.result == "2") ? new Input("Enter the number to convert", typeof(double)) : null;
            if (number != null) {
                if (number.result != null && binary.result == "1") {
                    this.message = $"{number.result} as a decimal is: ";
                    result = ToDecimal(number.result);
                }
                else if (number.result != null && binary.result == "2") {
                    this.message = $"{number.result} in binary is: ";
                    result = ToBinary(number.result);
                }
                else System.Console.WriteLine("Something went wrong. Please try again later.");
            }
            else System.Console.WriteLine("Invalid Selection. Please try again later.");

            System.Console.WriteLine(message + result);
        }

        /* -- MAIN COMPONENTS -- */
        string ToDecimal(string number) {
            char[] kill = new char[8] {'2','3','4','5','6','7','8','9'};
            foreach (char x in kill) {
                if (number.Contains(x)) {
                    this.message = "That's not a binary number!";
                    return "";
                }
            }

            ParseDecimal values = new ParseDecimal(number);
            string initial = Reverse(values.initial);
            int index = 0;
            double result = 0;

            foreach (char i in initial) {
                string x = i.ToString();
                result += (x == "1") ? Math.Pow(2, index) : 0;
                index++;
            }

            if (values.final != null) {
                index = 1;
                foreach (char i in values.final) {
                    string x = i.ToString();
                    result += (x == "1") ? Math.Pow(2, -index) : 0;
                    index++;
                }
            }

            return result.ToString();
        }

        string ToBinary(string number) {
            ParseDecimal values = new ParseDecimal(number);

            int index = 1;
            string beforeDecimal = "";
            double initial = double.Parse(values.initial);
            while (Math.Pow(2, index) < initial) {
                index += 1;
            }
            while (index > 0) {
                index--;
                if (initial - Math.Pow(2, index) >= 0) {
                    beforeDecimal += '1';
                    initial = initial - Math.Pow(2, index);
                }
                else {
                    beforeDecimal += '0';
                }
            }

            double final = (values.final == null) ? 0 : (double.Parse(values.final) / Math.Pow(10, values.final.Length));
            string afterDecimal = "";
            index = 0;
            while (final != 0 && index < 18) {
                final = final * 2;
                if (final >= 1) {
                    afterDecimal += '1';
                    final -= 1;
                }
                else {
                    afterDecimal += '0';
                }
                index++;
            }

            string output = (beforeDecimal.Length > 0 && afterDecimal.Length > 0) ? beforeDecimal + "." + afterDecimal
                : (afterDecimal.Length > 0) ? "0." + afterDecimal
                : "0";
                
            return output;
        }  

        /* -- HELPER FUNCTIONS -- */
        string Reverse(string what) {
            char[] list = what.ToCharArray();
            Array.Reverse(list);
            return new string(list);
        }
    }   
}