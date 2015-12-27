﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject
{
	class Library
	{
		public const int maxBookNum = 10000;
		public int numofbooks = 0;
		public Book[] books = new Book[maxBookNum];

		// About Search
		private Book[] findResult = new Book[maxBookNum];
		private int numOfFind = 0;

		internal void AddBook(Book add)
		{
			books[numofbooks] = add;
			books[numofbooks].SetDate(DateTime.Now);
			numofbooks += 1;
		}

		public int FindBookIndex(String ISBN)
		{
			for(int i = 0 ; i < numofbooks; i += 1)
				if (books[i].GetISBN() == ISBN)
					return i;
			return -1;
		}

		internal void BorrowBook(String ISBN, String name)
		{
			int index = FindBookIndex(ISBN);
			if(index >= 0 && books[index].GetAvailible()==true)
			{
				books[index].ChangeBorrowPerson(name);
				books[index].ChangeStatusToBorrow();
				books[index].SetAvailible(false);
			}
		}


        public string Borrow(String ISBN, String name)
        {
            int index = FindBookIndex(ISBN);
			if (index >= 0 && books [index].GetAvailible () == true) {
				books [index].ChangeBorrowPerson (name);
				books [index].ChangeStatusToBorrow ();
				books [index].SetAvailible (false);
				return "Borrow Success";
			}
			else
				return (index < 0) ? "Book not found" : "This book already be borrowed";
        }

        public string Return(String ISBN)
        {
            int index = FindBookIndex(ISBN);
            if (index >= 0 && books[index].GetAvailible() == false)
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

		public void ReserveBook(string ISBN)
		{
			int index = FindBookIndex(ISBN);
			if (books[index].GetAvailible() == false)
			{
				books[index].SetReservation(true);	
			}
		}

		public bool SearchReservation(string ISBN)
		{
			int index = FindBookIndex(ISBN);
			if(books[index].GetReservation() == true)
			{
				return true;
			}
			return false;
		}

		public void DeleteReservation(string ISBN)
		{
			int index = FindBookIndex(ISBN);
			if (books[index].GetReservation() == true)
				books[index].SetReservation(false);
		}
	}
}
