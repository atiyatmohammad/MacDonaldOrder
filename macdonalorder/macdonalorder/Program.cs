using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace macdonalorder
{
    internal class Program
    {
        static int[] itemid = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        static string[] itemname = { "Burger", "Chicken", "Humus", "Falafel", "Kibah", "Tomato", "Frensh Fries", "Chicken Wings","Mash Potato" };
        static double[] price = { 4.5, 5, 10, 12.5, 13, 20, 13, 25, 10 };
        static string[] shopcart = { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" };
        //static string[] shopcart;
        static void Main(string[] args)
        {
            int i = 1;
            double ordertotal = 0;
            double finaltotal = 0;
            double discount = 0;
            string item1 = "order";
            Console.WriteLine("Menu Items");
            Console.WriteLine();
            for (int j = 0; j < 9; j++)
            {
                Console.WriteLine($"{itemid[j] } {itemname[j]} ${price[j]} ");

            }
            Console.WriteLine();
            Console.WriteLine("Your order Please type f to finsh order or c to cancel order(f/c)");
            
            
            while (true)
            {

                Console.WriteLine("enter itemid");
                item1 = Console.ReadLine();
                if (item1 == "c") { Console.WriteLine("order canceled"); return; }
                if (item1 == "f") { break; } // if "sales person press exit it will break loop and press after loop
                int itemid1;

                if (int.TryParse(item1, out itemid1)) // if customer enter number true it will add item price to total
                {
                    ordertotal = ordertotal + price[itemid1-1];  // add order price
                    //Console.WriteLine($"itemid {itemid1} itemname {itemname[itemid1-1]} itemprice {price[itemid1-1]}");
                    Console.WriteLine($"itemid {itemid1} itemname {itemname[itemid1 - 1]} itemprice {price[itemid1 - 1]}");
                    shopcart[i] = $"itemid {itemid1} itemname {itemname[itemid1 - 1]} itemprice {price[itemid1 - 1]}";
                    i++; // counter in case
                }
                else
                {
                    Console.WriteLine("error item price wrong"); // if customer enter character instead of number false from if
                    // it will show error but it will continue your order (you will stay in order) 
                }

            }

            string discounttype = "";

            if (ordertotal >= 15) // if cusomer totat 15 and up get discount y
            {
                discounttype = "y";
            }
            else
            {
                discounttype = "n"; // if order less than 15 no discount
            }

            switch (discounttype) // if he get discount he get 0.05;
            {

                case "y":
                    discount = 0.05; // if discount type y he get 0.05;
                    break;
                case "n":
                    discount = 0; // if discount type n he get 0
                    break;
            }

            ////// when sales person finsh order it will jump after loop to calculate
            Console.WriteLine();
            Console.WriteLine("Thank You For Shopping At MacDonald");
            Console.WriteLine();
            
            
            foreach (string nm in shopcart) {  // retreive all items in shopcart
                if (nm.Length > 0){
                    Console.WriteLine(nm);
                }
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

