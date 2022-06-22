
using Task6;

//TextHandler text1 = new TextHandler("TextFile.txt");

//text1.RemoveExtraSpaces();
//text1.MakeSentence();
//text1.WriteToFile("Result.txt");
//text1.PrintMinMaxWordColl();

ElectricityBillHandler elBill = new ElectricityBillHandler(1, "Pashko", 2, 3489, 3586, 3760);
Console.WriteLine(elBill.PrintHeader());
Console.WriteLine(elBill);

