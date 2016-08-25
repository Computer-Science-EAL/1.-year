using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _07_Timer
{
    [TestClass]
    public class TimerTests
    {
        private Timer timer;

        [TestInitialize]
        public void SetupForTest()
        {
            timer = new Timer();
        }

        [TestMethod]
        public void ShouldInitializeToZero()
        {
            Assert.AreEqual(0, timer.Seconds);
        }
        [TestMethod]
        public void ShouldDisplay0SecondsToStringAs00ː00ː00()
        {
            timer.Seconds = 0;
            Assert.AreEqual("00:00:00", timer.ToString());
        }
        [TestMethod]
        public void ShouldDisplay12SecondsToStringAs00ː00ː12()
        {
            timer.Seconds = 12;
            Assert.AreEqual("00:00:12", timer.ToString());
        }
        [TestMethod]
        public void ShouldDisplay66SecondsToStringAs00ː01ː06()
        {
            timer.Seconds = 66;
            Assert.AreEqual("00:01:06", timer.ToString());
        }
        [TestMethod]
        public void ShouldDisplay4000SecondsToStringAs01ː40ː06()
        {
            timer.Seconds = 4000;
            Assert.AreEqual("01:40:06", timer.ToString());
        }
        // One way to implement the Timer is with a helper method.
        // Uncomment these specs if you want to test-drive that
        // method, then call that method from inside of ToString().

        //[TestMethod]
        //public void PadsZero()
        //{
        //    Assert.AreEqual("00", timer.Padded(0));
        //}
        //[TestMethod]
        //public void PadsOne()
        //{
        //    Assert.AreEqual("01", timer.Padded(1));
        //}
        //[TestMethod]
        //public void DoesNotPad()
        //{
        //    Assert.AreEqual("12", timer.Padded(12));
        //}
    }
}
