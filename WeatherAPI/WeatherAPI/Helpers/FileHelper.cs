namespace WeatherAPI.Helpers
{
    using System;
    using System.Configuration;
    using System.IO;

    public static class FileHelper
    {
        /// <summary>
        /// Creates a json file to save stream 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="fileUrl"></param>
        /// <param name="fileName"></param>
        public static string SaveFile(Stream data, string fileUrl, string fileName)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(fileUrl);

            var path = Directory.CreateDirectory($"{directoryInfo.Parent.FullName}\\{ConfigurationManager.AppSettings["OutputFolderName"]}\\{DateTime.Now.Date.ToString("dd-MM-yyyy")}");

            using (var fileStream = File.Create(path.FullName + "\\" + fileName + ".json"))
            {
                data.Seek(0, SeekOrigin.Begin);
                data.CopyTo(fileStream);
                fileStream.Close();
            }
            return path.FullName;
        }

    }
}