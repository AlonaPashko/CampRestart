using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopProject
{
    public class Check : IPrint
    {
        public static void ClientInform(Buy buy)
        {
            Console.WriteLine(buy);
        }
        public static void CheckProduct(Product product)
        {
            Console.WriteLine(product);
        }
        public void ViewerBuy(Buy buy) 
        {
            Console.WriteLine(buy);
        }

        public void Print()
        {
            Console.WriteLine("Check");
        }
    }
}
