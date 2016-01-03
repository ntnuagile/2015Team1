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
		private int id_ = -1;
		private string ISBN_ = ""; //1
		private string title_ = ""; //2
		private string author_ = ""; //3
		private string seller_ = ""; //4
		private string location_ = ""; //5
		private int price_ = 0;
		private int borrowed_time_ = 0;//被借閱次數
		private bool recommended_ = false;

		// About Borrow
		private bool availible_ = true;
		private string borrow_person;
		private DateTime date_;
		private bool reserved_ = false;
		private string reserve_person;

		//others
		private bool later_ = false;

		public void SetBookData(string[] d, int p)
		{
			ISBN_ = d[0];
			title_ = d[1];
			author_ = d[2];
			seller_ = d[3];
			location_ = d[4];
			price_ = p;
		}

		// get value
		public int GetID() { return id_; }
		public int GetPrice() { return price_; }
		public string GetISBN() { return ISBN_; }
		public string GetTitle() { return title_; }
		public string GetAuthor() { return author_; }
		public string GetSeller() { return seller_; }
		public string GetLocation() { return location_; }
		public string GetBorrowPerson() { return borrow_person; }
		public bool isAvailible() { return availible_; }
		public bool isReserved() { return reserved_; }
		public bool GetReadLater() { return later_;  }
		public int GetBorrowTime() { return borrowed_time_; }
		public bool Recommended() { return recommended_; }

		public void SetID(int id) { id_ = id; }
		public void SetISBN(string ISBN) { ISBN_ = ISBN; }
		public void SetTitle(string Title) { title_ = Title; }
		public void SetAuthor(string author) { author_ = author; }
		public void SetSeller(string seller) { seller_ = seller; }
		public void SetLocation(string location) { location_ = location; }
		public void SetPrice(int price) { price_ = price; }
		public void SetDate(DateTime d) { date_ = d; }
		public void SetAvailible(bool availible) { availible_ = availible; }
		public void SetReservation(string name) { reserved_ = true; reserve_person = name; }
		public void CancelReservation() { reserved_ = false; reserve_person = ""; }
		public void BeRecommended() { recommended_ = true; }
		public void AddBorrowTime() { borrowed_time_ += 1; }

		public void ChangeStatusToBorrow() { availible_ = false; }
		public void ChangeBorrowPerson(string name) { borrow_person = name; }
		public void SetReadLater(string name) { later_ = true; }
		//public void ChangeReservePerson(string name) { reserve_person = name; }
	}
}
