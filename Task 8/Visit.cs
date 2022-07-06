using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Task8
{
    internal class Visit
    {
        private string addressIP;
        private DateTime date;
        private string dayOfWeek;

        public string AddressIP { get; set; }
        public DateTime Date { get; set; }
        public string DayOfWeek { get; set; }

        public Visit() : this("000.00.000.000", default) { }

        public Visit(string addressIP, DateTime date, string dayOfWeek)
        {
            AddressIP = addressIP;
            Date = date;
            DayOfWeek = dayOfWeek;
        }

        public Visit(string addressIP, DateTime date)
        {
            AddressIP = addressIP;
            Date = date;
            ChangeCulture();
            DayOfWeek = date.ToString("dddd");
        }
        public override string ToString()
        {
            return "IP: " + AddressIP + " Time: " + Date.ToString("T") + " " + DayOfWeek;
        }
        public void ChangeCulture()
        {
            CultureInfo.CurrentCulture = new CultureInfo("en-US", false);
        }
        public void Parse(string line)
        {
            string[] array = line.Split(' ');
            AddressIP = array[0];
            Date = DateTime.Parse(array[1]);
            DayOfWeek = array[2];
        }
        public string ReadFromFile(string path)
        {
            string line = "";
            StreamReader reader = new StreamReader(path);
            line += reader.ReadLine();
            reader.Close();
            return line;
        }
    }
}
