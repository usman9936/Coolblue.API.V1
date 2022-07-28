using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Coolblue.API.Helper
{
    public static class JsonFileReadingHelper
    {
        public static string ReadJsonFile(string filePath)
        {
            var rootPath = System.AppDomain.CurrentDomain.BaseDirectory; //get the root path
            var fullPath = Path.Combine(rootPath, filePath); //combine the root path with that of our json file inside Resources directory
            var fileContent = System.IO.File.ReadAllText(fullPath); //read all the content inside the file
            if (string.IsNullOrWhiteSpace(fileContent))//if no data is present then return null
            {
                return null;
            }
            return fileContent;
        }
    }
}
