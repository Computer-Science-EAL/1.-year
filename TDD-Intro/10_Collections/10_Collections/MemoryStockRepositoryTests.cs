using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using System.Collections.Generic;

namespace _10_Collections
{
    //THESE ARE THE SECOND TESTS YOU SHOULD DO

    //When we don't have a database, we can use an in-memory repository instead to load and save data.
    //The repository will later serve as a medium between our program and the database. This is called the repository pattern.
    //The tests automatically force you to create an interface which can be used in the next assignment


    [TestClass]
    public class MemoryStockRepositoryTests
    {

        Stock hp = new Stock("HP", 11.4, 10);
        Stock yhoo = new Stock("YHOO", 57.2, 30);

        [TestMethod]
        public void GetAndSetStockId()
        {
            Assert.AreEqual(0, hp.Id);
            hp.Id = 123;
            Assert.AreEqual(123, hp.Id);
        }

        [TestMethod]
        public void FindNextId()
        {
            IStockRepository repository = new MemoryStockRepository();
            long id1 = repository.NextId();
            Assert.IsTrue(id1 != 0);
            long id2 = repository.NextId();
            Assert.IsTrue(id2 != 0);
            Assert.IsTrue(id2 != id1);
        }

        [TestMethod]
        public void CanSaveAndLoad()
        {
            IStockRepository repository = new MemoryStockRepository();
            repository.SaveStock(yhoo);
            long id = yhoo.Id;
            Stock loaded = repository.LoadStock(id);
            Assert.AreEqual(yhoo, loaded);
        }

        [TestMethod]
        public void CanSaveAfterChangeWithoutError()
        {
            IStockRepository repository = new MemoryStockRepository();
            repository.SaveStock(yhoo);
            yhoo.NumShares = 120;
            repository.SaveStock(yhoo);
            Stock loaded = repository.LoadStock(yhoo.Id);
            Assert.AreEqual(120, loaded.NumShares);
        }

        [TestMethod]
        public void CanFindAllStocks()
        {
            IStockRepository repository = new MemoryStockRepository();
            ICollection stocks;
            stocks = repository.FindAllStocks();
            Assert.AreEqual(0, stocks.Count);

            repository.SaveStock(yhoo);
            stocks = repository.FindAllStocks();
            Assert.AreEqual(1, stocks.Count);

            repository.SaveStock(hp);
            stocks = repository.FindAllStocks();
            Assert.AreEqual(2, stocks.Count);
        }

        [TestMethod]
        public void CanClearRepository()
        {
            IStockRepository repository = new MemoryStockRepository();
            repository.SaveStock(yhoo);
            repository.SaveStock(hp);
            repository.Clear();
            ICollection stocks;
            stocks = repository.FindAllStocks();
            Assert.AreEqual(0, stocks.Count);
        }

        
    }
}
