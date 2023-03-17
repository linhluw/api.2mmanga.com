using System;

namespace MyWeb.COM.Helper
{
    public class RandomTextGenerator
    {
        const string LOWER_CASE = "abcdefghijklmnopqursuvwxyz";
        const string UPPER_CAES = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        const string NUMBERS = "123456789";
        const string SPECIALS = @"!@£$%^&*()#€";

        public static string GenerateText(bool useLowercase, bool useUppercase, bool useNumbers, bool useSpecial,
            int textSize)
        {
            char[] _text = new char[textSize];
            string charSet = ""; // Initialise to blank
            System.Random _random = new Random();
            int counter;

            // Build up the character set to choose from
            if (useLowercase) charSet += LOWER_CASE;

            if (useUppercase) charSet += UPPER_CAES;

            if (useNumbers) charSet += NUMBERS;

            if (useSpecial) charSet += SPECIALS;

            for (counter = 0; counter < textSize; counter++)
            {
                _text[counter] = charSet[_random.Next(charSet.Length - 1)];
            }

            return String.Join(null, _text);
        }
    }
}
