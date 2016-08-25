using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSpec;

namespace _05_Temperature
{
    [TestClass]
    public class TemperatureTest 
    {
        //Fahrenheit to celcius

        [TestMethod]
        public void ConvertFreezingTemperatureFTOC()
        {
           Assert.AreEqual(0, Temperature.FahrenheitToCelcius(32));
        }

        [TestMethod]
        public void ConvertBoilingTemperatureFTOC()
        {
            Assert.AreEqual(100, Temperature.FahrenheitToCelcius(212));
        }
        [TestMethod]
        public void ConvertBodyTemperatureFTOC()
        {
            Assert.AreEqual(37, Temperature.FahrenheitToCelcius(98.6));
        }
        [TestMethod]
        public void ConvertAbitraryTemperatureFTOC()
        {
            Assert.AreEqual(20, Temperature.FahrenheitToCelcius(68));
        }

        //Celcius to Fahrenheit
        [TestMethod]
        public void ConvertFreezingTemperatureCTOF()
        {
            Assert.AreEqual(32, Temperature.CelciusToFahrenheit(0));
        }
        [TestMethod]
        public void ConvertBoilingTemperatureCTOF()
        {
            Assert.AreEqual(212, Temperature.CelciusToFahrenheit(100));
        }
        [TestMethod]
        public void ConvertBodyTemperatureCTOF()
        {
            Assert.AreEqual(98.6, Temperature.CelciusToFahrenheit(37));
        }
        [TestMethod]
        public void ConvertArbitraryTemperatureCTOF()
        {
            Assert.AreEqual(68, Temperature.CelciusToFahrenheit(20));
        }
        
    }
}
