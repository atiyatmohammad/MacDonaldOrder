using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacDonald_order
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int i = 1;
            double ordertotal = 0;
            double finaltotal = 0;
            double discount = 0;
            while (i < 4)
            {

                Console.WriteLine("enter item" + i + " price" );
                string item1 = Console.ReadLine();
                double itemp;

                if (double.TryParse(item1, out itemp))
                {
                    ordertotal = ordertotal + itemp;
                    i++;
                }
                else
                {
                    Console.WriteLine("error item price wrong");

                }

            }

            string discounttype = "";

            if (ordertotal >= 15)
            {
                discounttype = "y";
            }
            else
            {
                discounttype = "n";
            }

            switch (discounttype)
            {

                case "y":
                    discount = 0.05;
                    break;
                case "n":
                    discount = 0;
                    break;
            }

            Console.WriteLine();
            Console.WriteLine("Total       " + Math.Round(ordertotal, 2));
            double discounttot = 0;
            discounttot = ordertotal * discount;
            finaltotal = ordertotal - discounttot;
            Console.WriteLine();

            Console.WriteLine("Discount    " + Math.Round(discounttot, 2));
            Console.WriteLine();
            Console.WriteLine("Final Total " + Math.Round(finaltotal, 2));
        }
    }
}
