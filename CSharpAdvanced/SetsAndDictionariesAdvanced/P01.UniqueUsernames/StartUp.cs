using System;
using System.Collections.Generic;

namespace P01.UniqueUsernames
{
    class StartUp
    {
        static void Main(string[] args)
        {

            var usernames = new HashSet<string>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var username = Console.ReadLine();
                usernames.Add(username);
               }
            Console.WriteLine(string.Join(Environment.NewLine, usernames));
        }
    }
}
