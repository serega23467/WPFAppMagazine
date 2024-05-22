using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFAppMagazine
{
    public static class Debugger
    {
        private static string filePath = Directory.GetCurrentDirectory() + "\\" + "logs.txt";
        public static void Log(string text)
        {
            using (StreamWriter sw = File.AppendText(filePath))
            {
                sw.WriteLine(DateTime.Now + ": " + text);
            }
        }
    }
}
