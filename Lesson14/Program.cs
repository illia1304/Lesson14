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
            if(answer == "yes")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    public class ProductManeger
    {
        private Dictionary<Product, int> products = new Dictionary<Product, int>();
        private bool wasBought = false;

        public Product GetProductByName(string productName)
            {
            foreach (var product in products.Keys)
            {
               if (product.name == productName)
               {
                    return product;
                }
            }
            return null;
        }
        public bool BuyProduct(Product product, int quantity)
        {
            if (products.TryGetValue(product, out int CurrentQuantity))
            {
                if (CurrentQuantity >= quantity)
                {
                    products[product] = CurrentQuantity - quantity;
                    wasBought = true;
                }
                else
                {
                    Console.WriteLine($"Not enough {product.name} in shop.");
                }
            }
            else
            {
                Console.WriteLine("We haven't that product in our shop");
            }
            return wasBought;
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
            if (quantity < 0)
            {
                Console.WriteLine("Count can't be < 0. Stop trying broke my program. Default quantity 10");
                quantity = 10;
            }
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
    }
    public class RecieptManeger
    {
        public List<Purchase> purchases = new List<Purchase>();
        public Buyer buyer = new();
        ProductManeger productManeger = new ProductManeger();
        public float totalAmount = 0;
        
        public void PrintReciept()
        {
            Console.WriteLine("***Receipt:***");
            Console.WriteLine($"***Buyer: {buyer.name}***");

            totalAmount = 0;
            foreach (var item in purchases)
            {
                Purchase purchase = new(item.Product, item.Quantity);
                Console.WriteLine($"***Product: {item.Product.name}\n Quantity: {item.Quantity}, Total Price: {purchase.TotalPrice}");
                totalAmount += item.Product.price * item.Quantity;
            }
            Console.WriteLine($"***Total Amount: {totalAmount}***");
        }
        public void AddPurchase(Product product, int quantity, string buyerName)
        {
            Purchase purchase = new(product, quantity);
            purchases.Add(purchase);
            totalAmount += purchase.TotalPrice;
            buyer = new Buyer(buyerName);
        }

        public void ClearReciept()
        {
            purchases.Clear();
            totalAmount = 0;
        }

    }
    public class Purchase
    {
        public Product Product { get; }
        public int Quantity { get; }
        public Purchase(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }

        public float TotalPrice => Product.price * Quantity;
    }
    public class ShopInterface
    {
        private ProductManeger productManeger = new();
        private RecieptManeger recieptManeger = new();
        private Buyer buyer = new Buyer();
        private UserInteraction userInteraction = new UserInteraction();
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
                    Product product = productManeger.GetProductByName(name);

                    if (productManeger.BuyProduct(product, quantity))
                    {
                        recieptManeger.AddPurchase(product, quantity, buyer.name);
                    }
                    if (!userInteraction.ContinueShopping())
                    {
                        recieptManeger.PrintReciept();
                        recieptManeger.ClearReciept();
                    }
                    break;
                case 2:
                    productManeger.ListOfProducts();
                    break;
                case 3:
                    Console.WriteLine("Enter name of product:");
                    string _name = Console.ReadLine();
                    Console.WriteLine("Enter price of product:");
                    float price = float.Parse(Console.ReadLine());
                    Console.WriteLine("Enter quantity of product:");
                    int _quantity = int.Parse(Console.ReadLine());
                    productManeger.AddProduct(new Product(_name, price), _quantity);
                    break;
                case 4:
                   Console.Write("Enter new buyer's name: ");
                   string newName = Console.ReadLine();
                   buyer = new Buyer(newName);
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
            ProductManeger productManeger = new ProductManeger();
            RecieptManeger recieptManeger = new RecieptManeger();
            ShopInterface shopInterface = new ShopInterface();

            while (true)
            {
                shopInterface.Inteface();
            }
        }
    }
}
