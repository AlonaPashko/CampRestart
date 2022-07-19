using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task9
{
    internal class Dish
    {
        private Dictionary<string, double> ingridients;
        private string name;

        public Dictionary<string, double> Ingridients;
        public string Name;

        public int Length
        {
            get { return Ingridients.Count; }
        }

        public double this[string key]
        {
            get
            {
                return Ingridients[key];
            }
        }
        public IEnumerable<string> Keys
        {
            get { return Ingridients.Keys; }
        }

        public Dish()
        {
            Ingridients = new();
        }
        
        public Dish(Dictionary<string, double> ingridients)
        {
            Ingridients = ingridients;
        }
        public override string ToString()
        {
            return Name;
        }

    }
}
