using System;
using LearningCS.Resources.TaskClasses.Standalone_classes;
using NUnit.Framework;

namespace UnitTests
{
    internal class WaterStateControllerTest
    {
        #region Test 1 - Values are saved
        [Test]
        public void Test01WaterAt20Degrees()
        {
            var water = new Water(50, 20);
            Assert.AreEqual(WaterState.Fluid, water.State);
            Assert.AreEqual(20, water.Temperature);
            Assert.AreEqual(50, water.Amount);
        }
        #endregion

        #region Test 2 - Values are saved when there's a negative number
        [Test]
        public void Test02WaterAtMinus20Degrees()
        {
            var water = new Water(50, -20);
            Assert.AreEqual(WaterState.Ice, water.State);
            Assert.AreEqual(-20, water.Temperature);
        }
        #endregion

        #region Test 3 - State changes to gas at 120 degrees
        [Test]
        public void Test03WaterAt120Degrees()
        {
            var water = new Water(50, 120);
            Assert.AreEqual(WaterState.Gas, water.State);
            Assert.AreEqual(120, water.Temperature);
        }
        #endregion

        #region Test 4 - Exception error when we dont provide required parameter
        [Test]
        //At 0 and 100 degrees we have to proide a parameter to the constructor which tells it how large the
        //portion in the first phase is (if we mix ice and water at 0 or 100 degrees, or water and gas at
        //0 or 100 degrees, we have to tell the method how large a portion of each type we have). This test
        //checks if we get an exception error if this parameter is not present while the temperature is 0 or 100.
        public void Test04WaterAt100DegreesWithoutProportion()
        {
            var exception = Assert.Throws<ArgumentException>(() =>
            {
                new Water(50, 100);
            });

            Assert.That(exception?.Message, Is.EqualTo("When temperature is 0 or 100, you must provide a value for proportion"));
        }
        #endregion

        #region Test 5 - Do we get both water and gas with 30% proportion
        [Test]
        public void Test05WaterAt100Degrees()
        {
            var water = new Water(50, 100, 0.3);
            Assert.AreEqual(WaterState.FluidAndGas, water.State);
            Assert.AreEqual(100, water.Temperature);
            Assert.AreEqual(0.3, water.ProportionFirstState);
        }
        #endregion

        #region Test 6 - Increase in temperature
        [Test]
        //Tests that when we add energy, the temperature increases with the right amount
        public void Test06AddEnergy1()
        {
            var water = new Water(4, 10);
            water.AddEnergy(10);
            Assert.AreEqual(12.5, water.Temperature);
        }
        #endregion

        #region Test 7 - Decrease in temperature
        [Test]
        public void Test07AddEnergy2()
        {
            var water = new Water(4, -10);
            water.AddEnergy(10);
            Assert.AreEqual(-7.5, water.Temperature);
        }
        #endregion

        #region Test 8 - Water below 0 heats up to 0 and then melts
        [Test]
        //Test that water below 0 warms up to 0 and then melts if we supply enough energy.
        //Test that the temperature stops at 0 if we don't have enough energy to melt it all.
        public void Test10AddEnergy3()
        {
            var water = new Water(4, -10);
            water.AddEnergy(168);
            Assert.AreEqual(0, water.Temperature);
            Assert.AreEqual(WaterState.IceAndFluid, water.State);
            Assert.AreEqual(0.6, water.ProportionFirstState);
        }
        #endregion

        #region Test 9 - Melt ice
        [Test]
        public void Test11AddEnergy4()
        {
            var water = new Water(4, -10);
            water.AddEnergy(360);
            Assert.AreEqual(0, water.Temperature);
            Assert.AreEqual(WaterState.Fluid, water.State);
        }
        #endregion

        #region Test 10 - Excess energy after melting goes to heating
        [Test]
        //Test that all excess energy after melting goes to heating with the correct amount of degrees
        public void Test12AddEnergy5()
        {
            var water = new Water(4, -10);
            water.AddEnergy(400);
            Assert.AreEqual(10, water.Temperature);
            Assert.AreEqual(WaterState.Fluid, water.State);
        }
        #endregion

        #region Test 11 - Evaporate water 1
        [Test]
        public void Test13FluidToGasA()
        {
            var water = new Water(10, 70);
            water.AddEnergy(900);
            Assert.AreEqual(100, water.Temperature);
            Assert.AreEqual(WaterState.FluidAndGas, water.State);
            Assert.AreEqual(0.9, water.ProportionFirstState);
        }
        #endregion

        #region Test 12 - Evaporate water 2
        [Test]
        public void Test14FluidToGasB()
        {
            var water = new Water(10, 70);
            water.AddEnergy(6300);
            Assert.AreEqual(100, water.Temperature);
            Assert.AreEqual(WaterState.Gas, water.State);
        }
        #endregion

        #region Test 13 - Evaporate water 3
        [Test]
        public void Test14FluidToGasC()
        {
            var water = new Water(10, 70);
            water.AddEnergy(6400);
            Assert.AreEqual(110, water.Temperature);
            Assert.AreEqual(WaterState.Gas, water.State);
        }
        #endregion
    }
}
