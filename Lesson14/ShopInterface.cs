namespace Lesson14
{
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

            try
            {
                int index = int.Parse(Console.ReadLine());

                switch (index)
                {
                    case 1:
                        HandleBuyProduct();
                        break;
                    case 2:
                        HandleListOfProducts();
                        break;
                    case 3:
                        HandleAddProducts();
                        break;
                    case 4:
                        HandleChangeBuyerName();
                        break;
                    default:
                        Console.WriteLine("Invalid value");
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Enter right format of answer and don't try break my program!!!!");
            }
        }

        private void HandleBuyProduct()
        {
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
        }

        private void HandleListOfProducts()
        {
            productManeger.ListOfProducts();
        }

        private void HandleAddProducts()
        {
            Console.WriteLine("Enter name of product:");
            string _name = Console.ReadLine();

            Console.WriteLine("Enter price of product:");
            float price = float.Parse(Console.ReadLine());

            Console.WriteLine("Enter quantity of product:");
            int _quantity = int.Parse(Console.ReadLine());

            productManeger.AddProduct(new Product(_name, price), _quantity);
        }

        private void HandleChangeBuyerName()
        {
            Console.Write("Enter new buyer's name: ");
            string newName = Console.ReadLine();

            buyer = new Buyer(newName);
            Console.WriteLine($"Buyer's name changed to {buyer.name}");
        }

    }
    
}
