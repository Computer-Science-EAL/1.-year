using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace _05_Temperature
{
    [TestClass]
    public class TemperatureTest
    {
        //STATIC CLASSES

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

        //INSTANCE CLASSES

        //Through properties & constructors
        [TestMethod]
        public void CanSaveDataInFahrenheitProperty()
        {
            var temp = new Temperature();
            temp.Fahrenheit = 32;
            Assert.AreEqual(32, Temperature.Fahrenheit);
        }
        [TestMethod]
        public void CanSaveDataInCelciusProperty()
        {
            var temp = new Temperature();
            temp.Celcius = 0;
            Assert.AreEqual(0, Temperature.Celcius);
        }
        [TestMethod]
        public void CanBeConstructedViaConstructor()
        {
            var temp = new Temperature(Unit.Celcius, 20);
            Assert.AreEqual(20, Temperature.Celcius);
        }


        //# test-driving bonus:
        //#
        //# refactor to call CelciusToFahrenheit and FahrenheitToCelcius from the rest of the object
        //#
        //# run *all* the tests during your refactoring, to make sure you did it right
        //#


        //Test driven bonus. If you have read about factory methods try solving the problem below

        [TestMethod]
        public void CanBeConstructedViaFactoryMethod()
        {
            Assert.AreEqual(100, TemperatureFactory.Get(Unit.Celcius, 212));
            Assert.AreEqual(212, TemperatureFactory.Get(Unit.Fahrenheit, 100));
        }


    }
}
