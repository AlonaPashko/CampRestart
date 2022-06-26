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
        List<ElectricityBillHandler> bills;

        public ElectricityReport()
        {
            Appartments = 0;
            QuarterNo = 1;
            months = SetMonths();
            bills = new List<ElectricityBillHandler> { new ElectricityBillHandler() };
        }
        public ElectricityReport(int appartments, int quaterNo)
        {
            Appartments = appartments;
            QuarterNo = quaterNo;
            months = SetMonths();
            bills = SetBills();
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

        private List<ElectricityBillHandler> SetBills()
        {

        }

        public string PrintHeader()
        {
            return "----------------------------------------------------------" +
                "\n | No | Owners: " + appartments + " | QuarterNo: " + quarterNo + "\t\t | To pay |\n" +
                "----------------------------------------------------------" +
                "\n\t\t" + months + "\t\t\n" +
                 "----------------------------------------------------------";
        }
        public string PrintBills()
        {
            string line = "";
            foreach (ElectricityBillHandler bill in bills)
            {
                line += bill + "\n"; 
            }
            return line;
        }
        
        public override string ToString()
        {
            return PrintHeader() + '\n' + PrintBills();
        }
    }
}
