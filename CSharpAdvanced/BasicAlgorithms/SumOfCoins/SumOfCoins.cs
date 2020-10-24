using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

public class SumOfCoins
{
    public static void Main(string[] args)
    {
        var availableCoins = new[] { 3,7};
        var targetSum = 11;

        var selectedCoins = ChooseCoins(availableCoins, targetSum);

        Console.WriteLine($"Number of coins to take: {selectedCoins.Values.Sum()}");
        foreach (var selectedCoin in selectedCoins)
        {
            Console.WriteLine($"{selectedCoin.Value} coin(s) with value {selectedCoin.Key}");
        }
    }

    public static Dictionary<int, int> ChooseCoins(IList<int> coins, int targetSum)
    {
        int sum = 0;
        
        var result = new Dictionary<int, int>();
        var sortedCoins = coins.OrderByDescending(x => x).ToList();

        for (int i = 0; i < sortedCoins.Count; i++)
        {
            int count = (targetSum - sum) / sortedCoins[i];
            sum += sortedCoins[i] * count;
            if (count != 0)
            {

                result[sortedCoins[i]] = count;
            }
                        
        }
        if(targetSum != sum)
        {
            throw new InvalidOperationException();
        }
        
        return result;
    }
}