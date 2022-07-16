using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopProject
{
    public class CheckDecor : IViewerBuy
    {
        public void ViewerBuy(Buy buy)
        {
            Console.WriteLine("*********\n" + buy + "\n**********");
        }
    }
}
