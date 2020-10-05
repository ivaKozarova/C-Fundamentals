using System;
using System.Data.Common;

namespace GenericScale
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var scale = new EqualityScale<double>(23.5, 23.6);
            Console.WriteLine(scale.AreEqual());

        }
    }
}
