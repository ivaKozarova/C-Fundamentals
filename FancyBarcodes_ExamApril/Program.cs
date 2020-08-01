using System;
using System.Text.RegularExpressions;

namespace FancyBarcodes_ExamApril
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Regex findBarcode = new Regex(@"^@#+(?<barcode>[A-Z]{1}[A-Za-z0-9]{4,}[A-Z])@#+$");
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                MatchCollection matches = findBarcode.Matches(input);
                if (matches.Count == 0)
                {
                    Console.WriteLine("Invalid barcode");

                }
                else
                {
                    foreach (Match item in matches)
                    {
                        
                        string product = item.Groups["barcode"].Value;
                        string productGroup = "";
                        foreach (char letter in product)
                        {
                            if (char.IsDigit(letter))
                            {
                                productGroup += letter;
                            }
                        }
                        if (productGroup == "")
                        {
                            productGroup = "00";
                        }
                        Console.WriteLine($"Product group: {productGroup}");
                    }
                }
            }
        }
    }
}
