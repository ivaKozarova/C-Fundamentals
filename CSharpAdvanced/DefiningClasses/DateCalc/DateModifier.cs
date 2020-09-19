using System;

namespace DateCalc
{
    class DateModifier
    {
       
        public static double CaclDaysBeetweenTwoDates(string firstDate, string secondDate)
        {
            DateTime dateOne = DateTime.Parse(firstDate);
            DateTime dateTwo = DateTime.Parse(secondDate);
            double result = Math.Abs((dateOne - dateTwo).TotalDays);
            return result;
        }
    }
}
