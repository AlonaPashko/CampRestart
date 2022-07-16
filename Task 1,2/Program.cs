
using Task_1_2;
using Task1And2;

//Buy buyer1 = new Buy("Product3", 1, 12.4, 13.2);

//IViewerBuy viewerBuy = new Check();
//viewerBuy.ViewerBuy(buyer1);

//viewerBuy = new CheckDecor();
//viewerBuy.ViewerBuy(buyer1);

//Product product1 = new Product("Milk", 3.9, 4.5);
//Product product2 = new Product("Chokolade", 1.2, 5.5f);

//Console.WriteLine(product2.CompareTo(product1));

//List<Product> products = new List<Product>()
//{
//    new Product("Apple", 2.1, 3.2),
//    new Product("Bubble", 0.1, 18.2),
//    new Product("Iron", 2.4, 8.2),
//    new Product("Melon", 3.7, 2.1),
//};
//foreach (Product product in products)
//{
//    Console.WriteLine(product);
//}

//products.Sort();
//Console.WriteLine("********");

//foreach (Product product in products)
//{
//    Console.WriteLine(product);
//}

//CompareByPrice comparePrice = new CompareByPrice();

//products.Sort(comparePrice);

//Console.WriteLine("********");

//foreach (Product product in products)
//{
//    Console.WriteLine(product);
//}
Storage storage1 = new Storage();
Storage storage2 = new Storage();

List<Product> prodStorage1 = new List<Product>()
{
    new Product("pr01", 0.2, 1.0),
    new Product("pr02", 2.2, 1.2),
    new Product("pr03", 0.9, 2.5),
    new Product("pr04", 3.2, 3.4),
    new Product("pr05", 2.9, 2.5),
    new Product("pr06", 1.5, 5.7),
    new Product("pr010", 1.5, 5.7),
    new Product("pr013", 18.9, 28.3),
};

List<Product> prodStorage2 = new List<Product>()
{
    new Product("pr07", 0.2, 1.0),
    new Product("pr07", 0.2, 1.0),
    new Product("pr07", 0.2, 1.0),
    new Product("pr010", 1.5, 5.7),
    new Product("pr011", 2.0, 18.6),
    new Product("pr012", 2.6, 7.8),
    new Product("pr013", 18.9, 28.3),
    new Product("pr014", 3.5, 9.7),
};

storage1.Products = prodStorage1;
storage2.Products = prodStorage2;

Console.WriteLine(storage1);
Console.WriteLine(storage2);

Storage storage3 = StorageComparer.CommonStorage(storage1, storage2);
Console.WriteLine(storage3);

Storage storage4 = StorageComparer.FindCommonGoods(storage1, storage2);
Console.WriteLine(storage4);

Storage storage5 = StorageComparer.FindExceptGoods(storage1, storage2);
Console.WriteLine(storage5);







