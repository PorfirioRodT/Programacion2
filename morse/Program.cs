using System;
using System.Collections.Generic;

namespace morse
{
    class Program
    {

        public static Dictionary <char, string> _morseAlphabetDictionary;
        static void Main(string[] args)
        {

            int frequency = 450;
            int dot = 128, dash = dot * 3, space = dot * 7;

            _morseAlphabetDictionary = new Dictionary<char, string>(){

                {'a', ".-"},
                {'A', ".-"},
                {'b', "-..."},
                {'B', "-..."},
                {'c', "-.-."},
                {'C', "-.-."},
                {'d', "-.."},
                {'D', "-.."},
                {'e', "."},
                {'E', "."},
                {'f', "..-."},
                {'F', "..-."},
                {'g', "--."},
                {'G', "--."},
                {'h', "...."},
                {'H', "...."},
                {'i', ".."},
                {'I', ".."},
                {'j', ".---"},
                {'J', ".---"},
                {'k', "-.-"},
                {'K', "-..."},
                {'l', ".-.."},
                {'L', ".-.."},
                {'m', "--"},
                {'M', "--"},
                {'n', "-."},
                {'N', "-."},
                {'o', "---"},
                {'O', "---"},
                {'p', ".--."},
                {'P', ".--."},
                {'q', "--.-"},
                {'Q', "--.-"},
                {'r', ".-."},
                {'R', ".-."},
                {'s', "..."},
                {'S', "..."},
                {'t', "-"},
                {'T', "-"},
                {'u', "..-"},
                {'U', "..-"},
                {'v', "...-"},
                {'V', "...-"},
                {'w', ".--"},
                {'W', ".--"},
                {'x', "-..-"},
                {'X', "-..-"},
                {'y', "-.--"},
                {'Y', "-.--"},
                {'z', "--.."},
                {'Z', "--.."},
                {'0', "-----"},
                {'1', ".----"},
                {'2', "..---"},
                {'3', "...--"},
                {'4', "....-"},
                {'5', "....."},
                {'6', "-...."},
                {'7', "--..."},
                {'8', "---.."},
                {'9', "----."}

            };

            String word;
            char characterR;

            try
            {

                for (int i = 0; i < args.Length; i++)
                {

                    word = args[i];
                    Console.Write("Texto: "+word+" esta palabra en codigo Morse: ");

                    for (int j = 0; j < word.Length; j++)
                    {

                        try
                        {

                            characterR = word[j];
                            Console.Write(_morseAlphabetDictionary[characterR]+ " | ");

                            foreach(var item in _morseAlphabetDictionary[characterR]){

                                if (item == '.')
                                {
                                    
                                    Console.Beep(frequency, dot);

                                } else {

                                    Console.Beep(frequency, dash);

                                }

                                System.Threading.Thread.Sleep(dash);

                            }

                            
                        }
                        catch (Exception e)
                        {
                            
                            Console.WriteLine(e.Message);
                            
                        }
                        
                    }

                    System.Threading.Thread.Sleep(space);
                    
                }
                
            }
            catch (Exception e)
            {
                
                Console.WriteLine(e.Message);
                
            }

        
        }
    }
}