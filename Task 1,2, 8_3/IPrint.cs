using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopProject
{
    internal interface IPrint : IViewerBuy
    {
        void Print();
    }
}
