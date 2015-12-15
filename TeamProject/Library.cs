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
			books[numofbooks].status = 1;
			books[numofbooks].date = DateTime.Now;
			numofbooks += 1;
		}
		private int FindBookIndex(String ISBN)
		{
			for(int i=0; i<numofbooks; i+=1)
			{
				if (books[i].ISBN== ISBN) return i;
			}
			return -1;
		}

		internal void BorrowBook(String ISBN, String name)
		{
			int index = FindBookIndex(ISBN);
			if(index>=0)
			{
				books[index].borrow_person = name;
				books[index].status = 0;
			}
		}
	}
	
	

}
