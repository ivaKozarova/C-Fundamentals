using System;
using System.IO;
using System.Linq;
using System.Text;

namespace CustomMinFunctionReadedFromStream
{
    class Program
    {
        static void Main(string[] args)
        {
            string line;
            StringBuilder sb = new StringBuilder();
            while ((line = Console.ReadLine()) != "end")
            {
                sb.AppendLine(line);
            }
            using (StreamWriter writer = new StreamWriter("numbers.txt"))
            {
                writer.WriteLine(sb);

                writer.Flush();
            }

            using (StreamReader reader = new StreamReader("numbers.txt"))
            {
                string readLine;

                while ((readLine = reader.ReadLine()) != null)
                {
                    var nums = readLine
                        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();
                    if (nums.Length > 0)
                    {

                        Func<int[], int> smallest = new Func<int[], int>(n =>
                        {
                            int min = Int32.MaxValue;
                            foreach (var num in nums)
                            {
                                if (num < min)
                                {
                                    min = num;
                                }
                            }
                            return min;
                        });
                        int result = smallest(nums);
                        Console.WriteLine(result);
                    }
                }
            }
        }
    }
}
