using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XmlDataExtractorCsv.ViewModels;

namespace XmlDataExtractorCsv.Services
{
    public class CSVMap : ClassMap<CSVViewModel>
    {
        public CSVMap()
        {
            Map(m => m.Name).Index(0);
            Map(m => m.Email).Index(1);
            Map(m => m.Number).Index(2);
            Map(m => m.Building).Index(3);
            Map(m => m.Street).Index(4);
            Map(m => m.Region).Index(5);
            Map(m => m.City).Index(6);
            Map(m => m.Country).Index(7);
            Map(m => m.MobilePhone).Name("Mobile Phone").Index(8);
            Map(m => m.HomePhone).Name("Home Phone").Index(9);
            Map(m => m.WorkPhone).Name("Work Phone").Index(10);
        }
    }
}
