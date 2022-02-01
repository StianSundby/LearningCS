using NUnit.Framework;
using LearningCS.Resources.TaskClasses.BottleMath;

namespace UnitTests
{
    internal class BottleMathTest
    {
        [Test]
        public void BottleMathTest1()
        {
            var simulation = new Simulation( 1, 5, 7);
            var operationSet = simulation.Run();
            Assert.AreEqual(8, operationSet.Length);
            Assert.AreEqual(1, simulation.Bottle1.Content);
            Assert.AreEqual(7, simulation.Bottle2.Content);
        }
        [Test]
        public void BottleMathTest2()
        {
            var simulation = new Simulation(1, 3, 5);
            var operationSet = simulation.Run();
            Assert.AreEqual(4, operationSet.Length);
            Assert.AreEqual(1, simulation.Bottle1.Content);
            Assert.AreEqual(5, simulation.Bottle2.Content);
        }
        [Test]
        public void BottleMathTest3()
        {
            var simulation = new Simulation(2, 4, 5);
            var operationSet = simulation.Run();
            Assert.AreEqual(6, operationSet.Length);
            Assert.AreEqual(4, simulation.Bottle1.Content);
            Assert.AreEqual(2, simulation.Bottle2.Content);
        }
    }
}