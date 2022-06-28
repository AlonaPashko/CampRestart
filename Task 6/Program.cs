
using Task6;

//TextHandler text1 = new TextHandler("TextFile.txt");

//text1.RemoveExtraSpaces();
//text1.MakeSentence();
//text1.WriteToFile("Result.txt");
//text1.PrintMinMaxWordColl();

ElectricityReport elReport = new ElectricityReport("ElectrycityAccounting.txt");
elReport.WriteToFile("ElectrycityReport.txt");

Console.WriteLine(elReport.PrintOneBill("Bonn"));
Console.WriteLine(elReport.PrintOneBill(1));
Console.WriteLine(elReport.PrintOneBill("Non-existed surname"));

Console.WriteLine(elReport.LargestDebt() + " has a largest debt.");
Console.WriteLine();

Console.WriteLine("Apartment in which no electricity was used - " + elReport.ZeroDebt());
Console.WriteLine();

Console.WriteLine("Days since last meter reading: " + elReport.DaysSinceLastMeterReading());



