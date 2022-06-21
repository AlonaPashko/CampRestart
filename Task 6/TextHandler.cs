using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Task6
{
    internal class TextHandler
    {
        List<string> strings = new List<string>();
        
        public List<string> Strings
        {
            get { return strings; }
            set { strings = value; }
        }

        string line = "";

        public TextHandler(string fileName)
        {
            try
            {
                StreamReader reader = new StreamReader(fileName);
                line += reader.ReadToEnd();
                reader.Close();
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("File not found");
            }
        }
        public override string ToString()
        {
            line = line.Trim();
            return line;
        }

        public void ReadLineFromFile(string filePath)
        {
            StreamReader reader = new StreamReader(filePath);
            while(reader.Peek() >= 0)
            {
                strings.Add(reader.ReadLine());
            }
        }
        
        public List<string> MakeSentence() 
        {
            string[] array = Regex.Split(line, @"(?<=[\.!\?])\s+");
            for (int i = 0; i < array.Length; i++)
            {
                strings.Add(array[i]);
            }
            return strings;
        }
        public List<string> MakeWords()
        {
            string[] array = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < array.Length; i++)
            {
                strings.Add(array[i]);
            }
            return strings;
        }
        public void WriteToFile(string filePath)
        {
            StreamWriter writer = new StreamWriter(filePath);
            if (!File.Exists(filePath))
            {
                File.Create(filePath);
            }
            for (int i = 0; i < strings.Count; i++)
            {
                writer.WriteLine(strings[i]);
            }
            writer.Close();
        }

        public string RemoveExtraSpaces()
        {
            line = line.Trim();
            StringBuilder stringBuilder = new StringBuilder("");
            
            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] == ' ' && line[i + 1] == ' ')
                {
                    continue;
                }
                stringBuilder.Append(line[i]);
            }
            line = stringBuilder.ToString();
            return line;
        }
        public string MakeWordCollection(int index)
        {
            string sentence = strings[index];
            return sentence;
        }
        public void FindMinMaxWord(string sentence)
        {
            sentence = sentence.Trim();
            string[] words = sentence.Split(' ');

            int min = words[0].Length;
            int max = words[0].Length;

            string minWord = words[0];
            string maxWord = words[0];

            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Length < min)
                {
                    minWord = words[i];
                    min = words[i].Length;
                }
                if (words[i].Length > max)
                {
                    maxWord = words[i];
                    max = words[i].Length;
                }
            }
            Console.WriteLine("The longest word in sentence: " + maxWord + '\n' +
                "The shortest word in sentence: " + minWord);
        }
        public void PrintMinMaxWordColl()
        {
            for (int i = 0; i < strings.Count; i++)
            {
                string temp = strings[i];
                Console.WriteLine();
                FindMinMaxWord(temp);
            }
        }
        
        //public string InsertMonth(string line)
        //{
        //    string[] array = line.Split(' ');
        //    StringBuilder strBuider = new StringBuilder(line);

        //}
    }
}
