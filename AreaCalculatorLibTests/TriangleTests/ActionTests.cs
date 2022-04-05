using Microsoft.VisualStudio.TestTools.UnitTesting;
using AreaCalculatorLib;
using AreaCalculatorLib.Figures;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AreaCalculatorLibTests.TriangleTests
{
    [TestClass]
    public class ActionTests
    {
        (float a, float b, float c) _validSides;
        (float a, float b, float c) _invalidSides;
        private float _areaExpected;
        private Triangle _triangle;

        [TestInitialize]
        public void TestInitialize()
        {
            _validSides = (3, 4, 5);
            _invalidSides = (1, -2, 5);
            //нахождение площади треугольника
            float p = (_validSides.a + _validSides.b + _validSides.c) / 2;
            _areaExpected = MathF.Sqrt(p * (p - _validSides.a) * (p - _validSides.b) * (p - _validSides.c));
            
            _triangle = new Triangle(_validSides.a, _validSides.b, _validSides.c);
        }

        [TestMethod]
        public void GetAreaStatic_ValidSides()
        {
            Assert.AreEqual(_areaExpected, Triangle.GetFigureArea(_validSides.a, _validSides.b, _validSides.c));
        }

        [ExpectedException(typeof(FigureException), "Exception was not thrown")]
        [TestMethod]
        public void GetAreaStatic_InvalidSides_Exception()
        {
            Triangle.GetFigureArea(_invalidSides.a, _invalidSides.b, _invalidSides.c);
        }

        [TestMethod]
        public void IsTriangleRightStatic_ValidSides_4_7_4()
        {
            (float a, float b, float c) = (4, 7, 4);
            bool expectedAnswer = IsTriangleRight(a, b, c);

            Assert.AreEqual(expectedAnswer, Triangle.IsTriangleRight(a, b, c));
        }

        [ExpectedException(typeof(FigureException), "Exception was not thrown")]
        [TestMethod]
        public void IsTriangleRightStatic_InvalidSides_Exception()
        {
            Triangle.GetFigureArea(_invalidSides.a, _invalidSides.b, _invalidSides.c);
        }

        [TestMethod]
        public void GetArea_ValidSides()
        {
            Assert.AreEqual(_areaExpected, _triangle.GetFigureArea());
        }

        [TestMethod]
        public void IsTriangleRight_ValidSides()
        {
            bool expectedAnswer = IsTriangleRight(_validSides.a, _validSides.b, _validSides.c);
            Assert.AreEqual(expectedAnswer, _triangle.IsTriangleRight());
        }

        [ExpectedException(typeof(FigureException), "Exception was not thrown")]
        [TestMethod]
        public void SetInvalidSides_3_4_7_Exception()
        {
            (float a, float b, float c) = (3, 4, 7);
            _triangle.RedefineSides(a, b, c);
        }


        public bool IsTriangleRight(float a, float b, float c)
        {
            List<float> sides = new List<float>() { a, b, c };
            float hypotenuse = sides.Max();
            sides.Remove(hypotenuse);
            if (hypotenuse * hypotenuse == sides[0] * sides[0] + sides[1] * sides[1])
                return true;
            else
                return false;
        }
    }
}