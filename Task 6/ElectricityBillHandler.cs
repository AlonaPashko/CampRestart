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

        int appNo;
        string surname;
        int quarterNo;
        int meterReading;


        public ElectricityBillHandler()
        {
            appNo = 0;
            surname = "Smith";
            quarterNo = 1;
            meterReading = 0;
        }

        public ElectricityBillHandler(int appNo, string surname, int quarterNo, int meterReading)
        {
            this.appNo = appNo;
            this.surname = surname;
            this.quarterNo = quarterNo;
            this.meterReading = meterReading;
        }
        public int AppNo
        {
            get { return this.appNo; }
            set { this.appNo = value; } //there should be a check on the number of apartments in the house
        }
        public string Surname
        {
            get { return this.surname; }
            set
            {
                if (this.surname.Length > 1)//there should also be actions if the surname is given incorrectly
                {
                    this.surname = value;
                }
            }
        }
        public int QuarterNo //the user has the opportunity to view the info for each quarter, changing it himself
        {
            get { return this.quarterNo; }
            set
            {
                if (this.quarterNo > 0 && this.quarterNo < 5)
                {
                    this.quarterNo = value;
                }
            }
        }
        public int MeterReading //the user has the opportunity set his meterReadings
        {
            get { return this.meterReading; }
            set
            {
                if (this.meterReading > 0)
                {
                    this.meterReading = value;
                }
            }
        }
        public override string ToString()
        {
            return "AppNo: " + appNo.ToString() + "|\tSurname: " + surname + "|\tQuarterNo: "
                + quarterNo.ToString() + "|\tMeter Reading: " + meterReading.ToString();
        }
    }
}
