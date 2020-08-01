using System;
using System.Collections.Generic;

namespace P01.EmailValidator_Dec2019
{
    class Program
    {
        static void Main(string[] args)
        {
            string email = Console.ReadLine();
            string cmd;

            while ((cmd = Console.ReadLine()) != "Complete")
            {
                string[] cmdArg = cmd.Split();

                string command = cmdArg[0];
                if (command == "Make")
                {
                    if (cmdArg[1] == "Upper")
                    {
                        email = email.ToUpper();
                        Console.WriteLine(email);
                    }
                    else if (cmdArg[1] == "Lower")
                    {
                        email = email.ToLower();
                        Console.WriteLine(email);

                    }
                }
                else if (command == "GetDomain")
                {
                    int count = int.Parse(cmdArg[1]);
                    string substring = email.Substring(email.Length - count);
                    Console.WriteLine(substring);
                }
                else if (command == "GetUsername")
                {
                    int index = email.IndexOf('@');
                    if (index != -1)
                    {
                        string substring = email.Substring(0, index);
                        Console.WriteLine(substring);
                    }
                    else
                    {
                        Console.WriteLine($"The email {email} doesn't contain the @ symbol.");
                    }
                }
                else if (command == "Replace")
                {
                    char letter = char.Parse(cmdArg[1]);
                    email = email.Replace(letter, '-');
                    Console.WriteLine(email);
                }
                else if (command == "Encrypt")
                {
                    List<int> asciiCode = new List<int>();
                    foreach (var letter in email)
                    {
                        asciiCode.Add((int)letter);
                    }
                    Console.WriteLine(string.Join(" ", asciiCode));
                }
            }
        }
    }
}
