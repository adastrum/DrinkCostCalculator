using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DrinkCostCalculator;

namespace DrinkCostCalculatorTests
{
    [TestClass]
    public class CalculatorTests
    {
        private Calculator _calculator;

        [TestInitialize]
        public void Initialize()
        {
            _calculator = new Calculator(new DrinkBuilder(), new ProductFactory());
        }

        [TestMethod]
        public void EmptyInput_ReturnsZeroCost()
        {
            Assert.AreEqual(decimal.Zero, _calculator.GetTotalCost(string.Empty, string.Empty));
        }

        [TestMethod]
        public void EmptyDrinkInput_ReturnsAdditionCost()
        {
            Assert.AreEqual(7, _calculator.GetTotalCost(string.Empty, "1,2,3,4"));
        }

        [TestMethod]
        public void EmptyAdditionInput_ReturnsDrinkCost()
        {
            Assert.AreEqual(15, _calculator.GetTotalCost("1", string.Empty));
        }

        [TestMethod]
        public void InputWithSpaces_SpacesAreTrimmed()
        {
            Assert.AreEqual(20, _calculator.GetTotalCost(" 1 ", "2, 3, 2\t"));
        }
    }
}
