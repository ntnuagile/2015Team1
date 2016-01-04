using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject
{
    class History
    {
        public const int maxBookNum = 10000;
        public int num_of_history = 0;
        public Book[] books = new Book[maxBookNum];

        // About Search
        private Book[] findResult = new Book[maxBookNum];
        private int numOfFind = 0;

        internal void AddBook(Book add)
        {
            books[num_of_history] = add;
            books[num_of_history].SetDate(DateTime.Now);
            num_of_history += 1;
        }

        public int FindBookIndex(String ISBN)
        {
            for (int i = 0; i < num_of_history; i += 1)
                if (books[i].GetISBN() == ISBN)
                    return i;
            return -1;
        }

        public string ReturnBook(String ISBN)
        {
            int index = FindBookIndex(ISBN);
            //if (index >= 0 && books[index].GetAvailible() == false)
            if (index >= 0)
            {
                books[index].ChangeBorrowPerson(null);
                books[index].SetAvailible(true);
                return "Return Success";
            }
            else
                return (index < 0) ? "Book not found" : "This book already be returned";
        }
        public void DeleteBook(String ISBN)
        {
            int index = FindBookIndex(ISBN);
            if (index >= 0)
            {
                books[index].SetISBN("");
                books[index].SetTitle("");
                books[index].SetAuthor("");
                books[index].SetSeller("");
                books[index].SetLocation("");
                books[index].SetPrice(0);
            }
            num_of_history -= 1;
        }

        public Book[] SearchBookTitle(String title)
        {
            for (int i = 0; i < num_of_history; i += 1)
                if (books[i].GetTitle() == title)
                {
                    findResult[numOfFind] = books[i];
                    numOfFind += 1;
                }
            return findResult;
        }

        public Book[] SearchBookAuthor(String Author)
        {
            for (int i = 0; i < num_of_history; i += 1)
                if (books[i].GetAuthor() == Author)
                {
                    findResult[numOfFind] = books[i];
                    numOfFind += 1;
                }
            return findResult;
        }
    }
}
