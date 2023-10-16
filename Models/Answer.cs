using System.Xml.Serialization;

namespace QuizzProject.Models
{
    public class Answer
    {
        [XmlAttribute]
        public string? Text { get; set; }
        [XmlAttribute]
        public bool IsCorrect { get; set; }
    }
}
  