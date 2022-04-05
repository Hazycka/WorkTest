using Microsoft.VisualStudio.TestTools.UnitTesting;
using AreaCalculatorLib;
using AreaCalculatorLib.Figures;

namespace AreaCalculatorLibTests.CircleTests
{
    [TestClass]
    public class InitializeTests
    {
        [TestMethod]
        public void Initialization_ValidRadius_3_NotException()
        {
            float radius = 3;
            Circle circleInstance = new(radius);
            float radiusExpected = radius;

            float radiusActual = circleInstance.Radius;

            Assert.AreEqual(radiusExpected, radiusActual);
        }

        [ExpectedException(typeof(FigureException), "Exception was not thrown")]
        [TestMethod]
        public void Initialization_InvalidRadius_minus0123_Exception()
        {
            float radius = -0.123f;
            Circle circleInstance = new(radius);
        }
    }
}