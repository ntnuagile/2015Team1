using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject
{

	public class Book
	{
		public string ISBN;
		public string title;
		public string author;
		public string seller;
		public int price;
		public string location;
		public int status; //1=avalible
        public string borrow_person;
        internal void BorrowBook(String name)
        {
            borrow_person = name;
        }
	}
}
