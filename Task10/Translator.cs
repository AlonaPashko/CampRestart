using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task10
{
    internal class Translator
    {
        private Dictionary<string, string> vocabulary;
        private string text;
        private string pathToText;
        private string pathToDictionary;
        private const int attemptsCounter = 3;

        public Translator() : this("Text.txt", "Dictionary.txt") { }
        
        public Translator(string pathToText, string pathToDictionary)
        {
            vocabulary = new Dictionary<string, string>();
            text = "";
            this.pathToText = pathToText;
            this.pathToDictionary = pathToDictionary;
        }

        public Translator(Dictionary<string, string> vocabulary, string text, string pathToText, string pathToDictionary)
        {
            this.vocabulary = vocabulary;
            this.text = text;
            this.pathToText = pathToText;
            this.pathToDictionary = pathToDictionary;
        }
        public void AddText(string text)
        {
            this.text += text;
        }
        public void AddDictionary(Dictionary<string, string> dictionary)
        {
            this.vocabulary = dictionary;
        }

        public string ChangeWords()
        {
            string result = "";
            var words = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            foreach (string word in words)
            {
                char temp = ' ';
                string tempWord = "";
                int i = 0;
                if (Char.IsPunctuation(word[word.Length - 1]))
                {
                    temp = word[word.Length - 1];
                    while (!vocabulary.ContainsKey(word[0..^1]) && i < attemptsCounter)
                    {
                        UserAddToDictionary(word[0..^1]);
                        i++;
                    }
                    tempWord = vocabulary[word[0..^1]] + temp;
                }
                else
                {
                    while (!vocabulary.ContainsKey(word) && i < attemptsCounter)
                    {
                        UserAddToDictionary(word);
                        i++;
                    }
                    tempWord = vocabulary[word];
                }
                result += tempWord + " ";
            }
            return result;
        }
        private void UserAddToDictionary(string word)
        {
            Console.WriteLine($"Enter your replacement word {word}");
            string value = Console.ReadLine();
            vocabulary.Add(word, value);
            Reader.WriteToDictionary(word, value, "Dictionary.txt");
        }
    }
}
