using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Kwisspel.View;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace Kwisspel.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
   public class QuizListViewModel : ViewModelBase
    {

        public KwisspelEntities Context { get; }

        public ObservableCollection<QuizViewModel> Quizzes { get; set; }

        private QuizViewModel _selectedQuiz;

        public QuizViewModel SelectedQuiz
        {
            get { return _selectedQuiz; }
            set
            {
                _selectedQuiz = value;
                base.RaisePropertyChanged();
            }
        }

        public ICommand ShowQuestionManagementCommand { get; set; }

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public QuizListViewModel()
        {
            Context = new KwisspelEntities();

            ShowQuestionManagementCommand = new RelayCommand(ShowQuestionManagement);
            

            Quizzes = new ObservableCollection<QuizViewModel>(Context.Quizzes.ToList().Select(q => new QuizViewModel(q,Context)));
        }

        public void ShowQuestionManagement()
        {
            var QuestionManagement = new QuestionManagementWindow();
            QuestionManagement.Show();

        }



    }
}