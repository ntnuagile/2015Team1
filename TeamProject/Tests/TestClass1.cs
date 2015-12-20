using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject.Tests
{
    [TestFixture]
    public class TestClass1
    {
        [Test]
        public void Test1()
        {
            Assert.That(1 + 1, Is.EqualTo(2));
        }

		[Test]
		public void AddBook()
		{
			Library Lib = new Library();
			Book book1 = new Book();
			String [] data = {"1", "This is a Book", "Author", "Google", "Gong Guang Library"};

			book1.SetBookData(data, 200);

			Lib.AddBook(book1);

			Assert.That(Lib.books[0].GetISBN(), Is.EqualTo("1"));
		}

		[Test]
		public void AddBooks()
		{
			Library lib = new Library();
			Book book1 = new Book();
			String[] data1 = { "1", "This is a Book", "Author", "Google", "Gong Guang Library" };
			book1.SetBookData(data1, 200);
			lib.AddBook(book1);
			Book book2 = new Book();
			String[] data2 = { "2", "Computer Science", "Author", "Pearson", "Gong Guang Library" };
			book2.SetBookData(data2, 1000);
			lib.AddBook(book2);
			
			Assert.That(lib.books[1].GetISBN(), Is.EqualTo("2"));
			Assert.That(lib.books[1].GetLocation(), Is.EqualTo("Gong Guang Library"));
			Assert.That(lib.books[1].GetTitle(), Is.EqualTo("Computer Science"));
		}
        
		[Test]
		public void EditBook()
		{

		}

		[Test]
		public void DeleteBook()
		{ 
			
		}





		/////////////////////////////////////////////////
		
        [Test]
		public void Borrow3()
		{
			Library lib = new Library();

			Book book3 = new Book();
			String[] data3 = { "1515151515", "Knicks", "Author", "Carmelo Anthony", "New York" };
			book3.SetBookData(data3, 2015);
			lib.AddBook(book3);

			String name = "Jeremy";
			lib.BorrowBook("1515151515", name);
			Assert.That(lib.books[0].GetBorrowPerson(), Is.EqualTo("Jeremy"));
			Assert.That(lib.books[0].GetISBN(), Is.EqualTo("1515151515"));
		}
        
		[Test]
		public void RyanWeng()
		{
			Assert.That(40247037,Is.EqualTo(40247037));
		}
    }
}
