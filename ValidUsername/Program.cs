using System;
using System.Linq;

namespace ValidUsername
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] usernames = Console.ReadLine().Split(", ").ToArray();
            for (int i = 0; i < usernames.Length; i++)
            {
                bool isValid = true;
                if (usernames[i].Length >= 3 && usernames[i].Length <= 16)
                {
                    foreach (var letter in usernames[i])
                    {
                        if (!(char.IsLetterOrDigit(letter) || letter == '-' || letter == '_'))
                        {
                            isValid = false;
                            break;
                        }
                    }
                }
                else
                {
                    isValid = false;
                }
                if(isValid == true)
                {
                    Console.WriteLine(usernames[i]);
                }
            }
        }
    }
}
