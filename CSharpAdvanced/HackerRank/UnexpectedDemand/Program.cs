using System;
using System.Collections.Generic;
using System.Linq;

class Result
{

    /*
     * Complete the 'filledOrders' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER_ARRAY order
     *  2. INTEGER k
     */

    public static int FilledOrders(List<int> order, int k)
    {
        order.Sort();

        int maxOrders = 0;
       
        for (int i = 0; i < order.Count; i++)
        {
            if(order[i] <= k)
            {
                maxOrders++;
                k -= order[i];
            }
         
        }
      return maxOrders;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        List<int> order = Console.ReadLine().Split().Select(int.Parse).ToList();
        int orderAmount = int.Parse(Console.ReadLine());
        int result = Result.FilledOrders(order, k);
        Console.WriteLine(result);


    }

        
}