using Data_Access.Interfaces;
using System;
using System.IO;

namespace Data_Access.Logger
{
    public class Logger : ILogger
    {
        static string userName = Environment.UserName, path;
        string fileName;

        void ILogger.Add(string message)
        {
            DateTime dateTime = DateTime.Now;
            fileName = dateTime.ToString("yyyy-MM-dd") + ".txt";

            path = "C:/Users/" + userName + "/Documents/logs";

            EnsureDirectoryExists(fileName);

            StreamWriter streamWriter = new StreamWriter(path, true);

            string timeInfo = dateTime.ToString("HH:mm:ss");
            string timeArea = "[" + timeInfo + "]: ";

            streamWriter.WriteLine(timeArea + message);
            streamWriter.Close();
        }
        private static void EnsureDirectoryExists(string filePath)
        {
            FileInfo fi = new FileInfo(filePath);
            if (!fi.Directory.Exists)
            {
                Directory.CreateDirectory(fi.DirectoryName);
            }
        }

    }
}
