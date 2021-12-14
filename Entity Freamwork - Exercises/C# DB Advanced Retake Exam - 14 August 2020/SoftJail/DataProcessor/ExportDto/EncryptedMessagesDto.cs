using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace SoftJail.DataProcessor.ExportDto
{
    [XmlType("Message")]
    public class EncryptedMessagesDto
    {
        [Required]
        [XmlElement("Description")]
        public string Description { get; set; }
    }
}