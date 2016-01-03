using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamProject.Tests
{
	[TestFixture]
	public class TestLibAndBook
	{
		[Test]
		public void AddBook()
		{
			Library lib = new Library();
			Book book1 = new Book();
			book1.SetBookData(new string[] { "1", "This is a Book", "Author", "Google", "Gong Guang Library" }, 200);

			Assert.That(lib.AddBook(book1), Is.EqualTo(true));
			Assert.That(lib.books[0].GetISBN(), Is.EqualTo("1"));
			Assert.That(lib.books[0].GetLocation(), Is.EqualTo("Gong Guang Library"));
			Assert.That(lib.books[0].GetTitle(), Is.EqualTo("This is a Book"));
			Assert.That(lib.books[0].GetID(), Is.EqualTo(1));
		}

		[Test]
		public void AddBooks()
		{
			Library lib = new Library();
			Book book1 = new Book();
			Book book2 = new Book();
			book1.SetBookData(new string[] { "1", "This is a Book", "Author", "Google", "Gong Guang Library" }, 200);
			book2.SetBookData(new string[] { "2", "Computer Science", "Author", "Pearson", "Gong Guang Library" }, 1000);

			Assert.That(lib.AddBook(book1), Is.EqualTo(true));
			Assert.That(lib.AddBook(book2), Is.EqualTo(true));

			Assert.That(lib.books[0].GetISBN(), Is.EqualTo("1"));
			Assert.That(lib.books[0].GetLocation(), Is.EqualTo("Gong Guang Library"));
			Assert.That(lib.books[0].GetTitle(), Is.EqualTo("This is a Book"));
			Assert.That(lib.books[0].GetID(), Is.EqualTo(1));

			Assert.That(lib.books[1].GetISBN(), Is.EqualTo("2"));
			Assert.That(lib.books[1].GetLocation(), Is.EqualTo("Gong Guang Library"));
			Assert.That(lib.books[1].GetTitle(), Is.EqualTo("Computer Science"));
			Assert.That(lib.books[1].GetID(), Is.EqualTo(2));
		}

		[Test]
		public void AddBookOverMax()
		{
			Library Lib = new Library();
			for (int i = 0; i < 10000; ++i)
			{
				Book book = new Book ();
				book.SetBookData (new string[] { "1", "This is a Book", "Author", "Google", "Gong Guang Library" }, 200);
				Assert.That(Lib.AddBook(book), Is.EqualTo(true));
			}

			Book over = new Book ();
			over.SetBookData (new string[] { "1", "This is a Book", "Author", "Google", "Gong Guang Library" }, 200);
			Assert.That(Lib.AddBook(over), Is.EqualTo(false));
		}

		[Test]
		public void DeleteBook()
		{
			Library lib = new Library();
			Book book1 = new Book();
			book1.SetBookData(new string[] { "1", "This is a Book", "Author", "Google", "Gong Guang Library" }, 200);

			lib.AddBook(book1);

			Assert.That(lib.books[0].GetISBN(), Is.EqualTo("1"));
			Assert.That(lib.books[0].GetTitle(), Is.EqualTo("This is a Book"));
			Assert.That(lib.books[0].GetAuthor(), Is.EqualTo("Author"));
			Assert.That(lib.books[0].GetSeller(), Is.EqualTo("Google"));
			Assert.That(lib.books[0].GetLocation(), Is.EqualTo("Gong Guang Library"));
			Assert.That(lib.books[0].GetPrice(), Is.EqualTo(200));

			Assert.That(lib.DeleteBook("1"), Is.EqualTo(true));

			Assert.That(lib.books[0].GetISBN(), Is.EqualTo(""));
			Assert.That(lib.books[0].GetTitle(), Is.EqualTo(""));
			Assert.That(lib.books[0].GetAuthor(), Is.EqualTo(""));
			Assert.That(lib.books[0].GetSeller(), Is.EqualTo(""));
			Assert.That(lib.books[0].GetLocation(), Is.EqualTo(""));
			Assert.That(lib.books[0].GetPrice(), Is.EqualTo(0));
		}

		[Test]
		public void DeleteBookFail()
		{
			Library lib = new Library();
			Assert.That(lib.DeleteBook("1"), Is.EqualTo(false));
		}

		[Test]
		public void FindBookbyID()
		{
			Library Lib = new Library();
			Book book1 = new Book();
			book1.SetBookData(new string[] { "1", "This is a Book", "Author", "Google", "Gong Guang Library" }, 200);

			Lib.AddBook(book1);

			Assert.That(Lib.FindBookIndexbyID(1), Is.EqualTo(0));
		}

		[Test]
		public void FindBookByIndex()
		{
			Library Lib = new Library();
			Book book1 = new Book();
			book1.SetBookData(new string[] { "122211111", "This is a Book", "Author", "Google", "Gong Guang Library" }, 200);

			Lib.AddBook(book1);

			Assert.That(Lib.FindBookIndex("122211111"), Is.EqualTo(0));
		}

		[Test]
		public void NotFoundBookbyID()
		{
			Library Lib = new Library();
			Book book1 = new Book();
			book1.SetBookData(new string[] { "1", "This is a Book", "Author", "Google", "Gong Guang Library" }, 200);

			Lib.AddBook(book1);

			Assert.That(Lib.FindBookIndexbyID(2), Is.EqualTo(-1));
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

			Assert.That(Lib.EditBook (editBook, Lib.FindBookIndex ("1")), Is.EqualTo(true));

			Assert.That(Lib.books[0].GetISBN(), Is.EqualTo("1"));
			Assert.That(Lib.books[0].GetLocation(), Is.EqualTo("Gong Guang Library"));
			Assert.That(Lib.books[0].GetTitle(), Is.EqualTo("This is a edited Book"));
			Assert.That(Lib.books[0].GetLocation(), Is.EqualTo("Gong Guang Library"));
			Assert.That(Lib.books[0].GetAuthor(), Is.EqualTo("Jobs"));
			Assert.That(Lib.books[0].GetSeller(), Is.EqualTo("Apple"));
			Assert.That(Lib.books[0].GetPrice(), Is.EqualTo(400));
		}

		[Test]
		public void EditBookFail()
		{
			Library Lib = new Library();
			Book book1 = new Book();
			book1.SetBookData(new string[] { "1", "This is a Book", "Author", "Google", "Gong Guang Library" }, 200);
			Lib.AddBook(book1);

			Book editBook = new Book();
			editBook.SetBookData(new string[] { "1", "This is a edited Book", "Jobs", "Apple", "Gong Guang Library" }, 400);

			Assert.That(Lib.EditBook (editBook, Lib.FindBookIndex ("2")), Is.EqualTo(false));
		}

		[Test]
		public void EditBookbyTitle()
		{
			Library Lib = new Library();
			Book book1 = new Book();
			book1.SetBookData(new string[] { "1", "This is a Book", "Author", "Google", "Gong Guang Library" }, 200);
			Lib.AddBook(book1);

			Book editBook = new Book();
			editBook.SetBookData(new string[] { "1", "This is a edited Book", "Jobs", "Apple", "Gong Guang Library" }, 400);

			Assert.That(Lib.EditBookbyTitle(editBook, "This is a Book", 0), Is.EqualTo(true));

			Assert.That(Lib.books[0].GetISBN(), Is.EqualTo("1"));
			Assert.That(Lib.books[0].GetLocation(), Is.EqualTo("Gong Guang Library"));
			Assert.That(Lib.books[0].GetTitle(), Is.EqualTo("This is a edited Book"));
			Assert.That(Lib.books[0].GetLocation(), Is.EqualTo("Gong Guang Library"));
			Assert.That(Lib.books[0].GetAuthor(), Is.EqualTo("Jobs"));
			Assert.That(Lib.books[0].GetSeller(), Is.EqualTo("Apple"));
			Assert.That(Lib.books[0].GetPrice(), Is.EqualTo(400));
		}

		[Test]
		public void EditBookbyTitlefFail()
		{
			Library Lib = new Library();
			Book book1 = new Book();
			book1.SetBookData(new string[] { "1", "This is a Book", "Author", "Google", "Gong Guang Library" }, 200);
			Lib.AddBook(book1);

			Book editBook = new Book();
			editBook.SetBookData(new string[] { "1", "This is a edited Book", "Jobs", "Apple", "Gong Guang Library" }, 400);

			Assert.That(Lib.EditBookbyTitle(editBook, "This is a Book", 1), Is.EqualTo(false));

			Assert.That(Lib.books[0].GetISBN(), Is.EqualTo("1"));
			Assert.That(Lib.books[0].GetLocation(), Is.EqualTo("Gong Guang Library"));
			Assert.That(Lib.books[0].GetTitle(), Is.EqualTo("This is a Book"));
			Assert.That(Lib.books[0].GetLocation(), Is.EqualTo("Gong Guang Library"));
			Assert.That(Lib.books[0].GetAuthor(), Is.EqualTo("Author"));
			Assert.That(Lib.books[0].GetSeller(), Is.EqualTo("Google"));
			Assert.That(Lib.books[0].GetPrice(), Is.EqualTo(200));
		}

		[Test]
		public void SearchTitle()
		{
			Library Lib = new Library();
			Book book1 = new Book();
			Book book2 = new Book();
			Book book3 = new Book();
			Book book4 = new Book();

			book1.SetBookData(new string[] { "1", "This is a Book", "Author", "Google", "Gong Guang Library" }, 200);
			book2.SetBookData(new string[] { "1", "Should not find this", "Author", "Google", "Gong Guang Library" }, 200);
			book3.SetBookData(new string[] { "1", "Not a book", "Author", "Google", "Gong Guang Library" }, 200);
			book4.SetBookData(new string[] { "1", "This is a Book", "Author", "Google", "Gong Guang Library" }, 200);

			Lib.AddBook(book1);
			Lib.AddBook(book2);
			Lib.AddBook(book3);
			Lib.AddBook(book4);

			Assert.That(Lib.SearchTitle("This is a Book")[0], Is.EqualTo(1));
			Assert.That(Lib.SearchTitle("This is a Book")[1], Is.EqualTo(4));
		}

		[Test]
		public void SearchBookTitle()
		{
			Library lib = new Library();
			Book book1 = new Book();
			Book book2 = new Book();
			book1.SetBookData(new string[] { "2", "Computer Science", "Author", "Pearson", "Gong Guang Library" }, 1000);
			book2.SetBookData(new string[] { "222", "What do you mean", "Justin Bieber", "Kkbox", "Gong Guan Library" }, 236);

			lib.AddBook(book1);
			lib.AddBook(book2);

			Assert.That(lib.SearchBookTitle("What do you mean")[0], Is.EqualTo(book2));
		}

		[Test]
		public void SearchBookAuthor()
		{
			Library lib = new Library();

			Book book1 = new Book();
			Book book2 = new Book();
			Book book3 = new Book();

			book1.SetBookData(new string[] { "1", "Learning Japanese", "Candy", "Youtube", "Gong Guan Library" }, 520);
			book2.SetBookData(new string[] { "2", "Computer Science", "Ken", "Pearson", "Gong Guan Library" }, 448);
			book3.SetBookData(new string[] { "3", "Something Incredible", "Candy", "Happy", "Gong Guan Library" }, 361);

			lib.AddBook(book1);
			lib.AddBook(book2);
			lib.AddBook(book3);

			Book[] books = new Book[2];
			books[0] = book1;
			books[1] = book3;

			Assert.That(lib.SearchBookAuthor("Candy")[0], Is.EqualTo(books[0]));
			Assert.That(lib.SearchBookAuthor("Candy")[1], Is.EqualTo(books[1]));
		}
	}

	[TestFixture]
	public class TestMemberaAndMemberBase
	{
		[Test]
		public void AddUser()
		{
			MemberBase mb = new MemberBase();

			// Regular User
			Member m = new Member();
			DateTime regtime = DateTime.Now;

			m.SetName("test");
			m.SetPassword("123");
			m.SetDate(regtime);
			m.SetIsAdministrator(false);
			m.SetEmail("test@test.com");

			Assert.That(mb.AddMember(m), Is.EqualTo(true));
			Assert.That(mb.members[0].GetName(), Is.EqualTo("test"));
			Assert.That(mb.members[0].GetPassword(), Is.EqualTo("123"));
			Assert.That(mb.members[0].GetIsAdministrator(), Is.EqualTo(false));
			Assert.That(mb.members[0].GetEmail(), Is.EqualTo("test@test.com"));
			Assert.That(mb.members[0].GetRegtime(), Is.EqualTo(regtime));

			// Administrator
			Member n = new Member();
			n.SetName("root");
			n.SetPassword("RootIsGod");
			n.SetDate(regtime);
			n.SetIsAdministrator(true);
			n.SetEmail("IamGod.com");

			Assert.That(mb.AddMember(n), Is.EqualTo(true));
			Assert.That(mb.members[1].GetName(), Is.EqualTo("root"));
			Assert.That(mb.members[1].GetPassword(), Is.EqualTo("RootIsGod"));
			Assert.That(mb.members[1].GetIsAdministrator(), Is.EqualTo(true));
			Assert.That(mb.members[1].GetEmail(), Is.EqualTo("IamGod.com"));
			Assert.That(mb.members[1].GetRegtime(), Is.EqualTo(regtime));
		}

		[Test]
		public void AddUserFail()
		{
			MemberBase mb = new MemberBase();
			Member m = new Member();
			Member n = new Member();	// the same name
			Member o = new Member();	// the same email
			m.SetName("test");
			n.SetName("test");
			m.SetEmail("test@test.com");
			o.SetEmail("test@test.com");

			Assert.That(mb.AddMember(m), Is.EqualTo(true));
			Assert.That(mb.AddMember(n), Is.EqualTo(false));
			Assert.That(mb.AddMember(o), Is.EqualTo(false));
			Assert.That(mb.members[1], Is.EqualTo(null));
		}

		[Test]
		public void EditMember()
		{
			MemberBase mb = new MemberBase();

			Member m = new Member();
			m.SetName("test");
			m.SetPassword("123");
			m.SetIsAdministrator(false);

			mb.AddMember(m);

			Assert.That(mb.EditMember(m, "yEEEE", "689689", "test.com"), Is.EqualTo(true));
			Assert.That(mb.members[0].GetName(), Is.EqualTo("yEEEE"));
			Assert.That(mb.members[0].GetPassword(), Is.EqualTo("689689"));
		}

		[Test]
		public void EditMemberFail()
		{
			MemberBase mb = new MemberBase();

			Member m = new Member();
			Member n = new Member();
			m.SetName("test");
			m.SetPassword("123");
			m.SetIsAdministrator(false);

			mb.AddMember(m);

			Assert.That(mb.EditMember(n, "yEEEE", "689689", "test.com"), Is.EqualTo(false));
		}
	}

	/* ===================================================================================== */

	[TestFixture]
	public class TestClass1
	{
		[Test]
		public void BorrowBook()
		{
			Library lib = new Library();
			Book book3 = new Book();
			book3.SetBookData(new string[] { "1515151515", "Knicks", "Author", "Carmelo Anthony", "New York" }, 2015);
			lib.AddBook(book3);

			Member Jeremy = new Member();
			Jeremy.SetName("Jeremy");
			lib.BorrowBook("1515151515", Jeremy);
			Assert.That(lib.books[0].GetBorrowPerson(), Is.EqualTo(Jeremy));
			Assert.That(lib.books[0].GetISBN(), Is.EqualTo("1515151515"));
		}

		[Test]
		public void TestBorrow()	// Success or not
		{
			Library lib = new Library();
			Book book = new Book();
			string book_id = "123";
			book.SetBookData(new string[] { book_id, "Computer Science", "CSIE", "NTNU", "Taiwan" }, 2015);
			lib.AddBook(book);

			MemberBase mb = new MemberBase();
			Member m = new Member();
			string name = "Jerry";
			m.SetName(name);
			m.SetPassword("123");
			m.SetIsAdministrator(false);
			mb.AddMember(m);

			Assert.That(mb.SearchMember("Mark"), Is.EqualTo(false));
			Assert.That(mb.SearchMember(name), Is.EqualTo(true));

			Assert.That(lib.BorrowBook("456", m), Is.EqualTo("Book not found"));
			Assert.That(lib.BorrowBook(book_id, m), Is.EqualTo("Borrow Success"));
			Assert.That(lib.BorrowBook(book_id, m), Is.EqualTo("This book already be borrowed"));
		}

		[Test]
		public void ReserveBook()
		{
			Library lib = new Library();
			Book book1 = new Book();
			book1.SetBookData(new string[] { "1", "This is a Book", "Author", "Google", "Gong Guang Library" }, 200);

			Member Candy = new Member ();
			Candy.SetName("Candy");
			lib.AddBook(book1);
			lib.ReserveBook("1", Candy);

			Assert.That(lib.books[0].isReserved(), Is.EqualTo(false));
			// This book is not borrowed,so it cannot be reserved.
		}


		[Test]
		public void SearchReservation()
		{
			Library lib = new Library();
			Book book4 = new Book();
			book4.SetBookData(new string[] { "222", "What do you mean", "Justin Bieber", "Kkbox", "Gong Guan Library" }, 236);
			lib.AddBook(book4);

			Member Andy = new Member ();
			Andy.SetName ("Andy");
			Member Candy = new Member ();
			Candy.SetName ("Candy");
			lib.BorrowBook("222", Andy);
			lib.ReserveBook("222", Candy);
			Assert.That(lib.SearchReservation("222"), Is.EqualTo(true));
		}

		[Test]
		public void DeleteReservation()
		{
			Library lib = new Library();

			Book book3 = new Book();
			book3.SetBookData(new string[] { "1515151515", "Knicks", "Author", "Carmelo Anthony", "New York" }, 2015);
			lib.AddBook(book3);

			Member Mary = new Member();
			Mary.SetName("Mary");
			Member Candy = new Member();
			Candy.SetName("Candy");
			lib.BorrowBook("1515151515", Mary);
			lib.ReserveBook("1515151515", Candy);
			lib.CancelReservation("1515151515");

			Assert.That(lib.books[0].isReserved(), Is.EqualTo(false));
		}

        [Test]
        public void TestReturn()
        {
            Library lib = new Library();
            Book book = new Book();
			string book_id = "123";
            book.SetBookData(new string[] { book_id, "Computer Science", "CSIE", "NTNU", "Taiwan" }, 2015);
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

			book1.SetBookData(new string[] { "1", "This is a Book", "Author", "Google", "Gong Guang Library" }, 200);
			book2.SetBookData(new string[] { "2", "Computer Science", "Author", "Pearson", "Gong Guang Library" }, 1000);
			book3.SetBookData(new string[] { "3", "Computer Science2", "Author", "Pearson", "Gong Guang Library" }, 1000);

			lib.AddBook(book1);
			lib.AddBook(book2);
			lib.AddBook(book3);

			Book[] testborrowing = new Book[10];
			testborrowing[0] = book1;
			testborrowing[1] = book3;

			Member m = new Member();
			m.SetName("Mandy");
			m.SetPassword("123");
			m.SetIsAdministrator(false);

			Assert.That(lib.BorrowBook("1", m), Is.EqualTo("Borrow Success"));
			Assert.That(lib.BorrowBook("3", m), Is.EqualTo("Borrow Success"));

			Assert.That(lib.CheckBorrowing(m), Is.EqualTo(testborrowing));
		}

		[Test]
		public void ReadLaterTest()
		{
			Library lib2 = new Library();
			Book book01 = new Book();
			Book book02 = new Book();
			Book book03 = new Book();

			book01.SetBookData(new string[] { "1", "This is a Book", "Author", "Google", "Gong Guang Library" }, 200);
			book02.SetBookData(new string[] { "2", "Computer Science", "Author", "Pearson", "Gong Guang Library" }, 1000);
			book03.SetBookData(new string[] { "3", "Computer Science2", "Author", "Pearson", "Gong Guang Library" }, 1000);

			lib2.AddBook(book01);
			lib2.AddBook(book02);
			lib2.AddBook(book03);
			Assert.That(lib2.CheckReadLater("1"), Is.EqualTo(false));
			Assert.That(lib2.CheckReadLater("2"), Is.EqualTo(false));
			Assert.That(lib2.CheckReadLater("3"), Is.EqualTo(false));

			book01.SetReadLater("Sally");
			book02.SetReadLater("Sally");
			Assert.That(lib2.CheckReadLater("1"), Is.EqualTo(true));
			Assert.That(lib2.CheckReadLater("2"), Is.EqualTo(true));
			Assert.That(lib2.CheckReadLater("3"), Is.EqualTo(false));
		}
		[Test]
		public void AddBorrowTime()
		{
			Library lib = new Library();

			Book book1 = new Book();
			Book book2 = new Book();
			Book book3 = new Book();

			book1.SetBookData(new string[] { "1", "Happy New Year", "Taipei", "Mayor Ko", "Gong Guan Library" }, 344);
			book2.SetBookData(new string[] { "2", "Merry X'mas", "Taichung", "Mayor Lin", "Gong Guan Library" }, 487);
			book3.SetBookData(new string[] { "3", "Happy Mother's Day", "Tainan", "Mayor Lai", "Gong Guan Library" }, 664);

			lib.AddBook(book1);
			lib.AddBook(book2);
			lib.AddBook(book3);

			Member Judy = new Member();
			Judy.SetName ("Judy");
			Member John = new Member();
			John.SetName ("John");
			lib.BorrowBook("1", Judy);
			lib.BorrowBook("2", John);

			lib.ReturnBook("1");
			lib.BorrowBook("1", John);

			Assert.That(lib.books[0].GetBorrowTime(), Is.EqualTo(2));
			Assert.That(lib.books[2].GetBorrowTime(), Is.EqualTo(0));
		}

		[Test]
		public void RecommendBook()
		{
			Library lib = new Library();

			Book book1 = new Book();
			Book book2 = new Book();
			Book book3 = new Book();

			book1.SetBookData(new string[] { "1", "Happy New Year", "Taipei", "Mayor Ko", "Gong Guan Library" }, 344);
			book2.SetBookData(new string[] { "2", "Merry X'mas", "Taichung", "Mayor Lin", "Gong Guan Library" }, 487);
			book3.SetBookData(new string[] { "3", "Happy Mother's Day", "Tainan", "Mayor Lai", "Gong Guan Library" }, 664);

			lib.AddBook(book1);
			lib.AddBook(book2);
			lib.AddBook(book3);

			Member Rita = new Member();
			Member Jason = new Member();
			Member Zack = new Member();
			Member Wendy = new Member();
			Rita.SetName("Rita");
			Jason.SetName("Jason");
			Zack.SetName("Zack");
			Wendy.SetName("Wendy");

			lib.BorrowBook("1", Rita);
			lib.ReturnBook("1");
			lib.BorrowBook("1", Jason);
			lib.ReturnBook("1");
			lib.BorrowBook("2", Zack);
			lib.ReturnBook("2");
			lib.BorrowBook("1", Wendy);
			lib.ReturnBook("1");

			Assert.That(lib.Recommend(), Is.EqualTo(lib.books[0]));

		}

		[Test]
		public void ReturnNotRecommended()
		{
			Library lib = new Library();

			Book book1 = new Book();
			Book book2 = new Book();
			Book book3 = new Book();

			book1.SetBookData(new string[] { "1", "Happy New Year", "Taipei", "Mayor Ko", "Gong Guan Library" }, 344);
			book2.SetBookData(new string[] { "2", "Merry X'mas", "Taichung", "Mayor Lin", "Gong Guan Library" }, 487);
			book3.SetBookData(new string[] { "3", "Happy Mother's Day", "Tainan", "Mayor Lai", "Gong Guan Library" }, 664);

			lib.AddBook(book1);
			lib.AddBook(book2);
			lib.AddBook(book3);

			Member Rita = new Member();
			Member Jason = new Member();
			Member Zack = new Member();
			Member Wendy = new Member();
			Rita.SetName("Rita");
			Jason.SetName("Jason");
			Zack.SetName("Zack");
			Wendy.SetName("Wendy");

			lib.BorrowBook("1", Rita);
			lib.ReturnBook("1");
			lib.BorrowBook("1", Jason);
			lib.ReturnBook("1");
			lib.BorrowBook("2", Zack);
			lib.ReturnBook("2");
			lib.BorrowBook("1", Wendy);
			lib.ReturnBook("1");

			lib.Recommend();

			Assert.That(lib.Recommend(), Is.EqualTo(lib.books[1]));
		}

		[Test]
		public void TestSort()
		{
			Library lib2 = new Library();
			Book book01 = new Book();
			Book book02 = new Book();
			Book book03 = new Book();

			book01.SetBookData(new string[] { "1", "This is a Book", "Author", "Google", "Gong Guang Library" }, 200);
			book02.SetBookData(new string[] { "2", "Computer Science", "Author", "Pearson", "Gong Guang Library" }, 1000);
			book03.SetBookData(new string[] { "3", "Computer Science2", "Author", "Pearson", "Gong Guang Library" }, 1000);

			book01.SetTopic("Internet");
			book02.SetTopic("Computer");
			book03.SetTopic("Computer");

			lib2.AddBook(book01);
			lib2.AddBook(book02);
			lib2.AddBook(book03);

			Assert.That(book01.GetTopic(), Is.EqualTo("Internet"));
			Assert.That(book02.GetTopic(), Is.EqualTo("Computer"));
			Assert.That(book03.GetTopic(), Is.EqualTo("Computer"));
		}

		[Test]
		public void TestAddWaitToBuy()
		{
			Library lib = new Library();
			Assert.That(lib.AddWaitToBuy("Computer Science", "HAHA", "Google", "Jerry"), Is.EqualTo("Opinion Save"));
			Assert.That(lib.AddWaitToBuy ("Bad Apple", "YOYO", "Yahoo", "Jeremy"), Is.EqualTo ("Opinion Save"));
		}
	}
}
