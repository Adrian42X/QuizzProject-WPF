using System.Xml.Serialization;

namespace QuizzProject.Models
{
    public class Player
    {
        public Player()
        {
            Score = 0;
            NrOfPlayedQuizzes = 0;
        }

        [XmlAttribute]
        public string? Name { get; set; }
        [XmlAttribute]
        public int Score { get; set; }
        [XmlAttribute]
        public int NrOfPlayedQuizzes { get; set; }
    }
}
