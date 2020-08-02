using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace HornetComm_2017
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> message = new List<string>();
            List<string> broadcast = new List<string>();
            string patternMsg = @"^([0-9]+) <-> ([A-Za-z0-9]+)$";
            string patternBroadcast = @"^([^0-9]+) <-> ([A-Za-z0-9]+)$";
            string input;
            while((input = Console.ReadLine())!= "Hornet is Green")
            {
                Match matchMsg = Regex.Match(input, patternMsg);
                if(matchMsg.Success)
                {
                    string recipientsCode = matchMsg.Groups[1].Value;
                    string messageMatched = matchMsg.Groups[2].Value;
                    recipientsCode =new string(recipientsCode.Reverse().ToArray());
                    message.Add($"{recipientsCode} -> {messageMatched}");
                }
                else
                {
                    Match matchBroadcast = Regex.Match(input, patternBroadcast);
                    if(matchBroadcast.Success)
                    {
                        string msgBroadcast = matchBroadcast.Groups[1].Value;
                        string frequency = matchBroadcast.Groups[2].Value;

                        frequency = DecryptFrequency(frequency);
                        broadcast.Add($"{frequency} -> {msgBroadcast}");
                    }
                }
            }
            Console.WriteLine("Broadcasts:");
            if (broadcast.Count > 0)
            {
                Console.WriteLine(string.Join(Environment.NewLine, broadcast));
            }
            else
            {
                Console.WriteLine("None");
            }
            Console.WriteLine("Messages:");
            if(message.Count > 0)
            {
                Console.WriteLine(string.Join(Environment.NewLine, message));
            }
            else
            {
                Console.WriteLine("None");
            }

        }

        private static string DecryptFrequency(string frequency)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var letter in frequency)
            {
                if (letter >= 'a' && letter <= 'z')
                {
                    sb.Append(letter.ToString().ToUpper());
                }
                else if (letter >= 'A' && letter <= 'Z')
                {
                    sb.Append(letter.ToString().ToLower());
                }
                else
                {
                    sb.Append(letter);
                }
            }
            frequency = sb.ToString();
            return frequency;
        }
    }
}
