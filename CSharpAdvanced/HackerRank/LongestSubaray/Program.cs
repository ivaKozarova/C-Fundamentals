using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

class Result
{
    public static void Main(string[] args)
    {



        List<int> arr = new List<int>();
                arr = Console.ReadLine().Split().Select(int.Parse).ToList();



        int result = Result.LongestSubarray(arr);
        Console.WriteLine(result);
    }

    public static int LongestSubarray(List<int> arr)
    {
        int result = 1;
        int currentLenght = 1;
       bool foundSecondVal = false;

        int secVal = 0;

        for (int i = 0; i < arr.Count -1; i++)
        {
           
            for (int j = i + 1; j < arr.Count; j++)
            {
                
                if (arr[i] == arr[j])
                {
                    currentLenght++;
                }
                else if (arr[i] + 1 == arr[j] || arr[i] - 1 == arr[j])
                {
                    if (foundSecondVal && arr[j] != secVal )
                    {
                        break;
                    }
                    else
                    {
                        currentLenght++;
                        secVal = arr[j];
                        foundSecondVal = true;
                    }
                }
                else
                {
                    break;
                }

            }
            if (currentLenght > result)
            {
                result = currentLenght;
                
            }
            currentLenght = 1;
            secVal = 0;
            foundSecondVal = false;
        }

        return result;
    }

}


    
