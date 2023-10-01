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
        }

        public void GetAllData<T>(string filePath,ref ObservableCollection<T> collection)
        {
                try
                {
                    using (var stream = new FileStream(filePath, FileMode.Open))
                    {
                        var serializer = new XmlSerializer(typeof(ObservableCollection<T>));
                        collection = (ObservableCollection<T>)serializer.Deserialize(stream);
                    }
                }
                catch (FileNotFoundException ex)
                {
                    MessageBox.Show($"File not found: {ex.Message}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error occurred when deserializing data: {ex.Message}");
                }
        }

        public ObservableCollection<Question> GetQuizQuestions(string difficulty) {
            GetAllData("C:/Users/adria/source/repos/QuizzProject/Dat/QuizzData.xml",ref Questions);

            var quizQuestion= Questions.Where(x => x.Difficulty == difficulty).ToList(); 
            
            var random=new Random();
            var shuffledQuestions=quizQuestion.OrderBy(x => random.Next());

            return new ObservableCollection<Question>(shuffledQuestions.Take(5));
        }

        public void AddPlayerStats(Player player)
        {
            GetAllData("C:/Users/adria/source/repos/QuizzProject/Data/PlayerData.xml",ref Players);

            var newPlayer = Players.FirstOrDefault(x => x.Name == player.Name);
            if (newPlayer == null)
            {
                Players.Add(player);
                SeedData.SerializePlayersToXml(Players.ToList());
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
