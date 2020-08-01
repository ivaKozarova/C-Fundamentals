using System;

namespace MultiplyBigNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string bigNumber = Console.ReadLine();
            int digit = int.Parse(Console.ReadLine());
            string resut = "";
            int remainder = 0;
            if (digit == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                for (int i = bigNumber.Length - 1; i >= 0; i--)
                {
                    int number = (bigNumber[i] - '0');
                    int multi = number * digit + remainder;
                    remainder = multi / 10;
                    string numberToAdd = (multi % 10).ToString();
                    resut = numberToAdd + resut;

                }
                if (remainder != 0)
                {
                    resut = remainder + resut;
                }
                for (int i = 0; i < resut.Length; i++)
                {
                    if(resut[i] == '0')
                    {
                        resut = resut.Remove(0, 1);
                        i--;
                    }
                    else
                    {
                        break;
                    }
                }
                Console.WriteLine(resut);
            }
                
           
        }
    }
}
