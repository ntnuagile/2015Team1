using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject
{
	class Library
	{
		public const int maxBookNum = 10000;
		public const int maxBorrowNum = 10;
		private const int maxFindNum = 100;

		public int numofbooks = 0;
		public Book[] books = new Book[maxBookNum];
		private int idCounter_ = 1;

		// About Search
		private Book[] findResult = new Book[maxBookNum];
		private int numOfFind = 0;

		//For checking a member's borrowing book(s)
		public Book[] BorrowingBook = new Book[maxBorrowNum];
		private int numofborrowing = 0;

		internal void AddBook(Book add)
		{
			books[numofbooks] = add;
			books[numofbooks].SetDate(DateTime.Now);
			books[numofbooks].SetID(idCounter_);
			idCounter_ += 1;
			numofbooks += 1;
		}

		public int FindBookIndex(String ISBN)
		{
			for(int i = 0 ; i < numofbooks; i += 1)
				if (books[i].GetISBN() == ISBN)
					return i;
			return -1;
		}

		public string BorrowBook(String ISBN, String name)
		{
			int index = FindBookIndex(ISBN);
			if (index >= 0 && books [index].isAvailible () == true) {
				books [index].ChangeBorrowPerson (name);
				books[index].SetDate(DateTime.Now);
				books [index].ChangeStatusToBorrow ();
				books [index].SetAvailible (false);
				return "Borrow Success";
			}
			else
				return (index < 0) ? "Book not found" : "This book already be borrowed";
		}

		public string ReturnBook(String ISBN)
		{
			int index = FindBookIndex(ISBN);
			if (index >= 0 && books[index].isAvailible() == false)
			{
				books[index].ChangeBorrowPerson(null);
				books[index].SetAvailible(true);
				return "Return Success";
			}
			else
				return (index < 0) ? "Book not found" : "This book already be returned";
		}
		public void DeleteBook(string ISBN)
		{
			int index = FindBookIndex(ISBN);
			if(index >= 0)
			{
				books[index].SetISBN("");
				books[index].SetTitle("");
				books[index].SetAuthor("");
				books[index].SetSeller("");
				books[index].SetLocation("");
				books[index].SetPrice(0);
			}
			numofbooks -= 1;
		}

		public Book[] SearchBookTitle(String title)
		{
			for(int i = 0 ; i < numofbooks ; i += 1)
				if(books[i].GetTitle() == title)
				{
					findResult[numOfFind] = books[i];
					numOfFind += 1;
				}
			return findResult;
		}

		public Book[] SearchBookAuthor(String Author)
		{
			for(int i = 0 ; i < numofbooks ; i += 1)
				if(books[i].GetAuthor() == Author)
				{
					findResult[numOfFind] = books[i];
					numOfFind += 1;
				}
			return findResult;
		}

		// Edit book

		public int FindBookIndexbyID(int ID)
		{
			for (int i = 0; i < numofbooks; i += 1)
				if (books[i].GetID() == ID)
					return i;
			return -1;
		}

		public int[] SearchTitle(String title)
		{
			int[] findID = new int [maxFindNum];
			int counter = 0;
			for (int i = 0; i < numofbooks; i += 1)
				if (books[i].GetTitle() == title)
				{
					findID[counter] = books[i].GetID();
					counter += 1;
				}
			return findID;
		}

		public bool EditBook(Book edit, int index)
		{
			if (index == -1)
				return false;

			books[index].SetISBN(edit.GetISBN());
			books[index].SetTitle(edit.GetTitle());
			books[index].SetAuthor(edit.GetAuthor());
			books[index].SetSeller(edit.GetSeller());
			books[index].SetLocation(edit.GetLocation());
			books[index].SetPrice(edit.GetPrice());
			return true;
		}

		public bool EditBookbyTitle(Book edit, String Title, int choose)
		{
			return EditBook(edit, FindBookIndexbyID(SearchTitle(Title)[choose]));
			//SearchTitle returns books' id, choose to control which book's id to edit.
			//FindBookIndexbyID returns the book's index in the array
		}

		// End of Edit book

		public Book[] CheckBorrowing(string name)
		{
			numofborrowing = 0;
			for(int i=0; i<numofbooks; i+=1)
			{
				if(books[i].GetBorrowPerson() == name)
				{
					BorrowingBook[numofborrowing] = books[i];
					numofborrowing += 1;
				}
			}
			return BorrowingBook;
		}


		public void ReserveBook(string ISBN, string name)
		{
			int index = FindBookIndex(ISBN);
			if (books[index].isAvailible() == false)
			{
				books[index].SetReservation(name);
			}
		}

		public bool SearchReservation(string ISBN)
		{
			int index = FindBookIndex(ISBN);
			return books[index].isReserved();
		}

		public void CancelReservation(string ISBN)
		{
			int index = FindBookIndex(ISBN);
			if (books[index].isReserved() == true)
				books[index].CancelReservation();
		}
	}
}
