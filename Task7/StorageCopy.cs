using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1And2
{
    internal class StorageCopy
    {
        private int productsAmount;
        private double totalWeight;
        private double totalPrice;
        private Product[] allProducts; //delete it (and its methods) when class have completely switched to the list
        private List<Product> products;


        public int ProductsAmount { get; set; }
        public double TotalWeight { get; set; }
        public double TotalPrice { get; set; }
        
        public StorageCopy() : this(0, 0.0, 0.0) { }
        public StorageCopy(int productsAmount, double totalWeight, double totalPrice)
        {
            ProductsAmount = productsAmount;
            TotalWeight = totalWeight;
            TotalPrice = totalPrice;
            products = new List<Product>();
            allProducts = new Product[productsAmount];
        }
        public override string ToString()
        {
            return string.Format("Amount: " + ProductsAmount + " Total Weight: " + TotalWeight +
                " Total Price: " + TotalPrice);
        }
        public override bool Equals(object? otherStorage)
        {
            return ProductsAmount.Equals(((StorageCopy)otherStorage).ProductsAmount) &&
                TotalWeight.Equals(((StorageCopy)otherStorage).TotalWeight) &&
                TotalPrice.Equals(((StorageCopy)otherStorage).TotalPrice);
        }

        public void Initialization(string name, double weight, double price)
        {
            Product product = new Product(name, price, weight);
        }
        public string Print(Product[] products)
        {
            string line = "";
            for (int i = 0; i < products.Length; i++)
            {
                line += (products[i].ToString() + "\n");
            }
            return line;
        }
        public Product[] AddProductToArray(Product product)
        {
            Product[] temp = new Product[allProducts.Length + 1];
            temp[temp.Length - 1] = product;
            allProducts = temp;
            return allProducts;
        }
        public List<Product> AddProduct(Product product)
        {
            products.Add(product);
            return products;
        }
        
        public void ChangePrice(Product[] products, int rate)
        {
            for (int i = 0; i < products.Length; i++)
            {
                products[i].Price = (double)products[i].Price + (products[i].Price * rate / 100);
            }
        }
        public Product this[int index]//indecsator for array of Products
        {
            get 
            { if (index >= 0 && index < allProducts.Length)
                {
                    return allProducts[index];
                }
                else throw new ArgumentOutOfRangeException();
            }
            set 
            { if (index >= 0 && index < allProducts.Length)
                {
                    allProducts[index] = value;
                }
                else throw new ArgumentOutOfRangeException();
            }
        }
       
        public void Parse(string str)//parse string into class fields
        {
            if (str == null)
            {
                throw new ArgumentNullException();
            }
            string[] arrayStr = str.Split(' ');
            
            if (!(int.TryParse(arrayStr[0], out productsAmount)))
            {
                throw new ArgumentException();
            }
            if (!(double.TryParse(arrayStr[1], out totalWeight)))
            {
                throw new ArgumentException();
            }
            if (!(double.TryParse(arrayStr[2], out totalPrice)))
            {
                throw new ArgumentException();
            }
        }

        public void AddStorageFromFile(string path)
        {

        }
    }
}
