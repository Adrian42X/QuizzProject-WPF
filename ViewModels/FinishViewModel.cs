using QuizzProject.Commands;
using QuizzProject.Models;
using QuizzProject.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

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
            _quizService.AddPlayerStats(_quizService.playerName, _quizService.playerScore);
        }
        public string PlayerName => "Name ->"+_quizService.playerName;
        public string Difficulty => "Difficulty ->"+_quizService.selectedDifficulty;
        public string Score=> _quizService.playerScore.ToString() + "/5 Correct answers";

        public ICommand NewQuizCommand => new RelayCommand(execute =>
        {
            _quizService.NewQuiz();
            _navigationStore.CurrentViewModel = new StartViewModel(_quizService, _navigationStore);
        });

        public ICommand ShowPlayerStats => new RelayCommand(execute =>
        {
            _navigationStore.CurrentViewModel = new StatsViewModel(_quizService, _navigationStore);
        });
    }
}
