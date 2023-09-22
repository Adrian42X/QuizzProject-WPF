using QuizzProject.Data;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace QuizzProject.Models
{
    public class QuizService
    {
        private DataManager _dataManager;
        public string selectedDifficulty;
        public string playerName = "Player";
        public ObservableCollection<Question> questions;
        private static int index = 0;
        public int playerScore=0;
        public QuizService() {
            _dataManager = new DataManager();
            questions = new ObservableCollection<Question>();
        }
        public void StartQuizz() {
            
            this.questions=_dataManager.GetQuizQuestions(selectedDifficulty);
        }

        public Question GetCurrentQuestion()
        {
            if (index < 5)
            {//sa verific mai intai daca s-a raspuns la intrebarea anterioara sau trimit rapunsu din vm cumva gen nr rasp corecte (score)
                index++;
                return this.questions[index-1];
            }
            return new Question();
        }
        public Question GetPreviousQuestion() 
        {
            if (index >= 1)
            {
                index--;
                return this.questions[index];
            }
            return new Question();
        }

        public void NewQuiz()
        {
            index = 0;
            playerScore = 0;
            questions = new ObservableCollection<Question>();
        }
    }
}
