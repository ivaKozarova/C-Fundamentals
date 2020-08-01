using System;
using System.Text.RegularExpressions;

namespace P02.Registration_Dec2019
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int countOfSuccessiful = 0;
            string pattern = @"^(U\$)([A-Z][a-z]{2,})\1(P@\$)([A-Za-z]{5,}[0-9]+)\3$";
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                Match match = Regex.Match(input, pattern);

                if(match.Success)
                {
                    string userName = match.Groups[2].Value;
                    string password = match.Groups[4].Value;
                    Console.WriteLine("Registration was successful");
                    Console.WriteLine($"Username: {userName}, Password: {password}");
                    countOfSuccessiful++;
                }
                else
                {
                    Console.WriteLine("Invalid username or password");
                }
            }
            Console.WriteLine($"Successful registrations: {countOfSuccessiful}");
        }
    }
}
