using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1And2
{
    public class Product : IComparable
    {
        private string name;
        private double weight;
        private double price;
        
        public string Name { get; set; }
        public double Weight { get; set; }
        public double Price { get; set; }

        public Product() : this(null, 0.0, 0.0) { }
        public Product(string name, double weight, double price)
        {
            Name = name;
            Price = price;
            Weight = weight;
        }
        public override string ToString()
        {
            return string.Format("Name: " + Name + " Weight: " + Weight
                + " Price: " + Price);
        }
        public override bool Equals(object? otherProduct)
        {
            return Name.Equals(((Product)otherProduct).Name) &&
                Weight.Equals(((Product)otherProduct).Weight) &&
                Price.Equals(((Product)otherProduct).Price);
        }

        public virtual double ChangePrice(int rate)
        {
            Price = (double)(Price * rate / 100.0);
            return Price;
        }
        
        public virtual void Parse(string str)
        {
            if (str == null || str.Split(' ').Length != 3)
            {
                throw new ArgumentException("Wrong string!");
            }
            string[] arrayStr = str.Split(' ');
            Name = arrayStr[0];
            
            if (!(double.TryParse(arrayStr[1], out weight)))
            {
                throw new ArgumentException();
            }
            if (!(double.TryParse(arrayStr[2], out price)))
            {
                throw new ArgumentException();
            }
        }
        public Product ManualInput()
        {
            Console.WriteLine("Enter your product");
            string userProduct = Console.ReadLine();
            Console.WriteLine("Enter your product's weight");
            double userWeight = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter your price");
            double userPrice = double.Parse(Console.ReadLine());
            return new Product(userProduct, userWeight, userPrice);
        }

        public int CompareTo(object? obj)
        {
            int res = -1;

            //if (obj as Product == null)
            //{
            //    Console.WriteLine("NULL");
            //    return res;
            //}
            //return this.Name.CompareTo(((Product)obj).Name);
            return (obj as Product)?.Name.CompareTo(this.Name) ?? -1;
        }
    }
}
