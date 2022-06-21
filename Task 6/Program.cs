
using Task6;

//TextHandler text1 = new TextHandler("TextFile.txt");

//text1.RemoveExtraSpaces();
//text1.MakeSentence();
//text1.WriteToFile("Result.txt");
//text1.PrintMinMaxWordColl();

TextHandler text2 = new TextHandler("ElectrycityAccounting.txt");
text2.ReadLineFromFile("ElectrycityAccounting.txt");
text2.WriteToFile("Report.txt");

