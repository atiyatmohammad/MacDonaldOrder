using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacdonaldOrder
{
    internal class Program
    {
        static int[] itemIds = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        static string[] itemNames = { "Burger", "Chicken", "Humus", "Falafel", "Kibah", "Tomato", "French Fries", "Chicken Wings", "Mash Potato" };
        static double[] prices = { 4.5, 5, 10, 12.5, 13, 20, 13, 25, 10 };

        static void Main(string[] args)
        {
            DisplayMenu();

            List<string> shoppingCart = new List<string>();
            double orderTotal = 0;
            double discount = 0;

            Console.WriteLine("Your order (type 'f' to finish or 'c' to cancel):");

            while (true)
            {
                Console.Write("Enter item ID: ");
                string input = Console.ReadLine()?.Trim().ToLower();
                if (input == "c")
                {
                    Console.WriteLine("Order canceled.");
                    return;
                }
                else if (input == "f")
                {
                   goto finshorder;
                }
                else if (int.TryParse(input, out int itemId) && itemId >= 1 && itemId <= itemIds.Length)
                {
                    int index = itemId - 1;
                    orderTotal += prices[index];
                    shoppingCart.Add($"{itemIds[index],-10} {itemNames[index],-20} {prices[index],5:C}");
                    Console.WriteLine($"Added: {itemNames[index]} ({prices[index]:C})");
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid item ID.");
                }
            }

         finshorder:
            discount = CalculateDiscount(orderTotal);
            double discountAmount = orderTotal * discount;
            double finalTotal = orderTotal - discountAmount;

            DisplayReceipt(shoppingCart, orderTotal, discountAmount, finalTotal);
        }
        static void DisplayMenu()
        {
            Console.WriteLine("Menu Items:");
            Console.WriteLine();

            for (int i = 0; i < itemIds.Length; i++)
            {
                Console.WriteLine($"{itemIds[i],-5} {itemNames[i],-20} {prices[i],5:C}");
            }

            Console.WriteLine();
        }

        static double CalculateDiscount(double total)
        {
            return total >= 15 ? 0.05 : 0;
        }

        static void DisplayReceipt(List<string> shoppingCart, double orderTotal, double discountAmount, double finalTotal)
        {
            Console.WriteLine();
            Console.WriteLine("Thank You for Shopping at MacDonald!");
            Console.WriteLine();

            Console.WriteLine("Your Shopping Cart:");
            shoppingCart.ForEach(item => Console.WriteLine(item));

            Console.WriteLine();
            Console.WriteLine($"Total:       {orderTotal,5:C}");
            Console.WriteLine($"Discount:    {discountAmount,5:C}");
            Console.WriteLine($"Final Total: {finalTotal,5:C}");
        }
    }
}   


