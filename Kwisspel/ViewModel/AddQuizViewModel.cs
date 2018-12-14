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
    public class AddQuizViewModel : ViewModelBase
    {
        private KwisspelEntities _context;

        private QuizViewModel _quiz;

        public QuizViewModel Model
        {
            get { return _quiz; }
        }

        private QuestionViewModel _selectedQuestionComboBox;
        public QuestionViewModel SelectedQuestionComboBox
        {
            get { return _selectedQuestionComboBox; }
            set { _selectedQuestionComboBox = value; }
        }

        private QuestionViewModel _selectedQuestionDataGrid;
        public QuestionViewModel SelectedQuestionDataGrid
        {
            get { return _selectedQuestionDataGrid; }
            set { _selectedQuestionDataGrid = value; }
        }

        public ObservableCollection<QuestionViewModel> QuestionsComboBox { get; set; }
        public ObservableCollection<QuestionViewModel> QuestionsDataGrid { get; set; }


        public RelayCommand AddQuestionCommand { get; set; }
        public RelayCommand RemoveQuestionCommand { get; set; }
        public RelayCommand SaveQuizCommand { get; set; }
        public RelayCommand ShowAddQuestionCommand { get; set; }




        public AddQuizViewModel(KwisspelEntities context)
        {
            _context = context;
            _quiz = new QuizViewModel(new Quizze());
            _context.Quizzes.Add(_quiz.Model);

            AddQuestionCommand = new RelayCommand(AddQuestion, CanAddQuestion);
            RemoveQuestionCommand = new RelayCommand(RemoveQuestion, CanRemoveQuestion);
            ShowAddQuestionCommand = new RelayCommand(ShowAddQuestionWindow, CanAddQuestion);
            SaveQuizCommand = new RelayCommand(SaveQuiz);
        }

        public void AddNewQuestion(QuestionViewModel newQuestion)
        {
            _quiz.AddQuestion(newQuestion);
            ResetCanExecute();
        }

        private void AddQuestion()
        {
            QuestionsDataGrid.Add(SelectedQuestionComboBox);
            QuestionsComboBox.Remove(SelectedQuestionComboBox);
            RaisePropertyChanged();
            ResetCanExecute();
        }

        private void RemoveQuestion()
        {
            ResetCanExecute();
        }

        private void ShowAddQuestionWindow()
        {
            var addQuestionToQuizWindow = new AddQuestionToQuizWindow();
            addQuestionToQuizWindow.Show();
        }

        private void SaveQuiz()
        {
            _context.SaveChanges();
        }

        private bool CanAddQuestion()
        {
            return QuestionsDataGrid.Count < 10;
        }

        private bool CanRemoveQuestion()
        {
            return QuestionsDataGrid.Count > 2;
        }

        private void ResetCanExecute()
        {
            AddQuestionCommand.RaiseCanExecuteChanged();
            RemoveQuestionCommand.RaiseCanExecuteChanged();
            ShowAddQuestionCommand.RaiseCanExecuteChanged();
        }

    }
}
