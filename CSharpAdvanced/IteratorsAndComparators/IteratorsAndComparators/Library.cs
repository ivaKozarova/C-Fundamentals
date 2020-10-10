
using System.Collections;
using System.Collections.Generic;

namespace IteratorsAndComparators
{
    public class Library: IEnumerable<Book>
    {
        public Library(params Book[] books)
        {
            this.Books = new List<Book>(books);
        }
        public List<Book>  Books { get; private set; }

        public void Add(Book book)
        {
            this.Books.Add(book);
        }

        public IEnumerator<Book> GetEnumerator()
        {
            return new LibraryIterator(Books);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }

    public class LibraryIterator : IEnumerator<Book>
    {
        private List<Book> books;
        private int currIndex = -1;

        public LibraryIterator(List<Book> books)
        {
            this.Reset();
            this.books = books;
        }

        public Book Current => this.books[this.currIndex];

        object IEnumerator.Current => this.Current;

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            currIndex ++;
            return (this.currIndex < this.books.Count);

        }

        public void Reset()
        {
            this.currIndex = -1;
        }
    }


}
