using System;

namespace Tuple
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var inputPersonInfo = Console.ReadLine().Split();

            var name = $"{inputPersonInfo[0]} {inputPersonInfo[1]}";
            var address = inputPersonInfo[2];
            var town = inputPersonInfo[3];
            var personInfo = new Threeuple<string, string,string>(name,address,town);


            var inputPersonBeer = Console.ReadLine().Split();

            var nameBeer = inputPersonBeer[0];
            var beerInLiters = int.Parse(inputPersonBeer[1]);
            var isDrunk = inputPersonBeer[2] == "drunk" ? true : false;
            var amountOfBeer = new Threeuple<string, int,bool>(nameBeer, beerInLiters,isDrunk);

            var inputNumbers = Console.ReadLine().Split();

            var personName = inputNumbers[0];
            var doubleNum = double.Parse(inputNumbers[1]);
            var bank = inputNumbers[2];
            var numbers = new Threeuple<string, double, string>(personName, doubleNum,bank);

            Console.WriteLine(personInfo);
            Console.WriteLine(amountOfBeer);
            Console.WriteLine(numbers);


        }
    }
}
