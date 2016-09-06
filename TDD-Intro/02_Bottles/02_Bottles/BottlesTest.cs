﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _02_Bottles
{
    [TestClass]
    public class BottlesTest
    {
        [TestMethod]
        public void NoBottles()
        {
            Song song = new Song();
            Assert.AreEqual(" No more bottles of beer on the wall.", song.CountBottles(0));

        }
        [TestMethod]
        public void CountDownFromOne()
        {
            Song song = new Song();
            Assert.AreEqual("1 bottle of beer on the wall."
                + " 1 bottle of beer."
                + " Take one down and pass it around."
                + " No more bottles of beer on the wall.", song.CountBottles(1));
        }
        [TestMethod]
        public void CountDownFromTwo()
        {
            Song song = new Song();
            Assert.AreEqual("2 bottles of beer on the wall."
                + " 2 bottles of beer."
                + " Take one down and pass it around."
                + " 1 bottle of beer on the wall."
                + " 1 bottle of beer on the wall."
                + " 1 bottle of beer."
                + " Take one down and pass it around."
                + " No more bottles of beer on the wall.", song.CountBottles(2));
        }
        [TestMethod]
        public void CountDownFromThree()
        {
            Song song = new Song();
            Assert.AreEqual("3 bottles of beer on the wall."
                + " 3 bottles of beer."
                + " Take one down and pass it around."
                + " 2 bottles of beer on the wall."
                + " 2 bottles of beer on the wall."
                + " 2 bottles of beer."
                + " Take one down and pass it around."
                + " 1 bottle of beer on the wall."
                + " 1 bottle of beer on the wall."
                + " 1 bottle of beer."
                + " Take one down and pass it around."
                + " No more bottles of beer on the wall.", song.CountBottles(3));
        }
    }
}



