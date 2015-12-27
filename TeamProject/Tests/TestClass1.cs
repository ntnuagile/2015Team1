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
		public void AddBook()
		{
			Library Lib = new Library();
			Book book1 = new Book();
			book1.SetBookData(new string[] { "1", "This is a Book", "Author", "Google", "Gong Guang Library" }, 200);

			Lib.AddBook(book1);

			Assert.That(Lib.books[0].GetISBN(), Is.EqualTo("1"));
		}

		[Test]
		public void AddBooks()
		{
			Library lib = new Library();
			Book book1 = new Book();
			Book book2 = new Book();
			book1.SetBookData(new String[] { "1", "This is a Book", "Author", "Google", "Gong Guang Library" }, 200);
			book2.SetBookData(new String[] { "2", "Computer Science", "Author", "Pearson", "Gong Guang Library" }, 1000);

			lib.AddBook(book1);
			lib.AddBook(book2);

			Assert.That(lib.books[0].GetISBN(), Is.EqualTo("1"));
			Assert.That(lib.books[0].GetLocation(), Is.EqualTo("Gong Guang Library"));
			Assert.That(lib.books[0].GetTitle(), Is.EqualTo("This is a Book"));
			Assert.That(lib.books[1].GetISBN(), Is.EqualTo("2"));
			Assert.That(lib.books[1].GetLocation(), Is.EqualTo("Gong Guang Library"));
			Assert.That(lib.books[1].GetTitle(), Is.EqualTo("Computer Science"));
		}

		[Test]
		public void EditBook()
		{
			Library Lib = new Library();
			Book book1 = new Book();
			book1.SetBookData(new string[] { "1", "This is a Book", "Author", "Google", "Gong Guang Library" }, 200);
			Lib.AddBook(book1);

			Book editBook = new Book();
			editBook.SetBookData(new string[] { "1", "This is a edited Book", "Jobs", "Apple", "Gong Guang Library" }, 400);
			if (Lib.EditBook(editBook, Lib.FindBookIndex("1")) == false)
				throw new Exception();



			Assert.That(Lib.books[0].GetISBN(), Is.EqualTo("1"));
			Assert.That(Lib.books[0].GetLocation(), Is.EqualTo("Gong Guang Library"));
			Assert.That(Lib.books[0].GetTitle(), Is.EqualTo("This is a edited Book"));
			Assert.That(Lib.books[0].GetLocation(), Is.EqualTo("Gong Guang Library"));
			Assert.That(Lib.books[0].GetAuthor(), Is.EqualTo("Jobs"));
			Assert.That(Lib.books[0].GetSeller(), Is.EqualTo("Apple"));
			Assert.That(Lib.books[0].GetPrice(), Is.EqualTo(400));
		}

		[Test]
		public void DeleteBook()
		{
			Library lib = new Library();
			Book book1 = new Book();
			book1.SetBookData(new String[] { "1", "This is a Book", "Author", "Google", "Gong Guang Library" }, 200);

			lib.AddBook(book1);
			lib.DeleteBook("1");

			Assert.That(lib.books[0].GetISBN(), Is.EqualTo(""));
			Assert.That(lib.books[0].GetTitle(), Is.EqualTo(""));
			Assert.That(lib.books[0].GetAuthor(), Is.EqualTo(""));
			Assert.That(lib.books[0].GetSeller(), Is.EqualTo(""));
			Assert.That(lib.books[0].GetLocation(), Is.EqualTo(""));
			Assert.That(lib.books[0].GetPrice(), Is.EqualTo(0));
		}


		[Test]
		public void SearchBook()
		{
			Library lib = new Library();
			Book book4 = new Book();
			Book book2 = new Book();
			book4.SetBookData(new String[] { "222", "What do you mean", "Justin Bieber", "Kkbox", "Gong Guan Library" }, 236);
			book2.SetBookData(new String[] { "2", "Computer Science", "Author", "Pearson", "Gong Guang Library" }, 1000);
			lib.AddBook(book2);
			lib.AddBook(book4);


			Assert.That(lib.SearchBookTitle("What do you mean")[0], Is.EqualTo(lib.books[1]));
		}

		[Test]
		public void Borrow3()
		{
			Library lib = new Library();

			Book book3 = new Book();
			book3.SetBookData(new String[] { "1515151515", "Knicks", "Author", "Carmelo Anthony", "New York" }, 2015);
			lib.AddBook(book3);

			String name = "Jeremy";
			lib.BorrowBook("1515151515", name);
			Assert.That(lib.books[0].GetBorrowPerson(), Is.EqualTo("Jeremy"));
			Assert.That(lib.books[0].GetISBN(), Is.EqualTo("1515151515"));
		}

		[Test]
		public void AddUser()
		{
			MemberBase mb = new MemberBase();

			Member m = new Member();
			m.SetName("test");
			m.SetPassword("123");
            m.SetIsAdministrator(false);

			mb.AddMember(m);
			Assert.That(mb.members[0].GetName(), Is.EqualTo("test"));
			Assert.That(mb.members[0].GetPassword(), Is.EqualTo("123"));
			Assert.That(mb.members[0].GetIsAdministrator(), Is.EqualTo(false));
			//Assert.That(mb.members[0].GetInviter(), Is.EqualTo("self"));
			//Assert.That(mb.members[0].GetRegtime(), Is.EqualTo(DateTime.Now));

		}
        [Test]
        public void EditUser()
        {
            MemberBase mb = new MemberBase();

            Member m = new Member();
            m.SetName("test");
            m.SetPassword("123");
            m.SetIsAdministrator(false);

            mb.AddMember(m);

            mb.EditMember(m, "yEEEE", "689689", DateTime.Now);
            Assert.That(mb.members[0].GetName(), Is.EqualTo("yEEEE"));
            Assert.That(mb.members[0].GetPassword(), Is.EqualTo("689689"));
        }

        [Test]
        public void AddAdministrator()
        {
            MemberBase mb = new MemberBase();

            Member m = new Member();
            m.SetName("test");
            m.SetPassword("123");
            m.SetIsAdministrator(true);

            mb.AddMember(m);
            Assert.That(mb.members[0].GetName(), Is.EqualTo("test"));
            Assert.That(mb.members[0].GetPassword(), Is.EqualTo("123"));
            Assert.That(mb.members[0].GetIsAdministrator(), Is.EqualTo(true));
            //Assert.That(mb.members[0].GetInviter(), Is.EqualTo("self"));
            //Assert.That(mb.members[0].GetRegtime(), Is.EqualTo(DateTime.Now));

        }



		[Test]
		public void ReserveBook()
		{
			Library lib = new Library();
			Book book1 = new Book();
			book1.SetBookData(new String[] { "1", "This is a Book", "Author", "Google", "Gong Guang Library" }, 200);

			lib.AddBook(book1);
			lib.ReserveBook("1", "Candy");

			Assert.That(lib.books[0].isReserved(), Is.EqualTo(false));
			// This book is not borrowed,so it cannot be reserved.
		}


		[Test]
		public void SearchReservation()
		{
			Library lib = new Library();
			Book book4 = new Book();
			book4.SetBookData(new String[] { "222", "What do you mean", "Justin Bieber", "Kkbox", "Gong Guan Library" }, 236);
			lib.AddBook(book4);

			string name = "Andy";
			lib.BorrowBook("222", name);
			lib.ReserveBook("222", "Candy");
			Assert.That(lib.SearchReservation("222"), Is.EqualTo(true));
		}

		[Test]
		public void DeleteReservation()
		{
			Library lib = new Library();

			Book book3 = new Book();
			book3.SetBookData(new String[] { "1515151515", "Knicks", "Author", "Carmelo Anthony", "New York" }, 2015);
			lib.AddBook(book3);

			string name = "Mary";
			lib.BorrowBook("1515151515", name);
			lib.ReserveBook("1515151515", "Candy");
			lib.CancelReservation("1515151515");

			Assert.That(lib.books[0].isReserved(), Is.EqualTo(false));
		}

        [Test]
        public void TestBorrow()	// Success or not
        {
            Library lib = new Library();
            Book book = new Book();
            String book_id = "123";
            book.SetBookData(new String[] { book_id, "Computer Science", "CSIE", "NTNU", "Taiwan" }, 2015);
            lib.AddBook(book);

            MemberBase mb = new MemberBase();
            Member m = new Member();
            String name = "Jerry";
            m.SetName(name);
            m.SetPassword("123");
            m.SetIsAdministrator(false);
            mb.AddMember(m);

            Assert.That(mb.SearchMember("Mark"), Is.EqualTo(false));
            Assert.That(mb.SearchMember(name), Is.EqualTo(true));

			Assert.That(lib.BorrowBook("456", name), Is.EqualTo("Book not found"));
			Assert.That(lib.BorrowBook(book_id, name), Is.EqualTo("Borrow Success"));
			Assert.That(lib.BorrowBook(book_id, name), Is.EqualTo("This book already be borrowed"));
        }

        [Test]
        public void TestReturn()
        {
            Library lib = new Library();
            Book book = new Book();
            String book_id = "123";
            book.SetBookData(new String[] { book_id, "Computer Science", "CSIE", "NTNU", "Taiwan" }, 2015);
            lib.AddBook(book);
            book.SetAvailible(false);
            Assert.That(lib.ReturnBook("456"), Is.EqualTo("Book not found"));
            Assert.That(lib.ReturnBook(book_id), Is.EqualTo("Return Success"));
            Assert.That(lib.ReturnBook(book_id), Is.EqualTo("This book already be returned"));
        }


		[Test]
		public void CheckBorrowing()
		{
			Library lib = new Library();
			Book book1 = new Book();
			Book book2 = new Book();
			Book book3 = new Book();

			book1.SetBookData(new String[] { "1", "This is a Book", "Author", "Google", "Gong Guang Library" }, 200);
			book2.SetBookData(new String[] { "2", "Computer Science", "Author", "Pearson", "Gong Guang Library" }, 1000);
			book3.SetBookData(new String[] { "3", "Computer Science2", "Author", "Pearson", "Gong Guang Library" }, 1000);

			lib.AddBook(book1);
			lib.AddBook(book2);
			lib.AddBook(book3);

			Book[] testborrowing = new Book[10];
			testborrowing[0] = book1;
			testborrowing[1] = book3;

			String name = "Mandy";

			Assert.That(lib.BorrowBook("1", name), Is.EqualTo("Borrow Success"));
			Assert.That(lib.BorrowBook("3", name), Is.EqualTo("Borrow Success"));

			Assert.That(lib.CheckBorrowing(name), Is.EqualTo(testborrowing));

		}

        [Test]
        public void AddUserAgain()
        {
            MemberBase mb = new MemberBase();

            Member m = new Member();
            m.SetName("test");
            m.SetPassword("123");
            m.SetIsAdministrator(false);

            Member n = new Member();
            m.SetName("test");
            m.SetPassword("321");
            m.SetIsAdministrator(false);

            mb.AddMember(m);
            mb.AddMember(n);
            Assert.That(mb.members[0].GetName(), Is.EqualTo("test"));
            Assert.That(mb.members[1].GetName(), Is.EqualTo(null));
        }
	}
}
