using QuizzProject.Data;
using QuizzProject.Models;
using QuizzProject.Stores;
using QuizzProject.ViewModels;
using System.Windows;

namespace QuizzProject
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly QuizService _quizService;
        
        public App()
        {
            _quizService = new QuizService();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            NavigationStore navigationStore = new NavigationStore();
            navigationStore.CurrentViewModel = new StartViewModel(_quizService, navigationStore);

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_quizService,navigationStore)
            };
            MainWindow.Show();

            base.OnStartup(e);
        }
    }
}
