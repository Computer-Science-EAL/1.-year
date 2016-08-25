using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using System.Collections.Generic;

namespace _10_Collections
{
    //THESE ARE THE FIRST TESTS YOU SHOULD DO 

    [TestClass]
    public class CollectionsTest
    {
        Stock stockHP = new Stock("HPQ", 60.03, 120);
        Stock stockIBM = new Stock("IBM", 32.11, 50);
        Stock stockYHOO = new Stock("YHOO", 44.4, 180);

        [TestMethod]
        public void CanCopyElementsToAFacadeInterface()
        {
            Portfolio portfolio = new Portfolio();
            portfolio.AddAsset(stockIBM);
            portfolio.AddAsset(stockHP);
            portfolio.AddAsset(stockYHOO);

            IList<Asset> assets = portfolio.GetAssets();
            Assert.IsTrue(assets.Contains(stockIBM));
            Assert.IsTrue(assets.Contains(stockHP));
            Assert.IsTrue(assets.Contains(stockYHOO));
        }

        [TestMethod]
        public void CanGetAssetByName()
        {
            Portfolio portfolio = new Portfolio();
            portfolio.AddAsset(stockIBM);
            portfolio.AddAsset(stockHP);
            portfolio.AddAsset(stockYHOO);

            Assert.AreEqual(stockIBM, portfolio.GetAssetByName("IBM"));
            Assert.AreEqual(stockHP, portfolio.GetAssetByName("HPQ"));
            Assert.AreEqual(stockYHOO, portfolio.GetAssetByName("YHOO"));

            Assert.IsNull(portfolio.GetAssetByName("QQQQ"));
        }

        [TestMethod]
        public void CanCompareByName()
        {
            StockNameComparator comparator = new StockNameComparator();
            Assert.IsTrue(comparator.Compare(stockIBM, stockHP) > 0);
            Assert.AreEqual(0, comparator.Compare(stockIBM, stockIBM));
            Assert.IsTrue(comparator.Compare(stockIBM, stockYHOO) < 0);
        }

        [TestMethod]
        public void CanSortByName()
        {
            Portfolio portfolio = new Portfolio();
            portfolio.AddAsset(stockIBM);
            portfolio.AddAsset(stockHP);
            portfolio.AddAsset(stockYHOO);

            IList<Asset> assets = portfolio.GetAssetsSortedByName();
            Assert.IsTrue(stockHP.Equals(assets[0]));
            Assert.IsTrue(stockIBM.Equals(assets[1]));
            Assert.IsTrue(stockYHOO.Equals(assets[2]));
        }

        //    /**
        //* the ValueComparator sorts in *descending* order of value
        //* (most valuable comes first)
        //*/

        [TestMethod]
        public void CanCompareByValue()
        {
            StockValueComparator comparator = new StockValueComparator();
            Assert.IsTrue(comparator.Compare(stockIBM, stockHP) > 0);  // less is more
            Assert.AreEqual(0, comparator.Compare(stockIBM, stockIBM));
            Assert.IsTrue(comparator.Compare(stockYHOO, stockHP) < 0);
        }

        [TestMethod]
        public void CanSortByValue()
        {
            Portfolio portfolio = new Portfolio();
            portfolio.AddAsset(stockIBM);
            portfolio.AddAsset(stockHP);
            portfolio.AddAsset(stockYHOO);
            
            IList<Asset> stocks = portfolio.GetAssetsSortedByValue();
            Assert.AreEqual(stockYHOO, stocks[0]);
            Assert.AreEqual(stockHP, stocks[1]);
            Assert.AreEqual(stockIBM, stocks[2]);
            
        }

        [TestMethod]
        [ExpectedException(typeof(NotSupportedException), "Unable to add an asset to the returned collection. Collection is ReadOnly")]
        public void CannotAddAssetToFacade()
        {
            Portfolio portfolio = new Portfolio();
            portfolio.AddAsset(stockIBM);
            portfolio.AddAsset(stockHP);

            IList<Asset> assets = portfolio.GetAssets();
            assets.Add(stockYHOO);
        }

    }
}
