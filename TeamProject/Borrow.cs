using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject
{
	public class Borrow
	{
        private string id_;
        private string name_;
		public string id() { return id_; }
		public string name() { return name_; }
		internal void BorrowBook(Book book, String name)
		{
            id_ = book.ISBN;
            name_ = name;
		}
	}
}
