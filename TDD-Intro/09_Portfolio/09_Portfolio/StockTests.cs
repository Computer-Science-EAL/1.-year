using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _09_Portfolio
{
    //Now things are getting trickier. Be sure to follow along in the index.html file, to see the purpose of the different tests
    //we will be creating here.

        //THESE ARE THE FIRST TESTS YOU SHOULD DO 

    [TestClass]
    public class StockTests
    {
        [TestMethod]
        public void CanSetAndGetSymbol()
        {
            Stock s = new Stock();
            s.Symbol = "MSFT";

            Console.Write("STOCK IS: ");
            Console.WriteLine(s);

            Assert.AreEqual("MSFT", s.Symbol);
        }

        [TestMethod]
        public void CanSetAndGetPrice()
        {
            Stock s = new Stock();
            s.Symbol = "MSFT";
            s.PricePerShare = 56.67;

            Assert.AreEqual(56.67, s.PricePerShare);
        }
        [TestMethod]
        public void CanSetAndGetNumShares()
        {
            Stock s = new Stock();
            s.Symbol = "MSFT";
            s.PricePerShare = 56.67;
            s.NumShares = 100;

            Assert.AreEqual(100, s.NumShares);
            Assert.AreEqual(5667, s.GetValue());
        }

        [TestMethod]
        public void CanUseMultiArgumentConstructor()
        {
            Stock stockYHOO = new Stock("YHOO", 43.33, 60);

            Assert.AreEqual("YHOO", stockYHOO.Symbol);
            Assert.AreEqual(43.33, stockYHOO.PricePerShare);
            Assert.AreEqual(60, stockYHOO.NumShares);
            Assert.AreEqual(43.33 * 60, stockYHOO.GetValue());
        }

        [TestMethod]
        public void CanCreateMultipleInstances()
        {
            Stock stockYHOO = new Stock("YHOO", 10, 100);
            Stock stockMSFT = new Stock("MSFT", 22, 300);
            Assert.AreEqual(1000, stockYHOO.GetValue());
            Assert.AreEqual(6600, stockMSFT.GetValue());
        }

        [TestMethod]
        public void CanCalculateTotalValue()
        {
            Stock stockHP = new Stock("HPQ", 60.03, 120);
            Stock stockIBM = new Stock("IBM", 32.11, 50);

           Stock[] stocks = new Stock[2];
            stocks[0] = stockHP;
            stocks[1] = stockIBM;

            Assert.AreEqual(8809.1, Stock.TotalValue(stocks));
        }

        [TestMethod]
        public void CanCreateToString()
        {
            Stock stockABC = new Stock("ABC", 12.23, 50);

            Assert.AreEqual("Stock[symbol=ABC,pricePerShare=12.23,numShares=50]", stockABC.ToString());
        }

        
        [TestMethod]
        public void TwoStockObjectsWithSameValuesAreEqual()
        {
            Stock abc1 = new Stock("ABC", 12.23, 50);
            Stock abc2 = new Stock("ABC", 12.23, 50);

            Assert.IsTrue(abc1.Equals(abc2));
            Assert.IsTrue(abc2.Equals(abc1));
        }

        [TestMethod]
        public void TwoStockObjectsWithDifferentValuesAreNotEqual()
        {
            Stock stock1 = new Stock("ABC", 12.23, 50);
            Stock stock2 = new Stock("XYZ", 12.23, 50);
            Stock stock3 = new Stock("ABC", 45.67, 50);
            Stock stock4 = new Stock("ABC", 12.23, 60);

            Assert.IsTrue(!stock1.Equals(stock2));
            Assert.IsTrue(!stock1.Equals(stock3));
            Assert.IsTrue(!stock1.Equals(stock4));
        }


    }
}
