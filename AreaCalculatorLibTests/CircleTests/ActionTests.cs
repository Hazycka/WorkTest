using Microsoft.VisualStudio.TestTools.UnitTesting;
using AreaCalculatorLib;
using AreaCalculatorLib.Figures;
using System;

namespace AreaCalculatorLibTests.CircleTests
{
    [TestClass]
    public class ActionTests
    {
        private float _validRadius;
        private float _invalidRadius;
        private float _areaExpected;
        private Circle _circle;

        [TestInitialize]
        public void TestInitialize()
        {
            _validRadius = 4;
            _invalidRadius = 0;
            _areaExpected = MathF.PI * MathF.Pow(_validRadius, 2);

            _circle = new Circle(_validRadius);
        }

        [TestMethod]
        public void GetAreaStatic_ValidRadius()
        {
            Assert.AreEqual(_areaExpected, Circle.GetFigureArea(_validRadius));
        }

        [ExpectedException(typeof(FigureException), "Exception was not thrown")]
        [TestMethod]
        public void GetAreaStatic_InvalidRadius_Exception()
        {
            Circle.GetFigureArea(_invalidRadius);
        }

        [TestMethod]
        public void GetArea_ValidRadius()
        {
            Assert.AreEqual(_areaExpected, _circle.GetFigureArea());
        }

        [ExpectedException(typeof(FigureException), "Exception was not thrown")]
        [TestMethod]
        public void SetInvalidRadius_Exception()
        {
            _circle.Radius = _invalidRadius;
        }
    }
}