using QuizzProject.Commands;
using QuizzProject.Models;
using QuizzProject.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizzProject.ViewModels
{
    public class FinishViewModel : BaseViewModel
    {
        private readonly QuizService _quizService;
        private readonly NavigationStore _navigationStore;

        public FinishViewModel(QuizService quizService,NavigationStore navigationStore)
        {
            _quizService = quizService;
            _navigationStore = navigationStore;
        }
        public string PlayerName => _quizService.playerName;
        public string Difficulty => _quizService.selectedDifficulty;
        public string Score=> _quizService.playerScore.ToString() + "/5";

        public RelayCommand NewQuizCommand => new RelayCommand(execute =>
        {
            _quizService.NewQuiz();
            _navigationStore.CurrentViewModel = new StartViewModel(_quizService, _navigationStore);
        });
    
    }
}
