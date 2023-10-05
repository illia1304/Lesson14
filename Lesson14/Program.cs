using System;
using System.Diagnostics;

namespace Lesson14
{
    public record Product(string name, float price);
    public record Buyer(string BuyerName);

    public class ProductCart
    {
        public Dictionary<Product, int> Products { get; set; } = new();

        public float Amount
        {
            
            get{
                float amount = 0;

                foreach (var item in Products)
                {
                    amount += item.Key.price * item.Value;
                }
                return amount;
            }

            
        }
    }

    public class Shop
    {
        //відповідальність:зберігати кількість товару, продавати, додавати товар, показувати товар
    }

    public class ShopInterface : Shop
    {
        public ShopInterface()
        {

        }

        public void Inteface()
        {
            Console.WriteLine("Enter number");
            Console.WriteLine("1. Buy product");
            Console.WriteLine("2.List of products");
            Console.WriteLine("3. Get receipts");
            Console.WriteLine("4.Add products");

            int index = int.Parse(Console.ReadLine());

            switch (index)
            {
                case 1:

                    break;
                case 2:

                    break;
                case 3:

                    break;
                case 4:
                    break;
                default:
                    Console.WriteLine("Invalid value");
                    break;
            }

        }
    }

    public class Recipe
    {
        //друкувати чеки
        /*Чек
          Ім'я покупця
          Товар1
          Товар2
          Ціна
          Дата
         */
    }


    class Programme
    {
        static void Main(string[] args)
        {
            Shop shop = new Shop();
            ShopInterface shopInterface = new ShopInterface();

            while(true)
            {
                shopInterface.Inteface();
            }
        }
    }
}