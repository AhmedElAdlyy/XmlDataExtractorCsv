using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XmlDataExtractorCsv.Services;
using XmlDataExtractorCsv.ViewModels;

namespace XmlDataExtractorCsv.Reps
{
    public class CSVOperations
    {
        private readonly string _csvFilePath;

        public CSVOperations(string csvFilePath)
        {
            _csvFilePath = csvFilePath;
        }

        public List<CSVViewModel> GetAllRecords()
        {
            using (var reader = new StreamReader(_csvFilePath))
            {
                using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
                {
                    List<CSVViewModel> records = csv.GetRecords<CSVViewModel>().ToList();

                    return records;
                }
            }
        }

        public void WriteRecord(List<CSVViewModel> records)
        {
            using(var writer = new StreamWriter(_csvFilePath))
            {
                using(var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture)))
                {
                    csv.Context.RegisterClassMap<CSVMap>();
                    csv.WriteRecords(records);
                }
            }
        }
    }
}
