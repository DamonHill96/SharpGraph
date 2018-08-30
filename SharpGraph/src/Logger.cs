using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpGraph.src
{
    public static class Logger
    {
        static Logger()
        {
            sr = new StreamWriter(path, true);
        }

        private static string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "log.txt");
        private static StreamWriter sr;
        
        internal static void Log(string message, params object[] obj )
        {
             sr.Write(String.Format(message,obj));            
        }

        public static void ClearLogFile()
        {
            File.Create(path);
        }

        internal static void Close()
        {
            sr.Close();
        }
    }
}
