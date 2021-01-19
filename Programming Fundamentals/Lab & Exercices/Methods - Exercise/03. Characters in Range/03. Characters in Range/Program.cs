namespace CharactersInRange
{
    using System;

    public class EntryPoint
    {
        public static void Main()
        {
            char inputOne = char.Parse(Console.ReadLine());
            char inputTwo = char.Parse(Console.ReadLine());

            PrintTheCharsBetweenTwoChars(inputOne, inputTwo);
        }

        private static void PrintTheCharsBetweenTwoChars(char firstCharacter, char secondCharacter)
        {
            int startCharacter = Math.Min(firstCharacter, secondCharacter);
            int endCharacter = Math.Max(firstCharacter, secondCharacter);

            for (int i = ++startCharacter; i < endCharacter; i++)
            {
                Console.Write((char)i + " ");
            }

            Console.WriteLine();
        }
    }
}