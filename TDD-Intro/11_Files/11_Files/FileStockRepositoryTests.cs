using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Collections;

namespace _11_Files
{
    [TestClass]
    public class FileStockRepositoryTests
    {
        Stock hp = new Stock("HP", 11.4, 10);
        Stock yhoo = new Stock("YHOO", 57.2, 30);
        DirectoryInfo repositoryDir = new DirectoryInfo("mydata\\");

        [TestMethod]
        public void CanGetAndSetStockId()
        {
            Assert.AreEqual(0, hp.Id);
            hp.Id = 123;
            Assert.AreEqual(123, hp.Id);
        }

        [TestMethod]
        public void FindNextId()
        {
            IStockRepository repository = new FileStockRepository(repositoryDir);
            long id1 = repository.NextId();
            Assert.IsTrue(id1 != 0);
            long id2 = repository.NextId();
            Assert.IsTrue(id2 != 0);
            Assert.IsTrue(id2 != id1);

        }

        [TestMethod]
        public void CreateRepository()
        {
            IStockRepository repository;
            repository = new FileStockRepository(repositoryDir);
            Assert.IsTrue(repositoryDir.Exists);
        }

        [TestMethod]
        public void FindStockFileName()
        {
            IFileRepository repository = new FileStockRepository(repositoryDir);
            Assert.AreEqual("stock123.txt", repository.StockFileName(123));
            hp.Id = 456;
            Assert.AreEqual("stock456.txt", repository.StockFileName(hp));
        }

        [TestMethod]
        public void CanSaveStockWritesToFile()
        {
            IFileRepository repository = new FileStockRepository(repositoryDir);
            repository.SaveStock(yhoo);
            Assert.IsFalse(yhoo.Id == 0);
            FileInfo fileYhoo = new FileInfo(repositoryDir + repository.StockFileName(yhoo));
            Assert.IsTrue(fileYhoo.Exists);
        }

        [TestMethod]
        public void CanSaveAndLoad()
        {
            IStockRepository repository = new FileStockRepository(repositoryDir);
            repository.SaveStock(yhoo);
            long id = yhoo.Id;

            IStockRepository differentRepository = new FileStockRepository(repositoryDir);
            Stock newYhoo = differentRepository.LoadStock(id);

            Assert.AreEqual(yhoo, newYhoo);
        }

        [TestMethod]
        public void CanSaveAfterChange()
        {
            IStockRepository repository = new FileStockRepository(repositoryDir);
            repository.SaveStock(yhoo);
            yhoo.NumShares = 120;
            repository.SaveStock(yhoo);

            IStockRepository newRepository = new FileStockRepository(repositoryDir);
            Stock loaded = newRepository.LoadStock(yhoo.Id);
            Assert.AreEqual(120, loaded.NumShares);
        }

        [TestMethod]
        public void CanClearRepository()
        {
            IStockRepository repository = new FileStockRepository(repositoryDir);
            repository.SaveStock(yhoo);
            repository.SaveStock(hp);
            repository.Clear();
            ICollection stocks;
            stocks = repository.FindAllStocks();
            Assert.AreEqual(0, stocks.Count);
        }
        [TestMethod]
        public void CanFindAllStocks()
        {
            IStockRepository repository = new FileStockRepository(repositoryDir);
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
    }
}
