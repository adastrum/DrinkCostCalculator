using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkCostCalculator
{
    public interface IDrinkBuilder
    {
        Drink Drink { set; }
        void Add(Addition addition);
        decimal TotalCost { get; }
    }

    /// <summary>
    /// Combines drinks with additions and calculates cost
    /// </summary>
    public class DrinkBuilder : IDrinkBuilder
    {
        private Drink _drink;
        private List<Addition> _additions = new List<Addition>();

        public Drink Drink
        {
            set
            {
                _drink = value;
            }
        }

        public void Add(Addition addition)
        {
            _additions.Add(addition);
        }

        public decimal TotalCost
        {
            get
            {
                return (_drink == null ? decimal.Zero : _drink.Price) +
                    _additions.Sum(a => a.Price);
            }
        }
    }
}
