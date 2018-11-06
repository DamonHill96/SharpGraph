using System;
using System.IO;

namespace SharpGraph
{
    internal static class Logger
    {
        static Logger()
        {
            sr = new StreamWriter(path, true);
        }

        private static readonly string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "log.txt");
        private static readonly StreamWriter sr;
        
        internal static void Log(string message, params object[] obj )
        {
             sr.Write(DateTime.Now + " ");
             sr.Write(message, obj);            
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
