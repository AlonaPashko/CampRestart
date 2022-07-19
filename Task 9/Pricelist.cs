using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task9
{
    internal class Pricelist
    {
        private Dictionary<string, double> productPrice;

        public Dictionary<string, double> ProductPrice;

        public Pricelist()
        {
            ProductPrice = new();
        }
        public Pricelist(Dictionary<string, double> productPrice)
        {
            ProductPrice = productPrice;
        }
        public Pricelist(string path)
        {
            if (File.Exists(path))
            {
                ProductPrice = SetProductPrice(path);
            }
            else
            {
                ProductPrice = new();
            }
        }
        public bool TryGetProductPrice(string productName, out double price)//метод доступу, передаємо назву, отримуємо ціну
        {
            if (!productPrice.TryGetValue(productName, out double result))
            {
                price = default;
                return false;
            }
            price = result;
            return true;
        }
        public override string ToString()
        {
            return PrintDictionary();
        }
        public string PrintDictionary()
        {
            string line = "";
            foreach (KeyValuePair<string, double> product in ProductPrice)
            {
                line += product.Key + " - " + product.Value.ToString() + "\n";
            }
            return line;
        }
        private string ReadFromFile(string path)
        {
            StreamReader reader = new StreamReader(path);
            string line = "";
            while (!reader.EndOfStream)
            {
                line += reader.ReadLine() + "\n";
            }
            reader.Close();
            return line;
        }
        private string ReadOnlyProductsFromFile(string path)
        {
            string line = ReadFromFile(path);
            string[] array = line.Split('\n', StringSplitOptions.TrimEntries);
            string onlyProducts = "";

            for (int i = 0; i < array.Length - 1; i++)
            {
                string[] temp = array[i].Split(" ", StringSplitOptions.TrimEntries);
                onlyProducts += temp[0] + "\n";
            }
            return onlyProducts;
        }
        private double[] ReadOnlyPricesFromFile(string path)
        {
            string line = ReadFromFile(path);
            string[] array = line.Split('\n', StringSplitOptions.TrimEntries);
            double[] onlyPrices = new double[array.Length];

            for (int i = 0; i < array.Length - 1; i++)
            {
                string[] temp = array[i].Split("-", StringSplitOptions.TrimEntries);
                double price = double.Parse(temp[1]);
                onlyPrices[i] = price;
            }
            return onlyPrices;
        }
        
        private Dictionary<string, double> SetProductPrice(string path)
        {
            string keys = ReadOnlyProductsFromFile(path);

            string[] arrKeys = keys.Split("\n");
            double[] arrValues = ReadOnlyPricesFromFile(path);

            Dictionary<string, double> prodPricesFromFile = new Dictionary<string, double>();
            for (int i = 0, j = 0; i < arrKeys.Length - 1; i++, j++)
            {
                prodPricesFromFile.Add(arrKeys[i], arrValues[j]);
            }
            return prodPricesFromFile;
        }
    }
}
