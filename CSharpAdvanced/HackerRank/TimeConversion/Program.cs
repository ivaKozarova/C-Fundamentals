using System;
using System.Globalization;
using System.Net.Http.Headers;

namespace TimeConversion
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = Console.ReadLine();
            string result = TimeConversion(s);
            Console.WriteLine(result);
        }

        static string TimeConversion(string s)
        {
            
            DateTime time = DateTime.Parse(s);
            string result = time.ToString("HH:mm:ss");
            return result;
        }
    }
}
