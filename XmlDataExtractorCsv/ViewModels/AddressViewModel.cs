using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XmlDataExtractorCsv.ViewModels
{
    public class AddressViewModel
    {
        public string? Street { get; set; }
        public string? Building { get; set; }
        public string? Number { get; set; }
        public string? Region { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
    }
}
