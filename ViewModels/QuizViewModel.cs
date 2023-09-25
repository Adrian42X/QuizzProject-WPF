using QuizzProject.Commands;
using QuizzProject.Models;
using QuizzProject.Stores;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;

namespace QuizzProject.ViewModels
{
    public class QuizViewModel : BaseViewModel
    {
        private readonly QuizService _quizService;
        private readonly NavigationStore _navigationStore;
        private Question _currentQuestion;
        private static int index=0;
        public QuizViewModel(QuizService quizService,NavigationStore navigationStore) {
            _quizService = quizService;
            _navigationStore = navigationStore;
            _currentQuestion=_quizService.GetQuestion(index);
        }  


        public List<Answer> Answers
        {
            get { 
                if(_currentQuestion!=null)
                return _currentQuestion.Answers.ToList();
                return null;
            }
        }
        
        public string QuestionText
        {
            get
            {
                if (_currentQuestion != null)
                    return _currentQuestion.Text.ToString();

                index = 0;
                _navigationStore.CurrentViewModel = new FinishViewModel(_quizService, _navigationStore);
                return string.Empty;
                
            }
        }

        public string QuestionNumber => (index+1) + "/5 Questions";
        public string NextOrFinishButton
        {
            get
            {
                if(index+1==_quizService.questions.Count)
                return "Finish";

                return "Next";
            }
        }
        public ICommand NextCommand => new RelayCommand(execute =>
        {
            index++;

            if (_currentQuestion.Answers.FirstOrDefault(x => x.IsChecked == true) == null)
                MessageBox.Show("You must pick an answer for this question");

            _navigationStore.CurrentViewModel = new QuizViewModel(_quizService, _navigationStore);
        });

        public ICommand PreviousCommand => new RelayCommand(execute =>
        {
            if(index > 0)
            index--;
            _navigationStore.CurrentViewModel = new QuizViewModel(_quizService, _navigationStore);
        });
    }
}
