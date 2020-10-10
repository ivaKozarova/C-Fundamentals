
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace IteratorsAndComparators
{
    public class BookComparator : IComparer<Book>
    {
        public int Compare([AllowNull] Book firstBook, [AllowNull] Book secondBook)
        {
            int result = 1;
            result = firstBook.Title.CompareTo(secondBook.Title);
            if(result == 0)
            {
                result = firstBook.Year.CompareTo(secondBook.Year);
            }
            return result;

        }
    }
}
