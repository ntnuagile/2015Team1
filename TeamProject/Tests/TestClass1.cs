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
		public void Borrow1()
		{
			Book book1 = new Book();
			book1.ISBN = 1;
			book1.title = "This is a Book";
			book1.price = 200;
			book1.location = "Gong Guang Liarary";
			book1.seller = "Google";
			book1.status = 1;

			Borrow b = new Borrow();
			String name = "Mandy";
			b.BorrowBook(book1, name);
			Assert.That(b.name, Is.EqualTo("Mandy"));
			Assert.That(b.id, Is.EqualTo(1));
		}
        [Test]
        public void Borrow2()
        {
            Book book2 = new Book();
            book2.ISBN = 1;
            book2.title = "Computer Science";
            book2.price = 1000;
            book2.location = "Gong Guang Liarary";
            book2.seller = "Pearson";
            book2.status = 1;

            Borrow b = new Borrow();
            String name = "Jerry";
            b.BorrowBook(book2, name);
            Assert.That(b.name, Is.EqualTo("Jerry"));
            Assert.That(b.id, Is.EqualTo(1));
        }
    }
}
