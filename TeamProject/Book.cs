using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject
{
	public class Book
	{
		// Basic Info
		private string	ISBN_		= ""; //1
		private string	title_		= ""; //2
		private string	author_		= ""; //3
		private string	seller_		= ""; //4
		private string	location_	= ""; //5
		private int	price_		= 0;

		// About Borrow
		private bool	 avalible_ = true;
		private string	 borrow_person;
		private DateTime date_;

		public void SetBookData(string [] d, int p)
		{
			ISBN_		= d[0];
			title_		= d[1];
			author_		= d[2];
			seller_		= d[3];
			location_	= d[4];
			price_		= p;
		}

		public void	ChangeStatusToBorrow() { avalible_ = false; }
		public void	SetDate(DateTime d) { date_ = d; }
		public string	GetISBN() { return ISBN_; }
		public string	GetTitle() { return title_; }
		public string	GetAuthor() { return author_; }
		public string	GetSeller() { return seller_; }
		public string	GetLocation() { return location_; }
		public int	GetPrice() { return price_; }
		public string	GetBorrowPerson() { return borrow_person; }

		public void SetISBN(string ISBN) { ISBN_ = ISBN; }
		public void SetTitle(string Title) { title_ = Title; }
		public void SetAuthor(string author) { author_ = author; }
		public void SetSeller(string seller) { seller_ = seller; }
		public void SetLocation(string location) { location_ = location; }
		public void SetPrice(int price) { price_ = price; }

		public void ChangeBorrowPerson(string name) { borrow_person = name; }
	}
}
