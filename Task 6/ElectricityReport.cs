using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6
{
    internal class ElectricityReport
    {
        int appartments;
        int quarterNo;
        string months;
        List<ElectricityBill> bills;

        public ElectricityReport()
        {
            Appartments = 1;
            QuarterNo = 1;
            months = SetMonths();
            bills = new List<ElectricityBill> { new ElectricityBill() };
        }
        public ElectricityReport(int appartments, int quaterNo)
        {
            Appartments = appartments;
            QuarterNo = quaterNo;
            months = SetMonths();
            bills = new List<ElectricityBill> { new ElectricityBill(1, "Pashko", 3250, 3340, 3520),
                new ElectricityBill(2, "Cherniak", 2390, 2489, 2532) };
        }
        public ElectricityReport(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException("File not found");
            }
            else
            {
                StreamReader reader = new StreamReader(path);
                string line1 = "" + reader.ReadLine();
                string line2 = "" + reader.ReadToEnd();
                reader.Close();

                string[] array1 = line1.Split(' ');
                string[] array2 = line2.Split('\n');

                Appartments = int.Parse(array1[0]);
                QuarterNo = int.Parse(array1[1]);
                months = SetMonths();

                bills = SetBills(array2);
            }
        }

        public int Appartments
        {
            get { return appartments; }
            set
            {
                if (value <= 0)
                {
                    appartments = 1;
                }
                else
                {
                    appartments = value;
                }
            }
        }
        public int QuarterNo
        {
            get { return quarterNo; }
            set
            {
                if (value <= 0 || value > 4)
                {
                    quarterNo = 1;
                }
                else
                {
                    quarterNo = value;
                }
            }
        }

        private string SetMonths()
        {
            switch (quarterNo)
            {
                case 1:
                    months = " | January | February | March |";
                    break;
                case 2:
                    months = " | April | May | June |";
                    break;
                case 3:
                    months = " | July | August | September |";
                    break;
                case 4:
                    months = " | October | November | December |";
                    break;
            }
            return months;
        }

        private List<ElectricityBill> SetBills(string[] array)
        {
            List<ElectricityBill> bills = new List<ElectricityBill>();
            for (int i = 0; i < array.Length; i++)
            {
                ElectricityBill bill = new ElectricityBill();
                bill.Parse(array[i]);
                bills.Add(bill);
            }
            return bills;
        }
        
        public string PrintHeader()
        {
            return "----------------------------------------------------------\n" +
                "| No | Owners: " + appartments + " | QuarterNo: " + quarterNo + "\t\t | To pay |\n" +
                "---------------------------------------------------------- \n" +
                "\t\t" + months + "\t\t\n" +
                 "----------------------------------------------------------\n";
        }
        public string PrintBills()
        {
            string line = "";
            for (int i = 0; i < bills.Count; i++)
            {
                line += bills[i] + "\n";
            }
            return line;
        }

        public override string ToString()
        {
            return PrintHeader() + '\n' + PrintBills();
        }

        private string[] MakeArrayToWrite()
        {
            string header = PrintHeader();
            string bills = PrintBills();
            string result = header + bills;

            string[] strArray = result.Split('\n');
            return strArray;
        }

        public void WriteToFile(string path)
        {
            StreamWriter writer = new StreamWriter(path);
            string[] array = MakeArrayToWrite();
            for (int i = 0; i < array.Length; i++)
            {
                writer.WriteLine(array[i]);
            }
            writer.Close();
        }
       
    }
}
