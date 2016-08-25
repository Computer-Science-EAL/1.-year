using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _06_Book_Titles
{
    [TestClass]
    public class BookTitleTests
    {
        private Book book;

        [TestInitialize]
        public void SetupForTest()
        {
            book = new Book();
        }

        [TestMethod]
        public void ShouldCapitalizeFirstLetter()
        {
            book.Title = "infernal";
            Assert.AreEqual("Infernal", book.Title);
        }

        [TestMethod]
        public void ShouldCapitalizeEveryWord()
        {
            book.Title = "stuart little";
            Assert.AreEqual("Stuart Little", book.Title);
        }

        [TestMethod]
        public void ShouldCapitalizeEveryWordExceptThe()
        {
            book.Title = "alexander the great";
            Assert.AreEqual("Alexander the Great", book.Title);
        }
        [TestMethod]
        public void ShouldCapitalizeEveryWordExceptA()
        {
            book.Title = "to kill a mockingbird";
            Assert.AreEqual("To Kill a Mockingbird", book.Title);
        }
        [TestMethod]
        public void ShouldCapitalizeEveryWordExceptAn()
        {
            book.Title = "to eat an apple a day";
            Assert.AreEqual("To Eat an Apple a Day", book.Title);
        }
        [TestMethod]
        public void ShouldCapitalizeEveryWordExceptConjunctions()
        {
            book.Title = "war and peace";
            Assert.AreEqual("War and Peace", book.Title);
        }
        [TestMethod]
        public void ShouldCapitalizeEveryWordExceptPrepositions()
        {
            book.Title = "love in the time of cholera";
            Assert.AreEqual("Love in the Time of Cholera", book.Title);
        }
        [TestMethod]
        public void ShouldAlwaysCapitalizeI()
        {
            book.Title = "what i wish i knew when i was 20";
            Assert.AreEqual("What I Wish I Knew When I Was 20", book.Title);
        }
        [TestMethod]
        public void ShouldAlwaysCapitalizeTheFirstWord()
        {
            book.Title = "the man in the iron mask";
            Assert.AreEqual("The Man in the Iron Mask", book.Title);
        }
    }

}

