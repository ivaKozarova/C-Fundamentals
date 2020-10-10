using System.Collections.Generic;
using System.Linq;

namespace IteratorsAndComparators
{
    public class Book
    {
        public Book(string title, int year, params string[] authors)
        {
            this.Authors = authors.ToList();
            this.Title = title;
            this.Year = year;

        }
        public string Title { get; set; }

        public int Year { get; set; }

        public List<string> Authors { get; }

        public override string ToString()
        {
            var res = $"{this.Title} , {this.Year}, {string.Join(',',this.Authors)}";
            return res.ToString();
        }

    }

  
}
