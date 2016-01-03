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
		private const int maxWaitToBuyNum = 100;

		public int numofbooks = 0;
		public Book[] books = new Book[maxBookNum];
		private int idCounter_ = 1;

		// About Search
		private Book[] findResult = new Book[maxBookNum];
		private int numOfFind = 0;

		//For checking a member's borrowing book(s)
		public Book[] BorrowingBook = new Book[maxBorrowNum];
		private int numofborrowing = 0;

		//Save the list of a member's readlater books
		public Book[] ReadLaterBook = new Book[maxBorrowNum];
		// private int numofReadLater = 0;

		private string[,] WaitToBuy = new string[maxWaitToBuyNum, 4];	//Title, Author, Seller, Advisor
		private int numofWaitToBuy = 0;

		internal bool AddBook(Book add)
		{
			if (numofbooks == maxBookNum)
				return false;
			books[numofbooks] = add;
			books[numofbooks].SetAddTime(DateTime.Now);
			books[numofbooks].SetID(idCounter_);
			idCounter_ += 1;
			numofbooks += 1;
			return true;
		}

		public bool DeleteBook(string ISBN)
		{
			int index = FindBookIndex(ISBN);
			if (index < 0)
			{
				return false;
			}
			else
			{
				books[index].SetISBN("");
				books[index].SetTitle("");
				books[index].SetAuthor("");
				books[index].SetSeller("");
				books[index].SetLocation("");
				books[index].SetPrice(0);
				numofbooks -= 1;
				return true;
			}
		}

		public int FindBookIndexbyID(int ID)
		{
			for (int i = 0; i < numofbooks; i += 1)
				if (books[i].GetID() == ID)
					return i;
			return -1;
		}

		public int FindBookIndex(String ISBN)
		{
			for(int i = 0 ; i < numofbooks; i += 1)
				if (books[i].GetISBN() == ISBN)
					return i;
			return -1;
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
			// SearchTitle returns books' id, choose to control which book's id to edit.
			// FindBookIndexbyID returns the book's index in the array
		}

		public int[] SearchTitle(String title) //return ID
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

		public string BorrowBook(String ISBN, Member member)
		{
			int index = FindBookIndex(ISBN);
			if (index >= 0 && books [index].isAvailible () == true) {
				books [index].ChangeBorrowPerson (member);
				books[index].SetDate(DateTime.Now);
				books [index].ChangeStatusToBorrow ();
				books [index].SetAvailible (false);
				books[index].AddBorrowTime();
				return "Borrow Success";
			}
			else
				return (index < 0) ? "Book not found" : "This book already be borrowed";
		}

		/* ===================================================================================== */

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

		public Book[] CheckBorrowing(Member m)
		{
			numofborrowing = 0;
			for(int i=0; i<numofbooks; i+=1)
			{
				if(books[i].GetBorrowPerson() == m)
				{
					BorrowingBook[numofborrowing] = books[i];
					numofborrowing += 1;
				}
			}
			return BorrowingBook;
		}


		public void ReserveBook(string ISBN, Member member)
		{
			int index = FindBookIndex(ISBN);
			if (books[index].isAvailible() == false)
			{
				books[index].SetReservation(member);
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

		public void ReadLater(string ISBN, string name)
		{
			int index = FindBookIndex(ISBN);
			if (index >= 0)
			{
				books[index].SetReadLater(name);
			}
		}

		public bool CheckReadLater(string ISBN)
		{
			int index = FindBookIndex(ISBN);
			return books[index].GetReadLater();
		}

		public Book Recommend()
		{
			int max = 0, max_index = 0;
			for(int i=0; i<numofbooks; i+=1)
			{
				if(books[i].GetBorrowTime()>max && !books[i].Recommended())
				{
					max = books[i].GetBorrowTime();
					max_index = i;
				}
			}
			books[max_index].BeRecommended();
			return books[max_index];
		}

		public string AddWaitToBuy(string title, string author, string seller, string advisor)
		{
			if (numofWaitToBuy >= maxWaitToBuyNum) return "Overflow";
			WaitToBuy [numofWaitToBuy, 0] = title;
			WaitToBuy [numofWaitToBuy, 1] = author;
			WaitToBuy [numofWaitToBuy, 2] = seller;
			WaitToBuy [numofWaitToBuy, 3] = advisor;
			numofWaitToBuy++;
			return "Opinion Save";
		}
	}
}
