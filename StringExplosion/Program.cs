using System;

namespace StringExplosion
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            int strength = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if(input[i] == '>')
                {
                    i++;
                    strength += input[i] -'0';
                    for (int j = i; j < input.Length; j++)
                    {
                        if (strength > 0)
                        {
                            if (input[j] != '>')
                            {
                                input = input.Remove(j, 1);
                                strength--;
                                j--;
                            }
                            else
                            {
                                i = j -1;
                                break;
                            }
                        }
                        else
                        {
                            i = j - 1;
                            break;
                        }
                    }
                    
                }
                
            }
            Console.WriteLine(input);
        }
    }
}
