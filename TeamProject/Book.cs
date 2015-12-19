using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject
{

	public class Book
	{
		private string ISBN;//1
		private string title;//2
		private string author;//3
		private string seller;//4
		private string location;//5
		private int price;
		private bool avalible = true;
		private string borrow_person;
		private DateTime date;

		public void SetBookData(string [] d, int p)
		{
			ISBN = d[0];
			title = d[1];
			author = d[2];
			seller = d[3];
			location= d[4];
			price  = p;
		}

		public void ChangeStatusToBorrow() { avalible = false; }
		public void SetDate(DateTime d) { date = d; }
		public string GetISBN() { return ISBN; }
		public string GetTitle() { return title; }
		public string GetAuthor() { return author; }
		public string GetSeller() { return seller; }
		public string GetLocation() { return location; }
		public int GetPrice() { return price; }
		public string GetBorrowPerson() { return borrow_person; }

		public void ChangeBorrowPerson(string name) { borrow_person = name; }
	}
}
