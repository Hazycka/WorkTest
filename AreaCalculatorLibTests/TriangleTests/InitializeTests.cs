using Microsoft.VisualStudio.TestTools.UnitTesting;
using AreaCalculatorLib;
using AreaCalculatorLib.Figures;
using System;

namespace AreaCalculatorLibTests.TriangleTests
{
    [TestClass]
    public class InitializeTests
    {
        [TestMethod]
        public void Initialization_ValidSides_3_4_5_NotException()
        {
            (float a, float b, float c) = (3, 4, 5);
            Triangle triangleInstance = new(a, b, c);
            (float, float, float) expectedSides= (a, b, c);

            (float, float, float) actualSides = (triangleInstance.A, triangleInstance.B, triangleInstance.C);

            Assert.AreEqual(expectedSides, actualSides);
        }

        [ExpectedException(typeof(FigureException), "Exception was not thrown")]
        [TestMethod]
        public void Initialization_InvalidSides_1_4_5_Exception()
        {
            (float a, float b, float c) = (1, 4, 5);
            Triangle triangleInstance = new(a, b, c);
        }

        [ExpectedException(typeof(FigureException), "Exception was not thrown")]
        [TestMethod]
        public void Initialization_InvalidSides_3_minus2_5_Exception()
        {
            (float a, float b, float c) = (3, -2, 5);
            Triangle triangleInstance = new(a, b, c);
        }
    }
}