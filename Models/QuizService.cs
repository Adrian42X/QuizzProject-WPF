using QuizzProject.Data;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace QuizzProject.Models
{
    public class QuizService
    {
        private DataManager _dataManager;
        public string selectedDifficulty;
        public string playerName = "Player";
        public ObservableCollection<Question> questions;
        public int playerScore=0;
        public QuizService() {
            _dataManager = new DataManager();
            questions = new ObservableCollection<Question>();
        }
        public void StartQuizz() {
            
            this.questions=_dataManager.GetQuizQuestions(selectedDifficulty);
        }

        public Question GetQuestion(int id)
        {
            if(id < this.questions.Count)
                return this.questions[id];
            else 
                foreach(var qt in  this.questions)
                {
                    bool correctAnswer = true;
                    foreach (var ans in qt.Answers)
                    {
                        if (ans.IsCorrect == false && ans.IsChecked == true || ans.IsCorrect==true && ans.IsChecked==false)
                            correctAnswer = false;
                    }
                    if (correctAnswer)
                        this.playerScore++;
                }
            return null;
        }
        public void NewQuiz()
        {
            playerScore = 0;
            questions=new ObservableCollection<Question>();     
        }

        public List<Player> GetAllPlayers()
        {
            return _dataManager.Players.ToList();
        }

        public void AddPlayerStats(string playerName,int score)
        {
            _dataManager.AddPlayerStats(new Player() { Name=playerName,Score=score});
        }
    }
}
