using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1And2
{
    internal static class StorageComparer
    {
        public static Storage CommonStorage(Storage storage1, Storage storage2)
        {
            SortedSet<Product> set1 = new SortedSet<Product>(storage1.Products);
            SortedSet<Product> set2 = new SortedSet<Product>(storage2.Products);

            Storage commonStorage = new Storage();
            commonStorage.Products = set1.Union(set2).ToList();
            return commonStorage;
        }
        public static Storage FindCommonGoods(Storage storage1, Storage storage2)
        {
            SortedSet<Product> set1 = new SortedSet<Product>(storage1.Products);
            SortedSet<Product> set2 = new SortedSet<Product>(storage2.Products);

            Storage commonStorage = new Storage();
            set1.IntersectWith(set2);

            commonStorage.Products = set1.ToList();
            return commonStorage;
        }
        public static Storage FindExceptGoods(Storage storage1, Storage storage2)
        {
            SortedSet<Product> set1 = new SortedSet<Product>(storage1.Products);
            SortedSet<Product> set2 = new SortedSet<Product>(storage2.Products);

            Storage commonStorage = new Storage();
            set1.ExceptWith(set2);

            commonStorage.Products = set1.ToList();
            return commonStorage;
        }
    }
}
