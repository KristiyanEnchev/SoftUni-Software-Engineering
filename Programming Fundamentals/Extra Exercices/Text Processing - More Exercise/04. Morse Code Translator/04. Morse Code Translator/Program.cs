using System;
using System.Collections.Generic;
using System.Linq;

namespace _04
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] sequance = Console.ReadLine()
                .Split("|", StringSplitOptions.RemoveEmptyEntries);

            Dictionary<string, char> morseCode = MorseCodeInicialization();

            string sentence = string.Empty;

            foreach (var item in sequance)
            {
                string[] newSequance = item.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                foreach (var letter in newSequance)
                {
                    if (morseCode.ContainsKey(letter))
                    {
                        char ch = morseCode[letter];
                        sentence += ch;
                    }
                }
                sentence += " ";
            }

            Console.WriteLine(sentence.ToUpper()); ;
        }

        private static Dictionary<string, char> MorseCodeInicialization()
        {
            Dictionary<string, char> morseCodeDictionary = new Dictionary<string, char>() {
                                       {".-",'a'},
                                       {"-...",'b'},
                                       {"-.-.",'c'},
                                       {"-..",'d'},
                                       {".",'e'},
                                       {"..-.",'f'},
                                       {"--.",'g'},
                                       {"....",'h'},
                                       {"..",'i'},
                                       {".---",'j'},
                                       {"-.-",'k'},
                                       {".-..",'l'},
                                       {"--",'m'},
                                       {"-.",'n'},
                                       {"---",'o'},
                                       {".--.",'p'},
                                       {"--.-",'q'},
                                       {".-.",'r'},
                                       {"...",'s'},
                                       {"-",'t'},
                                       {"..-",'u'},
                                       {"...-",'v'},
                                       {".--",'w'},
                                       {"-..-",'x'},
                                       {"-.--",'y'},
                                       {"--..",'z'},
                                       {"-----",'0'},
                                       {".----",'1'},
                                       {"..---",'2'},
                                       {"...--",'3'},
                                       {"....-",'4'},
                                       {".....",'5'},
                                       {"-....",'6'},
                                       {"--...",'7'},
                                       {"---..",'8'},
                                       {"----.",'9'}
                                  };

            return morseCodeDictionary;
        }
    }
}
