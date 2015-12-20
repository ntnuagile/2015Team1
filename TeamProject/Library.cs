using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject
{
	class Library
	{
		public int numofbooks = 0;
		public Book[] books = new Book[10000];
		
		internal void AddBook(Book add)
		{
			books[numofbooks] = add;
			//books[numofbooks].ChangeStatusToBorrow()
			books[numofbooks].SetDate(DateTime.Now);
			numofbooks += 1;
		}
		private int FindBookIndex(String ISBN)
		{
			for(int i=0; i<numofbooks; i+=1)
			{
				if (books[i].GetISBN() == ISBN) return i;
			}
			return -1;
		}

		internal void BorrowBook(String ISBN, String name)
		{
			int index = FindBookIndex(ISBN);
			if(index>=0)
			{
				books[index].ChangeBorrowPerson(name);
				books[index].ChangeStatusToBorrow();
			}
		}

		internal void DeleteBook(String ISBN)
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
		public Book[] FindBooks = new Book[10000];
		public Book[] SearchBookTitle(String title)
		{
			int num = 0;
			for(int i=0;i<numofbooks;i+=1)
			{
				if(books[i].GetTitle()==title)
				{
					FindBooks[num] = books[i];
					num += 1;
				}
			}
			return FindBooks;
		}
		public Book[] SearchBookAuthor(String Author)
		{
			int num = 0;
			for(int i=0;i<numofbooks;i+=1)
			{
				if(books[i].GetAuthor()==Author)
				{
					FindBooks[num] = books[i];
					num += 1;
				}
			}
			return FindBooks;
		}
			

	}
	
	

}
