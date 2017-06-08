using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkCostCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var calculator = new Calculator(new DrinkBuilder(), new ProductFactory());

            Console.Write("Введите напиток: ");
            string drinkId = Console.ReadLine();

            Console.Write("Ведите добавки: ");
            string additionIds = Console.ReadLine();

            Console.WriteLine("Стоимость: {0}$", calculator.GetTotalCost(drinkId, additionIds));
            Console.ReadLine();
        }
    }
}
