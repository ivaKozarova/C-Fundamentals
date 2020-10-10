using System;

namespace Demo

{
    class StartUp
    {
        static void Main(string[] args)
        {
            var numbers = new Numbers(new[]{ 1, 3, 5, 7 });
            foreach (var number in numbers)
            {
                Console.WriteLine(number);
            }

            int sum = 0;
            foreach (var num in numbers)
            {
                sum += num;
            }
            Console.WriteLine(sum);
        }
    }
}
