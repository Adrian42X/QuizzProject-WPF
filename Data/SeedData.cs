using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using QuizzProject.Models;

namespace QuizzProject.Data
{
    public static class SeedData
    {

        public static void Seed()
        {
            var questions = new List<Question>();

            for (int n = 1; n <= 3; n++)
                for (int i = 1; i <= 10; i++)
                {
                    string dif= "Easy";
                    switch (n)
                    {
                        case 1:
                            dif = "Easy";
                            break;
                        case 2:
                            dif = "Medium";
                            break;
                        case 3:
                            dif = "Hard";
                            break;
                        default:
                            break;
                    }
                    var question = new Question
                    {
                        Text = $"Question {i}?",
                        Difficulty = dif,
                        Answers = new List<Answer>()
                    };


                    for (int j = 1; j <= 4; j++)
                    {
                        bool isCorrect = (j == 1);
                        var answer = new Answer
                        {
                            Text = $"Option {j}",
                            IsCorrect = isCorrect,
                        };

                        question.Answers.Add(answer);
                    }

                    questions.Add(question);
                }

            var players = new List<Player>();
            players.Add(new Player() { Name = "Adrian"});
            players.Add(new Player() { Name="Player"});

            SerializePlayersToXml(players);
            SerializeQuestionsToXml(questions);
        }

        public static void SerializePlayersToXml(List<Player> players)
        {
            using (var stream = new FileStream("C:/Users/adria/source/repos/QuizzProject/Data/PlayerData.xml", FileMode.Create))
            {
                var serializer = new XmlSerializer(typeof(List<Player>));
                var settings = new XmlWriterSettings
                {
                    Indent = true
                };

                using (var writer = XmlWriter.Create(stream, settings))
                {
                    serializer.Serialize(writer, players);
                }
            }
        }
        public static void SerializeQuestionsToXml(List<Question> questions)
        {
            using (var stream = new FileStream("C:/Users/adria/source/repos/QuizzProject/Data/QuizzData.xml", FileMode.Create))
            {
                var serializer = new XmlSerializer(typeof(List<Question>));
                var settings = new XmlWriterSettings
                {
                    Indent = true
                };

                using (var writer = XmlWriter.Create(stream, settings))
                {
                    serializer.Serialize(writer, questions);
                }
            }
        }
    }
}
