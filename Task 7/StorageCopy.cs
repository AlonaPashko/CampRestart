using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task7
{
    internal class StorageCopy
    {
        private int productsAmount;
        private double totalWeight;
        private double totalPrice;
        private List<ProductCopy> products;

        public int ProductsAmount { get; set; }
        public double TotalWeight { get; set; }
        public double TotalPrice { get; set; }
        public List<ProductCopy> Products;


        public StorageCopy() : this(new List<ProductCopy> { new ProductCopy() }) { }

        public StorageCopy(List<ProductCopy> products)
        {
            Products = products;
            ProductsAmount = Products.Count();
            TotalWeight = SetTotalWeight();
            TotalPrice = SetTotalPrice();

        }
        private double SetTotalWeight()
        {
            double totalWeight = 0.0;
            foreach (ProductCopy product in Products)
            {
                totalWeight += product.Weight;
            }
            return totalWeight;
        }
        private double SetTotalPrice()
        {
            double totalPrice = 0.0;
            foreach (ProductCopy product in Products)
            {
                totalPrice += product.Price;
            }
            return totalPrice;
        }

        public override string ToString()
        {
            return string.Format("Amount: " + ProductsAmount + " Total Weight: " + TotalWeight +
                " Total Price: " + TotalPrice) + "\n" + PrintList();
        }
        public override bool Equals(object? otherStorage)
        {
            return ProductsAmount.Equals(((StorageCopy)otherStorage).ProductsAmount) &&
                TotalWeight.Equals(((StorageCopy)otherStorage).TotalWeight) &&
                TotalPrice.Equals(((StorageCopy)otherStorage).TotalPrice);
        }

        public void Initialization(string name, double weight, double price)
        {
            ProductCopy product = new ProductCopy(name, price, weight);
        }

        public string PrintList()
        {
            string line = "";
            foreach (ProductCopy product in Products)
            {
                line += product + "\n";
            }
            return line;
        }

        public void ChangePrice(int rate)
        {
            for (int i = 0; i < Products.Count; i++)
            {
                Products[i].Price = (double)Products[i].Price + (Products[i].Price * rate / 100);
            }
        }
        public ProductCopy this[int index]
        {
            get
            {
                if (index >= 0 && index < Products.Count)
                {
                    return Products[index];
                }
                else throw new ArgumentOutOfRangeException();
            }
            set
            {
                if (index >= 0 && index < Products.Count)
                {
                    Products[index] = value;
                }
                else throw new ArgumentOutOfRangeException();
            }
        }

        public void Parse(string str)//parse string into class fields
        {
            string[] array = str.Split(' ');
            productsAmount = int.Parse(array[0]);
            TotalWeight = double.Parse(array[1]);
            TotalPrice = double.Parse(array[2]);
        }

        public string ReadFromFile(string path)
        {
            string line = "";
            StreamReader reader = new StreamReader(path);
            line += reader.ReadToEnd();
            reader.Close();
            return line;
        }
        public string ReadFromFileWithAttempts()
        {
            int attempts = 0;
            while (true)
            {
                if (attempts >= 3)
                {
                    throw new FileNotFoundException();
                }
                Console.WriteLine("Please, write the path of file: ");
                string path = Console.ReadLine();

                if (!IsFileExists(path))
                {
                    attempts++;
                }
                else
                {
                    return ReadFromFile(path);
                }
            }
        }

        public List<ProductCopy> MakeCollFromFile() //if met the product with Price or Weight = 0, system doesn`t add to coll 
        {
            string line = ReadFromFileWithAttempts();
            string[] array = line.Split('\n');
            List<ProductCopy> productsList = new List<ProductCopy>();
            for (int i = 0; i < array.Length; i++)
            {
                ProductCopy product = new ProductCopy();
                product.Parse(array[i]);
                if (IsCorrectProduct(product))
                {
                    product.Name = product.CorrectName();
                    productsList.Add(product);
                }
            }
            return productsList;
        }

        public StorageCopy MakeStorageFromFile()
        {
            StorageCopy storage = new StorageCopy(MakeCollFromFile());

            return storage;
        }

        public bool IsFileExists(string path)
        {
            if (!File.Exists(path))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool IsCorrectProduct(ProductCopy product)
        {
            if (product.Weight != 0 && product.Price != 0)
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





