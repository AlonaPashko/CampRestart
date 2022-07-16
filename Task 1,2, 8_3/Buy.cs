using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopProject
{
    public class Buy
    {
        private string name;
        private int boughtNumber;
        private double boughtWeight;
        private double boughtPrice;

        public string Name { get; set; }
        public int BoughtNumber { get; set; }
        public double BoughtWeight { get; set; }
        public double BoughtPrice { get; set; }

        public Buy() : this(null, 0, 0.0, 0.0) { }

        public Buy(string name, int boughtNumber, double boughtWeight, double boughtPrice)
        {
            Name = name;
            BoughtNumber = boughtNumber;
            BoughtWeight = boughtWeight;
            BoughtPrice = boughtPrice;
        }
        public override string ToString()
        {
            return string.Format("Goods: " + Name + " "+ BoughtNumber + " Weight: " + BoughtWeight +
                " Price: " + BoughtPrice);
        }
        public override bool Equals(object? otherBuy)
        {
            return Name.Equals(((Buy)otherBuy).Name)&&
                BoughtNumber.Equals(((Buy)otherBuy).BoughtNumber) &&
                BoughtWeight.Equals(((Buy)otherBuy).BoughtWeight) &&
                BoughtPrice.Equals(((Buy)otherBuy).BoughtPrice);
        }

        public void Parse(string str)
        {
            if (str == null)
            {
                throw new ArgumentNullException();
            }
            string[] arrayStr = str.Split(' ');
            if (!(int.TryParse(arrayStr[0], out boughtNumber)))
            {
                throw new ArgumentException();
            }
            if (!(double.TryParse(arrayStr[1], out boughtWeight)))
            {
                throw new ArgumentException();
            }
            if (!(double.TryParse(arrayStr[2], out boughtPrice)))
            {
                throw new ArgumentException();
            }
        }
        
        
    }
}
