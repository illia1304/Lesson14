using System;
using System.Diagnostics;

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

        public Products(string name, float price, int quantity)
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
        public float spentMoney;

        public Buyer(string name, int id, float spentMoney)
        {
            this.name = name;
            this.id = id;
            this.spentMoney = spentMoney;
        }
    }

    public class Shop
    {
        Products[] products = new Products[10];
        int countP = 0;

        Buyer[] buyers = new Buyer[10];
        int countB = 1;
        public Shop()
        {

        }

        public void BuyProduct()
        {
            Console.WriteLine("What product do you want to buy?");
            string name = Console.ReadLine();

            for(int i = 0; i < products.Length; i++)
            {
                if (products[i].name == name)
                {
                    buyers[countP] = new Buyer($"buyer{countB}", countB, products[i].price * products[i].quantity);

                    products[i].quantity--;
                }
            }
            
        }
        public void ListOfProducts()
        {
            for (int i = 0; i < countP; i++)
            {
                Console.WriteLine($"{products[i].name}, {products[i].price}, {products[i].quantity}");
            }
        }
        public void Receips()
        {
            for(int i = 1; i <= buyers.Length; i++)
            {
                Console.WriteLine($"{buyers[i].name}{i}, {buyers[i].id}, {buyers[i].spentMoney}");
            }
        }
        public void AddProduct(string name, float price, int quantity)
        {
            if(products.Length > countP)
            {
                products[countP] = new Products(name, price, quantity);
                countP++;

                Console.WriteLine("Product added");
            }

        }
    }

    public class ShopInterface: Shop
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

            switch(index)
            {
                case 1:
                    BuyProduct();
                    break;
                case 2:
                    ListOfProducts();
                    break;
                case 3:
                    Receips();
                    break;
                case 4:
                    Console.WriteLine("Enter name of product:");
                    string name = Console.ReadLine();
                    Console.WriteLine("Enter price of product:");
                    float price = float.Parse(Console.ReadLine());
                    Console.WriteLine("Enter quantity of product:");
                    int quantity = int.Parse(Console.ReadLine());
                    
                    
                    AddProduct(name, price, quantity);
                    break;
                default:
                    Console.WriteLine("Invalid value");
                    break;
            }

        }

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