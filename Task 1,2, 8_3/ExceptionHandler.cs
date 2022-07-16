using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopProject
{
    internal class ExceptionHandler
    {
        private string PrintExceptionMessage()
        {
            return "Uncorrect date for reading. Check in|" + PrintDate();
        }
        public void WriteExcInfoToFile(string path)
        {
            using (StreamWriter writer = File.AppendText(path))
            writer.WriteLine(PrintExceptionMessage());
        }
        private string PrintDate()
        {
            DateTime date = DateTime.Now;
            return date.ToString("g");
        }
    }
}
