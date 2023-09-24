using QuizzProject.Commands;
using QuizzProject.Models;
using QuizzProject.Stores;
using QuizzProject.Views;
using System.Windows.Input;

namespace QuizzProject.ViewModels
{
    public class StartViewModel : BaseViewModel
    {
        private readonly NavigationStore _navigationStore;
        private string _playername;
        private string _quizdifficulty="Easy";
        private QuizService _quizService;

        public StartViewModel(QuizService quizService,NavigationStore navigationStore)
        {
            _quizService = quizService; 
            _navigationStore = navigationStore;
        }

        public string PlayerName
        {
            get
            {
                return _playername;
            }
            set
            {
                _playername = value;
                OnPropertyChanged(nameof(PlayerName));
            }
        }
        public string Quizdifficulty
        {
            get
            {
                return _quizdifficulty;
            }
            set
            {
                _quizdifficulty = value;
                OnPropertyChanged(nameof(Quizdifficulty));
            }
        }

        public ICommand StartCommand => new RelayCommand(execute =>
            {
                _quizService.playerName = PlayerName;
                _quizService.selectedDifficulty = Quizdifficulty;
                _quizService.StartQuizz();
                _navigationStore.CurrentViewModel = new QuizViewModel(_quizService, _navigationStore);
            }, 
            canExecute => (PlayerName != null && Quizdifficulty != null)
            );
      
    }
}
