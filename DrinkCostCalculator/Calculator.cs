using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkCostCalculator
{
    /// <summary>
    /// Abstraction layer between actual logic (DrinkBuilder) and UI (Console)
    /// </summary>
    public class Calculator
    {
        private DrinkBuilder _drinkBuilder;
        private ProductFactory _productFactory;

        public Calculator(DrinkBuilder drinkBuilder, ProductFactory productFactory)
        {
            _drinkBuilder = drinkBuilder;
            _productFactory = productFactory;
        }

        public decimal GetTotalCost(string drinkId, string additionIds)
        {
            if (!string.IsNullOrEmpty(drinkId))
            {
                int id;
                if (int.TryParse(drinkId, out id))
                {
                    var drink = _productFactory.GetDrink(id);
                    if (drink != null)
                    {
                        _drinkBuilder.Drink = drink;
                    }
                }
            }

            if(!string.IsNullOrEmpty(additionIds))
            {
                string[] parts = additionIds.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string part in parts)
                {
                    int additionId;
                    if (int.TryParse(part, out additionId))
                    {
                        var addition = _productFactory.GetAddition(additionId);
                        if (addition != null)
                        {
                            _drinkBuilder.Add(addition);
                        }
                    }
                }
            }

            return _drinkBuilder.TotalCost;
        }
    }
}
