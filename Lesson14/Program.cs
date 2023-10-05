using System;
using System.Diagnostics;

namespace Lesson14
{
    public record Product(string name, float price);
    public record Buyer(string BuyerName);

    public class ProductCart
    {
        public Dictionary<Product, int> ProductsInCart { get; set; } = new();

        public float Amount
        {
            
            get{
                float amount = 0;

                foreach (var item in ProductsInCart)
                {
                    amount += item.Key.price * item.Value;
                }
                return amount;
            }

            
        }
    }
    
    public class Shop
    {
        Dictionary<Product, int> products = new();
        ProductCart productCar = new ProductCart();
        

        public Shop()
        {

        }
        public void AddProduct(Product product, int quantity)
        {
            products.Add(product, quantity);
        }
        public void RemoveProduct(Product product)
        {
            products.Remove(product);
        }

        public void SellProducts()
        {
            Console.WriteLine("What product do you want to buy?");
            string s=Console.ReadLine();
            Console.WriteLine("How many items do you want buy?");
            
            int count = int.Parse(Console.ReadLine());

            foreach (var item in products)
            {
                if (products.Equals(s))
                {
                    products[item.Key] -= count;

                    productCar.ProductsInCart[item.Key] = products[item.Key];
                }
            }
        }
        public void ListOfProduct()
        {

        }



        //відповідальність:зберігати товар, продавати, додавати товар, показувати товар, видаляти товар
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
                    SellProducts();
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
        Buyer buyer;
        ProductCart productCart;

        public Recipe()
        {

        }

        public void PrintRecipe() 
        {
            Console.Write($@"RECIPE
{buyer.BuyerName}
{productCart.ProductsInCart.Keys} {productCart.ProductsInCart.Values}
{productCart.Amount}
");
        }
    }


    class Programme
    {
        static void Main(string[] args)
        {
            Shop shop = new Shop();

            Product product = new Product("car", 32);
        }
    }
}