﻿using NUnit.Framework;
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
			book1.SetBookData(new string[] {"1", "This is a Book", "Author", "Google", "Gong Guang Library"}, 200);

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
        
		[Test, Ignore("Ignore EditBook test")]
		public void EditBook()
		{
			
		}

		[Test, Ignore("Ignore DeleteBook test")]
		public void DeleteBook()
		{ 
			
		}

		[Test]
		public void SearchBook()
		{
			Library lib = new Library();
			Book book4 = new Book();
			book4.SetBookData(new String[] { "222", "What do you mean", "Justin Bieber", "Kkbox", "Gong Guan Library" }, 236);

			lib.AddBook(book4);

			Assert.That(lib.SearchBookTitle("What do you mean")[0], Is.EqualTo(lib.books[0]));
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
    }
}
