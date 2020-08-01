using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.RegularExpressions;

namespace P02.SongEncryption_July2019
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;

            while ((input = Console.ReadLine()) != "end")
            {
                string validate = ValidateInput(input);
                if (validate == string.Empty)
                {
                    Console.WriteLine("Invalid input!");
                }

                else
                {
                    int key = validate.IndexOf(":") % 26;
                    
                    StringBuilder sb = new StringBuilder();
                    foreach (var letter in validate)
                    {
                        char letterEnc = letter;

                        if (letter == ':')
                        {
                            letterEnc = '@';
                        }
                        else if(char.IsLetter(letter))
                        {
                            if (letter >= 'a' && letter <= 'z')
                            {
                                if (letter + key <= 'z')
                                {
                                    letterEnc = (char)(letter + key);
                                }
                                else
                                {
                                    int newKey = key - ('z' - letter);
                                    letterEnc = (char)('a' + newKey - 1);
                                }
                            }
                            else if (letter >= 'A' && letter <= 'Z')
                            {
                                if (letter + key <= 'Z')
                                {
                                    letterEnc = (char)(letter + key);
                                }
                                else
                                {
                                    int keyNew = key - ('Z' - letter);
                                    letterEnc = (char)('A' + keyNew - 1);
                                }
                            }
                        }
                        sb.Append(letterEnc);
                    }
                    validate = sb.ToString();
                    Console.WriteLine($"Successful encryption: {validate}");
                }

            }

        }


        private static string ValidateInput(string input)
        {
            string pattern = @"^(?<artist>[A-Z][a-z\' ]+):(?<song>[A-Z][A-Z ]+)$";
            Match match = Regex.Match(input, pattern);
            string validInput = string.Empty;
            if (match.Success)
            {
                string artist = match.Groups["artist"].Value;
                string song = match.Groups["song"].Value;
                validInput = artist + ':' + song;
            }
            return validInput;
        }
    }

}
