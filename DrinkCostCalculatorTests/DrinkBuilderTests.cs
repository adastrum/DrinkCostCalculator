using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DrinkCostCalculator;

namespace DrinkCostCalculatorTests
{
    [TestClass]
    public class DrinkBuilderTests
    {
        private DrinkBuilder _drinkBuilder;

        [TestInitialize]
        public void Initialize()
        {
            _drinkBuilder = new DrinkBuilder();
        }

        [TestMethod]
        public void NoProducts_ReturnsZeroCost()
        {
            Assert.AreEqual(decimal.Zero, _drinkBuilder.TotalCost);
        }

        [TestMethod]
        public void NoAdditions_ReturnsDrinkCost()
        {
            var price = 1000m;
            _drinkBuilder.Drink = new Drink(0, null, price);
            Assert.AreEqual(price, _drinkBuilder.TotalCost);
        }

        [TestMethod]
        public void NoDrink_ReturnsAdditionCost()
        {
            _drinkBuilder.Add(new Addition(0, null, 111));
            _drinkBuilder.Add(new Addition(0, null, 222));
            _drinkBuilder.Add(new Addition(0, null, 333));
            Assert.AreEqual(666, _drinkBuilder.TotalCost);
        }

        [TestMethod]
        public void DrinkWithAdditions_ReturnsCorrectCost()
        {
            var price = 1000m;
            _drinkBuilder.Drink = new Drink(0, null, price);
            _drinkBuilder.Add(new Addition(0, null, 111));
            _drinkBuilder.Add(new Addition(0, null, 222));
            _drinkBuilder.Add(new Addition(0, null, 333));
            Assert.AreEqual(1666, _drinkBuilder.TotalCost);
        }
    }
}
