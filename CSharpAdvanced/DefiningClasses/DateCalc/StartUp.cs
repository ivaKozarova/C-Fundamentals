using System;

namespace DateCalc
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string dateOne = Console.ReadLine();
            string dateTwo = Console.ReadLine();
            Console.WriteLine(DateModifier.CaclDaysBeetweenTwoDates(dateOne, dateTwo));
        }
    }
}
