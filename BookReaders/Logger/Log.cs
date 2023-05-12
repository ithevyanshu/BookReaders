using System;
using System.IO;
using System.Text;

namespace NagarroReader.Logger
{
    public sealed class Log : ILog
    {
        private static readonly object _lock = new object();
        private static Log _instance;

        public Log()
        {

        }

        public static Log GetInstance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new Log();
                    }

                    return _instance;
                }
            }
        }

        public void LogException(string message)
        {
            string fileName = string.Format("{0}{1}.log","Exception", DateTime.Now.ToShortDateString());
            string logFilePath = string.Format(@"{0}\{1}", AppDomain.CurrentDomain.BaseDirectory, fileName);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("---------------------------------------------------------------------");
            sb.AppendLine(DateTime.Now.ToString());
            sb.AppendLine(message);
            using (StreamWriter writer = new StreamWriter(logFilePath, true))
            {
                writer.Write(sb.ToString());
                writer.Flush();
            }
        }
    }
}