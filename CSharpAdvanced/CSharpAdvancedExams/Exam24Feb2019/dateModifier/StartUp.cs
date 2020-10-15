using System;

namespace DateModifier
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string startDate = Console.ReadLine();
            string endDate = Console.ReadLine();

            

            var result = DateModifier.GetDatesDifference(startDate, endDate);

            Console.WriteLine(result);
        }
    }
}