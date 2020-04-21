using System;

namespace BinaryConverter
{
    public class Input
    {
        public string result;
        public Input(string message, Type dataType) {
            int intResponse;
            double doubleResponse;

            int attempts = 0;
            while (attempts < 3) {
                System.Console.Write(message + ": ");
                string result = Console.ReadLine();

                if (dataType == typeof(int) && int.TryParse(result, out intResponse)) 
                    this.result = intResponse.ToString();
                else if (dataType == typeof(double) && double.TryParse(result, out doubleResponse)) 
                    this.result = doubleResponse.ToString();
                else if (dataType == typeof(string) && result != "") 
                    this.result = result;
                else 
                    this.result = null;

                if (this.result == null) {
                    System.Console.WriteLine("Invalid input.");
                    attempts++;
                }
                else {
                    break;
                }
            }
        }
    }
}