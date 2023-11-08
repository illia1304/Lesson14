namespace Lesson14
{
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
    
}
