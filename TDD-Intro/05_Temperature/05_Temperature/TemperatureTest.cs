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
            Assert.AreEqual(32, temp.Fahrenheit);
        }
        [TestMethod]
        public void CanSaveDataInCelciusProperty()
        {
            var temp = new Temperature();
            temp.Celcius = 0;
            Assert.AreEqual(0, temp.Celcius);
        }
        [TestMethod]
        public void CanBeConstructedViaConstructor()
        {
            var temp = new Temperature(Unit.Celcius, 20); //Use Enum
            Assert.AreEqual(20, temp.Celcius);

            temp = new Temperature(Unit.Fahrenheit, 20); //Use Enum
            Assert.AreEqual(20, temp.Fahrenheit);
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
            ITemperature temp = TemperatureFactory.Get(Unit.Celcius); //Use Enum
            Assert.IsInstanceOfType(temp, typeof(Celcius)); //Pay attention to the order of the parameters in IsInstanceOfType

        }
        [TestMethod]
        public void FactoryMethodCovertsCorrectlyFromFahrenheitToCelcius()
        {
            ITemperature temp = TemperatureFactory.Get(Unit.Celcius); //Use Enum
            Assert.AreEqual(100, (temp as Celcius).Convert(212));
            Assert.AreEqual(100, temp.Convert(212));
        }
        [TestMethod]
        public void FactoryMethodCovertsCorrectlyFromCelciusToFahrenheit()
        {
            ITemperature temp = TemperatureFactory.Get(Unit.Fahrenheit); //Use Enum
            Assert.AreEqual(212, (temp as Fahrenheit).Convert(100));
            Assert.AreEqual(212, temp.Convert(100));
        }

    }
}
