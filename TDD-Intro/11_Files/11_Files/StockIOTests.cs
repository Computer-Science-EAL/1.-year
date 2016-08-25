using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace _11_Files
{
    /// <summary>
    /// Summary description for StockIOTests
    /// </summary>
    [TestClass]
    public class StockIOTests
    {
        Stock hp = new Stock("HP", 11.4, 10);
        Stock yhoo = new Stock("YHOO", 57.2, 30);
        string NL = Environment.NewLine;

        [TestMethod]
        public void CanWriteToWriterHp()
        {
            StockIO io = new StockIO();
            StringWriter sw = new StringWriter();
            io.WriteStock(sw, hp);
            Assert.AreEqual("HP" + NL + "11,4" + NL + "10" + NL, sw.ToString());
        }

        [TestMethod]
        public void CanWriteStockYahoo()
        {
            StockIO io = new StockIO();
            StringWriter sw = new StringWriter();
            io.WriteStock(sw, yhoo);
            Assert.AreEqual("YHOO" + NL + "57,2" + NL + "30" + NL, sw.ToString());
        }

        [TestMethod]
        public void CanReadStock()
        {
            StockIO io = new StockIO();

            String hpData = "HP" + NL + "11,4" + NL + "10" + NL;
            String yhooData = "YHOO" + NL + "57,2" + NL + "30" + NL;

            StringReader data = new StringReader(hpData);
            Stock loaded = io.ReadStock(data);
            Assert.AreEqual(hp, loaded);

            data = new StringReader(yhooData);
            loaded = io.ReadStock(data);
            Assert.AreEqual(yhoo, loaded);
        }


        [TestMethod]
        public void CanWriteToFile()
        {
            FileInfo output = new FileInfo("stockout.txt");
            try
            {
                StockIO io = new StockIO();
                io.WriteStock(output, hp);
                Assert.IsTrue(output.Exists);
                Stock loaded = io.ReadStock(output);
                Assert.AreEqual(hp, loaded);
            }
            finally
            {
                output.Delete();
            }
        }


    }
}
