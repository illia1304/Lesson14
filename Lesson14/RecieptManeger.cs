namespace Lesson14
{
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
    
}
