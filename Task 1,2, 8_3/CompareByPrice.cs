using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopProject
{
    internal class CompareByPrice : IComparer<Product>
    {
        //public int Compare(object? x, object? y)
        //{
        //   return (x as Product).Price.CompareTo((y as Product).Price);
        //}
        public int Compare(Product? x, Product? y)
        {
            return x.Price.CompareTo(y.Price);
        }
    }
}
