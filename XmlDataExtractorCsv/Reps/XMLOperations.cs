using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using XmlDataExtractorCsv.ViewModels;

namespace XmlDataExtractorCsv.Reps
{
    public class XMLOperations
    {
        private readonly string _xmlFilePath;
        private readonly XDocument _xmlDoc;

        public XMLOperations(string xmlFilePath)
        {
            _xmlFilePath = xmlFilePath;
            _xmlDoc = XDocument.Load(xmlFilePath);
        }

        public List<CSVViewModel> ExtractXMLData()
        {
            List<CSVViewModel> records = new List<CSVViewModel>();

            foreach (XElement employeeElement in _xmlDoc.Descendants("employee"))
            {

                List<AddressViewModel> adresses = GetAddressData(employeeElement.Element("Addresses"));
                PhonesViewModel phones = GetPhonesData(employeeElement.Element("Phones"));


                foreach (var address in adresses)
                {
                    CSVViewModel record = new CSVViewModel
                    {
                        Name = ((string)employeeElement.Element("name")).Trim(),
                        Email = ((string)employeeElement.Element("email")).Trim(),
                        Building = address.Building,
                        City = address.City,
                        Country = address.Country,
                        Number = address.Number,
                        Region = address.Region,
                        Street = address.Street,
                        HomePhone = phones.Home,
                        MobilePhone = phones.Mobile,
                        WorkPhone = phones.Work
                    };

                    records.Add(record);
                }

            }

            return records;
        }

        private List<AddressViewModel> GetAddressData(XElement addresses)
        {
            List<AddressViewModel> addressesList = new List<AddressViewModel>();

            foreach (XElement address in addresses.Descendants("address"))
            {
                AddressViewModel adress = new AddressViewModel
                {
                    Building = ((string)address.Element("building")).Trim(),
                    City = ((string)address.Element("city")).Trim(),
                    Country = ((string)address.Element("country")).Trim(),
                    Number = ((string)address.Element("number")).Trim(),
                    Region = ((string)address.Element("region")).Trim(),
                    Street = ((string)address.Element("street")).Trim()
                };

                addressesList.Add(adress);
            }

            return addressesList;
        }

        private PhonesViewModel GetPhonesData(XElement phones)
        {
            PhonesViewModel phonesData = new PhonesViewModel();

            foreach (var phone in phones.Descendants("phone"))
            {
                string type = ((string)phone.Attribute("type")).Trim();
                string number = ((string)phone.Value.Trim());

                switch (type)
                {
                    case "work":
                        phonesData.Work = number;
                        break;
                    case "home":
                        phonesData.Home = number;
                        break;
                    case "mobile":
                        phonesData.Mobile = number;
                        break;

                    default:
                        break;
                }

            }

            return phonesData;
        }


    }
}
