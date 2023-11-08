namespace Lesson14
{
    public class UserInteraction
    {
        public bool ContinueShopping()
        {
            Console.Write("Do you want to continue shopping? (yes/no)");

            string answer = Console.ReadLine().ToLower();
            if (answer == "yes")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    
}
