using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace IteratorsAndComparators
{
    public class Book : IComparable<Book>
    {
        public Book(string title, int year, params string[] authors)
        {
            this.Title = title;
            this.Year = year;
            this.Authors = authors.ToList();

        }
        public string Title { get; set; }

        public int Year { get; set; }

        public List<string> Authors { get; }

        public int CompareTo([AllowNull] Book secondBook)
        {
            int result = 1;
            result = this.Year.CompareTo(secondBook.Year);
            if(result == 0)
            {
                result = this.Title.CompareTo(secondBook.Title);
            }

            return result;
        }

        public override string ToString()
        {
            var res = $"{this.Title} - {this.Year}";
            return res.ToString();
        }

    }


}
