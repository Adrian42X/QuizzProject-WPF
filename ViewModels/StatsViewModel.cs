using QuizzProject.Commands;
using QuizzProject.Models;
using QuizzProject.Stores;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace QuizzProject.ViewModels
{
    public class StatsViewModel : BaseViewModel
    {
        private QuizService _quizService;
        private NavigationStore _navigationStore;
        public StatsViewModel(QuizService quizService,NavigationStore navigationStore)
        {
            _quizService = quizService;
            _navigationStore = navigationStore;
        }

        public List<Player> Players=>_quizService.GetAllPlayers().OrderByDescending(x=>x.Score).ToList();
        public ICommand BackCommand => new RelayCommand(execute =>
        {
            _navigationStore.CurrentViewModel = new FinishViewModel(_quizService, _navigationStore);
        });
    }
}
