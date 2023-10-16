using System.Collections.Generic;
using System.Xml.Serialization;

namespace QuizzProject.Models
{
    public class Question
    {
        [XmlAttribute]
        public string? Text { get; set; }
        [XmlAttribute]
        public string? Difficulty { get; set; }

        [XmlArrayItem("R")]
        public List<Answer>? Answers { get; set; }
    }
}
