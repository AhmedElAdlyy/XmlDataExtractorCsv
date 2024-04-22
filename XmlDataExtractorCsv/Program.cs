using XmlDataExtractorCsv.Reps;
using XmlDataExtractorCsv.ViewModels;

namespace XmlDataExtractorCsv
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var paths = ReadFilePaths();

            if (paths != null && paths.Length != 0)
            {
                foreach (string path in paths)
                {
                    XMLOperations xmlOps = new XMLOperations(path);
                    List<CSVViewModel> records = xmlOps.ExtractXMLData();

                    string csvPath = GetCSVFilePath(path);
                    CSVOperations csvOps = new CSVOperations(csvPath);
                    csvOps.WriteRecord(records);
                }
            }
            else
            {
                Console.WriteLine("Empty Input folder");
            }
        }

        static private string[] ReadFilePaths()
        {
            string inputFolderPath = "Input\\";

            if (Directory.Exists(inputFolderPath))
            {
                var files = Directory.GetFiles(inputFolderPath);
                return files;
            }
            else
            {
                return null;
            }
        }

        static private string GetCSVFilePath(string xmlFilePath)
        {
            var fileName = Path.GetFileNameWithoutExtension(xmlFilePath);

            return $"Output\\{fileName}.csv";
        }
    }
}
