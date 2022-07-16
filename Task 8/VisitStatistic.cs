using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task8
{
    internal class VisitStatistic
    {
        private List<Visit> visits;

        public List<Visit> Visits { get; set; }

        public VisitStatistic()
        {
            Visits = new List<Visit> { new Visit() };
        }
      
        public VisitStatistic(string path)
        {
            StreamReader reader = new StreamReader(path);
            string line = "" + reader.ReadToEnd();
            reader.Close();

            string[] array = line.Split('\n');
            Visits = SetVisits(array);
        }
       
        public override string ToString()
        {
            return StringVisits();
        }
        private string StringVisits()
        {
            string line = "";
            for (int i = 0; i < Visits.Count; i++)
            {
                line += Visits[i] + "\n";
            }
            return line;
        }
        private List<Visit> SetVisits(string[] array)
        {
            List<Visit> visits = new List<Visit>();
            for (int i = 0; i < array.Length; i++)
            {
                Visit visit = new Visit();
                visit.Parse(array[i]);
                visits.Add(visit);
            }
            return visits;
        }
        private List<string> GetIP()
        {
            List<string> strList = new List<string>();

            foreach (Visit visit in Visits)
            {
                strList.Add(visit.AddressIP);
            }
            return strList;
        }
        public List<string> GetDay()
        {
            List<string> strList = new List<string>();

            foreach (Visit visit in Visits)
            {
                strList.Add(visit.DayOfWeek);
            }
            return strList;
        }
        private Dictionary<string, int> GetQuantity(List<string> items)
        {
            Dictionary<string, int> quantity = new Dictionary<string, int>();

            foreach (string str in items)
            {
                if (quantity.ContainsKey(str))
                {
                    quantity[str]++;
                }
                else
                {
                    quantity.Add(str, 1);
                }
            }
            return quantity;
        }
        public string GetQuantityIP()
        {
            Dictionary<string, int> dictForPrint = new Dictionary<string, int>();
            dictForPrint = GetQuantity(GetIP());
            string line = "";

            foreach (KeyValuePair<string, int> kvp in dictForPrint)
            {
                line += "IP: " + kvp.Key + " Quantity: " + kvp.Value + '\n';
            }
            return line;
        }
        public int FindMaxValue(Dictionary<string, int> dict)
        {
            int maxValue = 0;

            foreach (KeyValuePair<string, int> kvp in dict)
            {
                if (kvp.Value > maxValue)
                {
                    maxValue = kvp.Value;
                }
            }
            return maxValue;
        }
        public string MostPopularDay()
        {
            Dictionary<string, int> dict = GetQuantity(GetDay());
            int quantity = FindMaxValue(dict);
            string result = "";

            foreach(KeyValuePair<string, int> kvp in dict)
            {
                if (quantity == kvp.Value)
                {
                    result = kvp.Key;
                }
            }
            return result;
        }
        private List<Visit> MakeListOfVisits(string userIP)
        {
            List<Visit> visitsForOneIP = new List<Visit>();
            for (int i = 0; i < Visits.Count; i++)
            {
                if (Visits[i].AddressIP == userIP)
                {
                    visitsForOneIP.Add(Visits[i]);
                }
            }
            return visitsForOneIP;
        }
        public VisitStatistic MakeStatisticForOneIP(string userIP)
        {
            VisitStatistic visitsForOneIP = new VisitStatistic();
            visitsForOneIP.Visits = MakeListOfVisits(userIP);
            return visitsForOneIP;
        }
       
    }
}
