using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _08_Orange_Tree
{
    [TestClass]
    public class OrangeTreeTests
    {
        private OrangeTree orangeTree;

        [TestInitialize]
        public void SetupForTest()
        {
            //Arrange
            orangeTree = new OrangeTree(0,6);
        }

        [TestMethod]
        public void ShouldIncrementTheTreesAgeWithEachPassingYear()
        {
             
            //Act
            orangeTree.OneYearPasses();

            //Assert
            Assert.AreEqual(1, orangeTree.Age);
        }
        [TestMethod]
        public void ShouldIncrementTheTreesHeightByTwoWithEachPassingYear()
        {
            
            //Act
            orangeTree.OneYearPasses();

            //Assert
            Assert.AreEqual(8, orangeTree.Height);
        }
        [TestMethod]
        public void ShouldDieAfter80Years()
        {

            //Act
            for (int i = 1; i <= 80; i++)
            {
                orangeTree.OneYearPasses();
            }

            //Assert
            Assert.AreEqual(false, orangeTree.TreeAlive);
        }

        [TestMethod]
        public void ShouldProduceFruitAfter2Years()
        {
            orangeTree.NumOranges = 0;
            orangeTree.OneYearPasses();
            Assert.AreEqual(0, orangeTree.NumOranges);

            orangeTree.OneYearPasses();
            Assert.AreEqual(5, orangeTree.NumOranges);
            
        }
        [TestMethod]
        public void ShouldIncreaseFruitProductionBy5PiecesEachYearAfterMaturity()
        {
            orangeTree.OneYearPasses();
            orangeTree.OneYearPasses();
            Assert.AreEqual(5, orangeTree.NumOranges);

            orangeTree.OneYearPasses();
            Assert.AreEqual(10, orangeTree.NumOranges);
            
        }
        [TestMethod]
        public void ShouldCountNumberOfOrangesEatenThisYear()
        {
            orangeTree.OneYearPasses();
            orangeTree.OneYearPasses();
            orangeTree.EatOrange(1);

            Assert.AreEqual(1, orangeTree.OrangesEaten);

            orangeTree.EatOrange(3);
            Assert.AreEqual(4, orangeTree.OrangesEaten);
        }
        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException), "You can't eat an orange that isn't there!  There are 0 oranges available to eat")]
        public void ShouldNotLetYouPickFruitThatIsNotThere()
        {
            orangeTree.EatOrange(1);
        }

       
    }
}
