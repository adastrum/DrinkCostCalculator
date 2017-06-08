using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkCostCalculator
{
    public interface IProductFactory
    {
        Drink GetDrink(int id);
        Addition GetAddition(int id);
    }

    /// <summary>
    /// Simple data source implementation;
    /// can be replaced with database, service etc.
    /// </summary>
    public class ProductFactory : IProductFactory
    {
        Dictionary<int, Drink> _drinks;
        Dictionary<int, Addition> _additions;

        public ProductFactory()
        {
            _drinks = new Dictionary<int, Drink>
            {
                {1, new Drink(1, "Кофе", 15)},
                {2, new Drink(2, "Чай", 10)}
            };

            _additions = new Dictionary<int, Addition>
            {
                {1, new Addition(1, "Молоко ", 2)},
                {2, new Addition(2, "Сахар ", 1)},
                {3, new Addition(3, "Корица ", 3)},
                {4, new Addition(4, "Лимон ", 1)}
            };
        }

        public Drink GetDrink(int id)
        {
            if (_drinks.ContainsKey(id))
            {
                return _drinks[id];
            }
            return null;
        }

        public Addition GetAddition(int id)
        {
            if (_additions.ContainsKey(id))
            {
                return _additions[id];
            }
            return null;
        }
    }
}
