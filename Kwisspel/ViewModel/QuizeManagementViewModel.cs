using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Kwisspel.View;

namespace Kwisspel.ViewModel
{
    public class QuizeManagementViewModel : ViewModelBase
    {
        private KwisspelEntities _context;

        private QuizViewModel _selectedQuiz;

        public QuizViewModel SelectedQuiz
        {
            get { return _selectedQuiz; }
            set
            {
                _selectedQuiz = value;
                RaisePropertyChanged();
            }
        }

        public AddQuizViewModel AddQuizViewModel { get; private set; }

        public ObservableCollection<QuizViewModel> Quizzes { get; set; }

        public RelayCommand ShowAddQuizWindowCommand { get; set; }
        public RelayCommand ShowEditQuizWindowCommand { get; set; }
        public RelayCommand DeleteQuizCommand { get; set; }

        public QuizeManagementViewModel(KwisspelEntities context, ObservableCollection<QuizViewModel> quizzes)
        {
            _context = context;

            Quizzes = quizzes;

            ShowAddQuizWindowCommand  = new RelayCommand(ShowAddQuizWindow);
            ShowEditQuizWindowCommand  = new RelayCommand(ShowEditQuizWindow);
            DeleteQuizCommand = new RelayCommand(DeleteQuiz);
        }

        private void ShowAddQuizWindow()
        {
            this.AddQuizViewModel = new AddQuizViewModel(_context,Quizzes);
            var addQuizWindow = new AddQuizeWindow();
            addQuizWindow.Show();
        }

        private void ShowEditQuizWindow()
        {
            this.AddQuizViewModel = new AddQuizViewModel(_context, _selectedQuiz, Quizzes);
            var editQuizWindow = new EditQuizeWindow();
            editQuizWindow.Show();
        }

        private void DeleteQuiz()
        {
            _context.Quizzes.Remove(_selectedQuiz.Model);
            Quizzes.Remove(_selectedQuiz);
            RaisePropertyChanged();
            _context.SaveChanges();
        }

    }
}
