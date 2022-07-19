
using Task7;


List<ProductCopy> products = new List<ProductCopy>();
products.Add(new ProductCopy("Banan", 3.4, 2.5));
products.Add(new ProductCopy("Lemon", 1.1, 3.2));
products.Add(new ProductCopy("Melon", 2.4, 2.7));

StorageCopy storage = new StorageCopy();
storage = storage.MakeStorageFromFile();


Console.WriteLine(storage);

