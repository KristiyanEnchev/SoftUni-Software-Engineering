using System;

namespace ConsoleApp64
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine().ToLower();
            string firstValidation = DigitCountValidator(password);
            string secondValidator = LettersAndDigitsOnlyValidator(password);
            string thurdValidator = PasswordLenghtValidator(password);
            if (firstValidation == "Valid" && secondValidator == "Valid" && thurdValidator == "Valid")
            {
                Console.WriteLine("Password is valid");
            }
            else
            {
                if (thurdValidator != "Valid")
                {
                    Console.WriteLine(thurdValidator);
                }
                if (secondValidator != "Valid")
                {
                    Console.WriteLine(secondValidator);
                }
                if (firstValidation != "Valid")
                {
                    Console.WriteLine(firstValidation);
                }
            }
        }

        public static string PasswordLenghtValidator(string pass)
        {
            string output = string.Empty;
            string invalidOutput = string.Empty;

            if (pass.Length < 6 || pass.Length > 10)
            {
                invalidOutput = "Password must be between 6 and 10 characters";
                return invalidOutput;
            }
            else
            {
                output = "Valid";
                return output;
            }

        }
        public static string LettersAndDigitsOnlyValidator(string pass)
        {
            string output = string.Empty;
            string invalidOutput = string.Empty;
            char areaOfChars = 'a', areaTo = 'z';
            char from = '0', to = '9';

            for (int i = 0; i < pass.Length; i++)
            {
                char letter = pass[i];
                if (pass[i] >= areaOfChars && pass[i] <= areaTo)
                {
                    output = "Valid";
                }
                else if (pass[i] >= from && pass[i] <= to)
                {
                    output = "Valid";
                }
                else
                {
                    invalidOutput = "Password must consist only of letters and digits";
                    break;
                }
            }
            if (output == "Valid" && invalidOutput == "")
            {
                return output;
            }
            else
            {
                return invalidOutput;
            }
        }

        public static string DigitCountValidator(string pass)
        {
            int count = 0;
            char from = '0', to = '9';
            string output = string.Empty;
            string invalidOutput = string.Empty;

            for (int i = 0; i < pass.Length; i++)
            {
                if (pass[i] >= from && pass[i] <= to)
                {
                    count++;
                }
            }
            if (count >= 0 && count < 2)
            {
                invalidOutput = "Password must have at least 2 digits";
                return invalidOutput;
            }
            else
            {
                output = "Valid";
                return output;
            }
        }
    }
}
