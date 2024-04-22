using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlDataExtractorCsv.ViewModels
{
    public class CSVViewModel
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? City { get; set; }
        public string? HomePhone { get; set; }
        public string? MobilePhone { get; set; }
        public string? WorkPhone { get; set; }
        public string? Street { get; set; }
        public string? Building { get; set; }
        public string? Number { get; set; }
        public string? Region { get; set; }
        public string? Country { get; set; }
    }
}
