using QuizzProject.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace QuizzProject.Data
{
    public class DataManager
    {
        public ObservableCollection<Question> Questions;
        public ObservableCollection<Player> Players;
        public DataManager() { 
            Questions = new ObservableCollection<Question>();
            Players = new ObservableCollection<Player>();
            GetAllQuestion();
            GetAllPlayers();
        }

        public void GetAllQuestion()
        {
            var filePath = "C:/Users/adria/source/repos/QuizzProject/Data/QuizzData.xml";
            try
            {
                using (var stream = new FileStream(filePath, FileMode.Open))
                {
                    var serializer = new XmlSerializer(typeof(ObservableCollection<Question>));
                    Questions = (ObservableCollection<Question>)serializer.Deserialize(stream);
                }
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show($"File not found: {ex.Message}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error occured when deserializing data: {ex.Message}");
            }
        }

        public void GetAllPlayers() {
            var filePath = "C:/Users/adria/source/repos/QuizzProject/Data/PlayerData.xml";
            if (File.Exists(filePath))
            {
                using (var stream = new FileStream(filePath, FileMode.Open))
                {
                    var serializer = new XmlSerializer(typeof(ObservableCollection<Player>));
                    Players = (ObservableCollection<Player>)serializer.Deserialize(stream);
                }
            }

            if (Players.Count == null)
                MessageBox.Show("Cannot find players in database");
        }

        public ObservableCollection<Question> GetQuizQuestions(string difficulty) {
            GetAllQuestion();
            var quizQuestion= this.Questions.Where(x => x.Difficulty == difficulty).ToList(); 
            
            var random=new Random();
            var shuffledQuestions=quizQuestion.OrderBy(x => random.Next());

            return new ObservableCollection<Question>(shuffledQuestions.Take(5));
        }

        public void AddPlayerStats(Player player)
        {
            var newPlayer = this.Players.FirstOrDefault(x => x.Name == player.Name);
            if (newPlayer == null)
            {
                this.Players.Add(player);
                SeedData.SerializePlayersToXml(this.Players.ToList());
            }
            else
            {
                if (player.Score >= newPlayer.Score)
                    newPlayer.Score = player.Score;

                newPlayer.NrOfPlayedQuizzes += 1;
            }
        }
    }
}
