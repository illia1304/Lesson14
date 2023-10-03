using System;

namespace Lesson14
{
    /*1.Goods
      2. buyers
      3. shop
      4.receipts 
    */

    struct Products
    {
        public string name;
        public float price;
        public int quantity;

        public Products(string? name, float price, int quantity)
        {
            this.name = name;
            this.price = price;
            this.quantity = quantity;
        }
    }

    public struct Buyer
    {
        public string name;
        public int id;

        public Buyer(string name, int id)
        {
            this.name = name;
            this.id = id;
        }
    }

    public class Shop
    {
        public Shop()
        {

        }
    }

    class Programme
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            float price = float.Parse(Console.ReadLine());
            int quantity = int.Parse(Console.ReadLine());

            Products products = new Products(name,price, quantity);

        }
    }
}