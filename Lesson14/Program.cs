using System;
using System.Collections.Generic;
using System.Linq;

namespace Lesson14
{
    public record Product(string name, float price);

    public record Buyer(string name = "Orest");

    public class UserInteraction
    {
        public bool ContinueShopping()
        {
            Console.Write("Do you want to continue shopping? (yes/no)");

            string answer = Console.ReadLine().ToLower();

            return answer == "yes";
        }
    }

    public class Shop
    {
        private Receipt receipt = new();
        private Dictionary<Product, int> products = new Dictionary<Product, int>();
        private Buyer buyer = new();

        UserInteraction userInteraction = new UserInteraction();

        public Shop()
        {

        }

        public void BuyProduct(string productName, int quantity)
        {
            Product product = products.Keys.FirstOrDefault(p => p.name == productName);
            if (products.TryGetValue(product, out int CurrentQuantity))
            {
                if (CurrentQuantity >= quantity)
                {
                    float totalPrice = quantity * product.price;
                    products[product] = CurrentQuantity - quantity;

                    receipt.AddPurchase(product, quantity, buyer.name);

                    if (!userInteraction.ContinueShopping())
                    {
                        receipt.PrintReceipt();
                    }
                }
                else
                {
                    Console.WriteLine($"Not enough {product.name} in shop.");
                }
            }
            else
            {
                Console.WriteLine($"{productName} not found in shop");
            }
        }

        public void ListOfProducts()
        {
            foreach (var product in products)
            {
                Console.WriteLine($"Product name:{product.Key.name}, price:{product.Key.price}, quantity:{product.Value}");
            }
        }

        public void AddProduct(Product product, int quantity)
        {
            if (products.ContainsKey(product))
            {
                products[product] += quantity;
            }
            else
            {
                products.Add(product, quantity);
            }
            Console.WriteLine($"Added {quantity} {product.name} to the shop.");
        }

        public void UpdateBuyerName(string newName)
        {
            buyer = new Buyer(newName);
        }
    }

    public class Receipt
    {
        private Purchase purchase = new Purchase();
        private readonly List<Purchase> purchases = new();
        private Buyer buyer;
        public float TotalAmount { get; private set; }

        public void AddPurchase(Product product, int quantity, string buyerName)
        {
            purchases.Add(new Purchase(product, quantity));
            TotalAmount += product.price * quantity;
            buyer = new Buyer(buyerName);
        }

        public void PrintReceipt()
        {
            Console.WriteLine("***Receipt:***");
            Console.WriteLine($"***Buyer: {buyer.name}***");
            foreach (var purchase in purchases)
            {
                Console.WriteLine($"***Product: {purchase.Product.name}\n Quantity: {purchase.Quantity}, Total Price: {purchase.TotalPrice}");
            }
            Console.WriteLine($"***Total Amount: {TotalAmount}***");
        }
    }

    public class Purchase
    {
        public Product Product { get; }
        public int Quantity { get; }
        public float TotalPrice => Product.price * Quantity;

        public Purchase(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;

        }

        public Purchase()
        {
        }
    }

    public class ShopInterface : Shop
    {
        private Receipt receipt = new Receipt();
        private UserInteraction userInteraction = new UserInteraction();
        Buyer buyer = new Buyer();
        public ShopInterface()
        {

        }
        public void Inteface()
        {
            Console.WriteLine("Enter number");
            Console.WriteLine("1. Buy product");
            Console.WriteLine("2. List of products");
            Console.WriteLine("3. Add products");
            Console.WriteLine("4. Buyer name change");

            int index = int.Parse(Console.ReadLine());

            switch (index)
            {
                case 1:
                    Console.WriteLine("Enter product's name which you want to buy:");
                    string name = Console.ReadLine();
                    Console.WriteLine("Enter product's quantity which you want to buy:");
                    int quantity = int.Parse(Console.ReadLine());
                    BuyProduct(name, quantity);
                    break;
                case 2:
                    ListOfProducts();
                    break;
                case 3:
                    Console.WriteLine("Enter name of product:");
                    string _name = Console.ReadLine();
                    Console.WriteLine("Enter price of product:");
                    float price = float.Parse(Console.ReadLine());
                    Console.WriteLine("Enter quantity of product:");
                    int _quantity = int.Parse(Console.ReadLine());

                    AddProduct(new Product(_name, price), _quantity);
                    break;
                case 4:
                    Console.Write("Enter new buyer's name: ");
                    string newName = Console.ReadLine();
                    UpdateBuyerName(newName);
                    Console.WriteLine($"Buyer's name changed to {buyer.name}");
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
            ShopInterface shopInterface = new ShopInterface();

            while (true)
            {
                shopInterface.Inteface();
            }
        }
    }
}
