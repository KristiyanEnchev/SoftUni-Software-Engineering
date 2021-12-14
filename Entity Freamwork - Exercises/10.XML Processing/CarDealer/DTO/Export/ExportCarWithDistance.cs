
using System.Xml.Serialization;

namespace CarDealer.DTO.Export
{
   [XmlType("car")]

    public class ExportCarWithDistance
    {
        [XmlElement("make")]
        public string Make { get; set; }

        [XmlElement("model")]
        public string Model { get; set; }

        [XmlElement("travelled-distance")]
        public long TravelledDistance { get; set; }
    }
}
