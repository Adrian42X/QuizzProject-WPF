using QuizzProject.Models;
using QuizzProject.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizzProject.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private QuizService _quizService;
        private readonly NavigationStore _navigationStore;
        public BaseViewModel CurrentViewModel =>_navigationStore.CurrentViewModel;
        public MainViewModel(QuizService quizService, NavigationStore navigationStore)
        {
            _quizService = quizService;
            _navigationStore = navigationStore;
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel)); 
        }
    }
}
