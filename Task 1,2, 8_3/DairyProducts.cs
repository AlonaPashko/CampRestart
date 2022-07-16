using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopProject
{
    internal class DairyProducts : Product
    {
        public DateTime ExpirationDate { get; set; }
        
        public DairyProducts() : this(null, 0.0, default(DateTime), 0.0) { }
        public DairyProducts(string name, double weight, DateTime expirationDate, double price)
            : base(name, weight, price)
        {
            ExpirationDate = expirationDate;
        }
        public override string ToString()
        {
            return base.ToString() + " Date of expiration: " + ExpirationDate;
        }
        public override bool Equals(object otherDairyProducts)
        {
            return Name.Equals(((DairyProducts)otherDairyProducts).Name) &&
                Weight.Equals(((DairyProducts)otherDairyProducts).Weight) &&
                ExpirationDate.Equals(((DairyProducts)otherDairyProducts).ExpirationDate) &&
                Price.Equals(((DairyProducts)otherDairyProducts).Price);
        }

        public override double ChangePrice(int rate)
        {
            Price = Price + (double)(Price * rate / 100.0);
            return Price;
        }
       
        public override void Parse(string str)
        {
            base.Parse(str);
            string dateString = null;
            DateTime.Parse(dateString);
        }

    }
   
}
