using System;
using System.Collections.Generic;

namespace MultiplyBigNumber
{
    class Program
    {
        static void Main()
        {
            string bigNum = Console.ReadLine();

            byte multiplier = byte.Parse(Console.ReadLine());

            List<int> newNum = new List<int>();

            int additional = 0;

            for (int i = bigNum.Length - 1; i >= 0; i--)
            {
                byte digit = byte.Parse(bigNum[i].ToString());
                int multiplied = digit * multiplier + additional;

                newNum.Insert(0, multiplied % 10);

                if (multiplied >= 10)
                {
                    additional = multiplied / 10;
                }
                else
                {
                    additional = 0;
                }
            }

            if (additional > 0)
            {
                newNum.Insert(0, additional);
            }
            for (int i = 0; i < newNum.Count; i++)
            {
                if (newNum[i] == 0)
                {
                    newNum.Remove(0);
                    i--;
                }
                else
                {
                    break;
                }
            }
            Console.WriteLine(string.Join("", newNum));
        }
    }
}