using System;
using System.Collections.Generic;
using System.Linq;

public class SetCover
{
    public static void Main(string[] args)
    {
        int[] universe = new[] { 1, 2, 3, 4, 5 };
        int[][] sets = new[]
        {
                new[] { 1, 2, 3, 4, 5},
                new[] {2, 3, 4, 5},
                new[] {5},
                new[] {3}
                
        };

        List<int[]> selectedSets = ChooseSets(sets.ToList(), universe.ToList());
        Console.WriteLine($"Sets to take ({selectedSets.Count}):");

        foreach (int[] set in selectedSets)
        {
            Console.WriteLine($"{{ {string.Join(", ", set)} }}");
        }
    }

    public static List<int[]> ChooseSets(IList<int[]> sets, IList<int> universe)
    {
        var selectedList = new List<int[]>();
        while (universe.Count > 0)
        {            
            var orderedSets = sets.OrderByDescending(x => x.Count(universe.Contains)).First();
            selectedList.Add(orderedSets);
            sets.Remove(orderedSets);
            foreach (var el in orderedSets)
            {
                if(universe.Contains(el))
                {
                    universe.Remove(el);
                }
            }

        }
        return selectedList;


        
    }
}
