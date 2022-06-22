using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6
{
    internal class ElectricityBillHandler
    {
        const double priceKWh = 0.18; //it is price per kWh in Poland, сurrency - $USA

        List<ElectricityBillHandler> bills;
        int appNo;
        string surname;
        int quarterNo;
        int[] meterReadings;
        string months;

        public ElectricityBillHandler()
        {
            appNo = 0;
            surname = "Smith";
            quarterNo = 1;
            //meterReadings = new int[] { 0, 0, 0 };
        }

        public ElectricityBillHandler(int appNo, string surname, int quarterNo, int month1Readings, int month2Readings, int month3Readings)
        {
            AppNo = appNo;
            Surname = surname;
            QuarterNo = quarterNo;
            meterReadings = SetMeterReadings(month1Readings, month2Readings, month3Readings);
            months = SetMonths();
        }
        public int AppNo
        {
            get { return appNo; }
            set { appNo = value; } //there should be a check on the number of apartments in the house
        }
        public string Surname //there should also be actions if the surname is given incorrectly
        {
            get { return surname; }
            set { surname = value; }

        }
        public int QuarterNo //the user has the opportunity to view the info for each quarter, changing it himself
        {
            get
            {
                if (quarterNo > 0 && quarterNo < 5)
                {
                    return quarterNo;
                }
                else return 1;
            }
            set
            {
                quarterNo = value;
            }
        }

        public string SetMonths()
        {
            switch (quarterNo)
            {
                case 1:
                    months = "January | February | March |";
                    break;
                case 2:
                    months = "April | May | June |";
                    break;
                case 3:
                    months = "July | August | September |";
                    break;
                case 4:
                    months = "October | November | December |";
                    break;
            }
            return months;
        }
        public int[] SetMeterReadings(int month1Reading, int month2Reading, int month3Reading)
        {
            int[] meterReadings = new int[3];
            meterReadings[0] = month1Reading;
            meterReadings[1] = month2Reading;
            meterReadings[2] = month3Reading;
            return meterReadings;
        }
        public override string ToString()
        {
            return " | " + appNo.ToString() + " | " + surname + " | " + PrintMeterReadings()
                + CountPayAmount().ToString() + " | \n";
        }

        public string PrintMeterReadings()
        {
            string meterReadStr = "";
            for (int i = 0; i < meterReadings.Length; i++)
            {
                meterReadStr += meterReadings[i].ToString() + " | ";
            }
            return meterReadStr;
        }
        public double CountPayAmount()
        {
            return (double)((meterReadings[2] - meterReadings[0]) * priceKWh);
        }
        public string PrintHeader()
        {
            return " | No | Owners | " + months + " To pay |";
        }
        public List<ElectricityBillHandler> InitialiseBills()
        {
            bills.Add(new ElectricityBillHandler(1, "Pashko", 2, 3456, 3458, 3620));
            bills.Add(new ElectricityBillHandler(2, "Cherniak", 2, 3456, 3458, 3620));
            bills.Add(new ElectricityBillHandler(3, "Nowak", 2, 3456, 3458, 3620));

            return bills;
        }
    }
}
