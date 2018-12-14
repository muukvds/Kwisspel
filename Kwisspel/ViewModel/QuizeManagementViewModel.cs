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
            set { _selectedQuiz = value; }
        }

        public ObservableCollection<QuizViewModel> Quizzes { get; set; }

        public RelayCommand ShowAddQuizWindowCommand { get; set; }
        public RelayCommand ShowEditQuizWindowCommand { get; set; }
        public RelayCommand DeleteQuizCommand { get; set; }

        public QuizeManagementViewModel(KwisspelEntities context)
        {
            _context = context;

            Quizzes = new ObservableCollection<QuizViewModel>(_context.Quizzes.ToList().Select(q => new QuizViewModel(q)));

            ShowAddQuizWindowCommand  = new RelayCommand(ShowAddQuizWindow);
            ShowEditQuizWindowCommand  = new RelayCommand(ShowEditQuizWindow);
            DeleteQuizCommand = new RelayCommand(DeleteQuiz);
        }

        private void ShowAddQuizWindow()
        {
            var addQuizWindow = new AddQuizeWindow();
            addQuizWindow.Show();
        }

        private void ShowEditQuizWindow()
        {
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
