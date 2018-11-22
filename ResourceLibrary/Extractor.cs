using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ResourceLibrary.Properties
{
    public static class Extractor
    {
        public static string ExtractSchema(string resourse)
        {
            string fileName =  System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData)
            + "\\University\\Templates\\Schema" + " - " + DateTime.Now.ToString("dd.MM.yyyy hh-mm-ss") + ".xsd";

            if (!Directory.Exists(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData)+ "\\University\\Templates"))
            {
                Directory.CreateDirectory(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData)
            + "\\University\\Templates");
            }

            File.WriteAllText(fileName, resourse);
            

            return fileName;
        }

        public static string ExtractDocument(byte[] resource)
        {
            string fileName = System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData)
            + "\\University\\Templates\\Document" + " - " + DateTime.Now.ToString("dd.MM.yyyy hh-mm-ss") + ".dotx";

            if (!Directory.Exists(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData) + "\\University\\Templates\\Document"))
            {
                Directory.CreateDirectory(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData)
            + "\\University\\Template\\Document");
            }

            File.WriteAllBytes(fileName, resource);

            return fileName;
        }
    }
}
