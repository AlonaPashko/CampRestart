
using Task10;

Dictionary<string, string> dictionary1;
List<string> text1;

try
{
    text1 = Reader.ReadText("Text.txt");
    dictionary1 = Reader.ReadDictionary("Dictionary.txt");
    Translator translator1 = new Translator();
    translator1.AddDictionary(dictionary1);

    foreach(string i in text1)
    {
        translator1.AddText(i);
    }

    string changeText = translator1.ChangeWords();
    Console.WriteLine(changeText);
}
catch (FileNotFoundException) 
{
    Console.WriteLine("File not found exception");
}
catch (ArgumentException) 
{
    Console.WriteLine("Argument exception");
}
catch (WordNotFoundException e)
{

}