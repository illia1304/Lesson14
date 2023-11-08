using System;
using System.Collections.Generic;
using System.Linq;

namespace Lesson14
{
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
