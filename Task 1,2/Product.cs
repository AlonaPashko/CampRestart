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

        public virtual void Parse(string line)
        {
            try
            {
                if (IsCanParse(line))
                {
                    string[] array = line.Split(' ');
                    Name = array[0];;
                    if (!double.TryParse(array[1], out weight) || !double.TryParse(array[2], out price))
                    {
                        throw new FormatException();
                    }
                    else
                    {
                        Weight = double.Parse(array[1]);
                        Price = double.Parse(array[2]);
                    }
                }
                else
                {
                    throw new ArgumentException();
                }
            }
            catch (ArgumentException)
            {
                ExceptionHandler ex = new ExceptionHandler();
                ex.WriteExcInfoToFile("ErrorLog.txt");
            }
            catch (FormatException)
            {
                ExceptionHandler ex = new ExceptionHandler();
                ex.WriteExcInfoToFile("ErrorLog.txt");
            }
        }
        public bool IsCanParse(string line)
        {
            if (line == null)
            {
                return false;
            }
            if (line.Split(' ').Length != 3)
            {
                return false;
            }
            return true;
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
            //int res = -1;

            //if (obj as Product == null)
            //{
            //    Console.WriteLine("NULL");
            //    return res;
            //}
            //return this.Name.CompareTo(((Product)obj).Name);
            return (obj as Product)?.Name.CompareTo(this.Name) ?? -1;
        }
        public string CorrectName()
        {
            return char.ToUpper(Name[0]) + Name.Substring(1);
        }

    }
}
