namespace Lesson14
{
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
    
}
