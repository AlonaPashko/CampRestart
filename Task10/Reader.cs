using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task10
{
    internal class Reader
    {
        public static List<string> ReadText(string path)
        {
            List<string> result = new List<string>();
            using (StreamReader reader = new StreamReader(path))
            {
                result.Add(reader.ReadLine());
            }
            return result;
        }
        public static Dictionary<string, string> ReadDictionary(string path)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            if (!File.Exists(path))
            {
                throw new FileNotFoundException("Dictionary isn't found");
            }
            using (StreamReader reader = new StreamReader(path))
            {
                while (!reader.EndOfStream)
                {
                    string temp = reader.ReadLine();
                    try
                    {
                        var str = temp.Split('-');
                        if (str.Length != 2)
                        {
                            throw new ArgumentException("Incorrect key-value pair");
                        }
                        result.Add(str[0], str[1]);
                    }
                    catch (ArgumentException)
                    {
                        throw;
                    }

                }
            }
            return result;
        }
        public static void WriteToDictionary(string key, string value, string path)
        {
            using (StreamWriter writer = File.AppendText(path))
            {
                writer.Write("\n");
                writer.Write($"{key}-{value}");
            }
        }
    }
}
