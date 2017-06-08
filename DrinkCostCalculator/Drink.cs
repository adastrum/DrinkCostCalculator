using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkCostCalculator
{
    public class Drink : Product
    {
        public Drink(int id, string name, decimal price)
            : base(id, name, price)
        {
        }
    }
}
