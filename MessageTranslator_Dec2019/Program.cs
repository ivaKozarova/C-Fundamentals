using System;
using System.Text;
using System.Text.RegularExpressions;

namespace MessageTranslator_Dec2019
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Regex checkMsg = new Regex(@"^!(?<command>[A-Z][a-z]{2,})!:\[(?<msg>[A-za-z]{8,})\]$");

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                var message = checkMsg.Match(input);
                if (message.Success)
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append($"{message.Groups["command"]}: ");
                    foreach (var letter in message.Groups["msg"].ToString())
                    {
                        sb.Append($"{(int)letter} ");
                    }
                    Console.WriteLine(sb);
                }
                else
                {
                    Console.WriteLine("The message is invalid");
                }
            }
        }
    }
}
