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
		public void Add1Book()
		{
			Library Lib = new Library();
			Book book1 = new Book();
			book1.ISBN = "1";
			book1.title = "This is a Book";
			book1.price = 200;
			book1.location = "Gong Guang Library";
			book1.seller = "Google";

			Lib.AddBook(book1);

			Assert.That(Lib.books[0].ISBN, Is.EqualTo("1"));
		}

		[Test]
		public void Add2Books()
		{
			Library lib = new Library();
			Book book1 = new Book();
			book1.ISBN = "1";
			book1.title = "This is a Book";
			book1.price = 200;
			book1.location = "Gong Guang Library";
			book1.seller = "Google";
			lib.AddBook(book1);
			Book book2 = new Book();
			book2.ISBN = "2";
			book2.title = "Computer Science";
			book2.price = 1000;
			book2.location = "Gong Guang Library";
			book2.seller = "Pearson";
			book2.status = 1;

			lib.AddBook(book2);
			
			Assert.That(lib.books[1].ISBN, Is.EqualTo("2"));
			Assert.That(lib.books[1].location, Is.EqualTo("Gong Guang Library"));
			Assert.That(lib.books[1].title, Is.EqualTo("Computer Science"));
		}
        
		[Test]
		public void Borrow3()
		{
			Library lib = new Library();
			Book book3 = new Book();
			book3.ISBN = "0262033844";
			book3.title = "Introduction to algorithm";
			book3.price = 1107;
			book3.location = "LinCo Library";
			book3.seller = "Simpson";
			book3.status = 1;

			lib.AddBook(book3);
			String name = "Wildsky";
			lib.BorrowBook("0262033844", name);
			Assert.That(lib.books[0].borrow_person, Is.EqualTo("Wildsky"));
			Assert.That(lib.books[0].ISBN, Is.EqualTo("0262033844"));
		}

        [Test]
		public void Borrow4()
		{
			Library lib = new Library();

			Book book4 = new Book();

			lib.AddBook(book4);

			book4.ISBN = "1515151515";
			book4.title = "Knicks";
			book4.price = 2015;
			book4.location = "New York";
			book4.seller = "Carmelo Anthony";
			book4.status = 1;

			String name = "Jeremy";
			lib.BorrowBook("1515151515", name);
			Assert.That(lib.books[0].borrow_person, Is.EqualTo("Jeremy"));
			Assert.That(lib.books[0].ISBN, Is.EqualTo("1515151515"));
		}
        
		[Test]
		public void RyanWeng()
		{
			Assert.That(40247037,Is.EqualTo(40247037));
		}
    }
}
