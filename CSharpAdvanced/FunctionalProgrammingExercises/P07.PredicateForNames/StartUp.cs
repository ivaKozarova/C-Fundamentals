using System;

namespace P07.PredicateForNames
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var names = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);


            Func<string, string> selectName = name =>
            {
                if (name.Length <= n)
                {
                    return name;
                }
                else
                {
                    return null;
                }
            };

            for (int i = 0; i < names.Length; i++)
            {
                string result = selectName(names[i]);
                if(result != null)
                {
                    Console.WriteLine(result);
                }
            }
        }
    }
}
