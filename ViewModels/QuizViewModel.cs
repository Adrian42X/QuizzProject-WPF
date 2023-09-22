using QuizzProject.Commands;
using QuizzProject.Models;
using QuizzProject.Stores;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Documents;

namespace QuizzProject.ViewModels
{
    public class QuizViewModel : BaseViewModel
    {
        private readonly QuizService _quizService;
        private readonly NavigationStore _navigationStore;
        private Question _currentQuestion;
        public QuizViewModel(QuizService quizService,NavigationStore navigationStore) {
            _quizService = quizService;
            _navigationStore = navigationStore;
            _currentQuestion=_quizService.GetCurrentQuestion();
        }  


        public List<Answer> Answers
        {
            get { return _currentQuestion.Answers.ToList(); }
        }
        public string QuestionText
        {
            get
            {
                try
                {
                    return _currentQuestion.Text.ToString();
                }
                catch
                {
                    _navigationStore.CurrentViewModel = new FinishViewModel(_quizService, _navigationStore);
                    return string.Empty;
                }
            }
        }

        public RelayCommand NextCommand => new RelayCommand(execute =>
        {
            _navigationStore.CurrentViewModel = new QuizViewModel(_quizService, _navigationStore);
        });
        
    }
}
