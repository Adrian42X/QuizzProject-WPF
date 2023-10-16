using QuizzProject.Data;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Policy;

namespace QuizzProject.Models
{
    public class QuizService
    {
        private DataManager _dataManager;
        public string selectedDifficulty;
        public string playerName = "Player";
        public ObservableCollection<Question> questions;
        public int playerScore=0;
        public List<bool> correctQuestions;
        public QuizService() {
            _dataManager = new DataManager();
            questions = new ObservableCollection<Question>();
        }
        public void StartQuizz() {
            
            this.questions=_dataManager.GetQuizQuestions(selectedDifficulty);
            this.correctQuestions = new List<bool> { false,false,false,false,false};
        }

        public void CheckQuestionAnswer(int qid, List<bool> answers)
        {
            var ok = true;
            for(int i = 0; i < this.questions[qid].Answers.Count; i++)
            {
                if (answers[i] != this.questions[qid].Answers[i].IsCorrect)
                { 
                    ok = false;
                    break;
                }
            }

            this.correctQuestions[qid] = ok;
        }
        public Question GetQuestion(int id)
        {
            if (id < this.questions.Count)
                return this.questions[id];
            else
            {
                this.playerScore=this.correctQuestions.Where(x=>x==true).Count();
                return null;
            }
        }

        public void NewQuiz()
        {
            this.playerScore = 0;
            this.questions.Clear();
        }

        public List<Player> GetAllPlayers()
        {
            return _dataManager.Players.ToList();
        }

        public void AddPlayerStats()
        {
            _dataManager.AddPlayerStats(new Player() { Name=playerName,Score=playerScore});
        }
    }
}
