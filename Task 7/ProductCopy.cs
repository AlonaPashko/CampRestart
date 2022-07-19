using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task7
{
    public class ProductCopy : IComparable
    {
        private string name;
        private double weight;
        private double price;

        public string Name { get; set; }
        public double Weight { get; set; }
        public double Price { get; set; }

        public ProductCopy() : this(null, 0.0, 0.0) { }
        public ProductCopy(string name, double weight, double price)
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
            return Name.Equals(((ProductCopy)otherProduct).Name) &&
                Weight.Equals(((ProductCopy)otherProduct).Weight) &&
                Price.Equals(((ProductCopy)otherProduct).Price);
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
                    Name = array[0];
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

        public ProductCopy ManualInput()
        {
            Console.WriteLine("Enter your product");
            string userProduct = Console.ReadLine();
            Console.WriteLine("Enter your product's weight");
            double userWeight = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter your price");
            double userPrice = double.Parse(Console.ReadLine());
            return new ProductCopy(userProduct, userWeight, userPrice);
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
            return (obj as ProductCopy)?.Name.CompareTo(this.Name) ?? -1;
        }
        public string CorrectName()
        {
            return char.ToUpper(Name[0]) + Name.Substring(1);
        }

    }

}

