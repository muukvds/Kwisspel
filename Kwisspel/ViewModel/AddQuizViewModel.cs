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

        public QuizViewModel Quiz
        {
            get { return _quiz; }
        }

        private QuestionViewModel _selectedQuestionComboBox;
        public QuestionViewModel SelectedQuestionComboBox
        {
            get { return _selectedQuestionComboBox; }
            set
            {
                _selectedQuestionComboBox = value; 
                RaisePropertyChanged();
                ResetCanExecute();
            }
        }

        private QuestionViewModel _selectedQuestionDataGrid;
        public QuestionViewModel SelectedQuestionDataGrid
        {
            get { return _selectedQuestionDataGrid; }
            set
            {
                _selectedQuestionDataGrid = value; 
                RaisePropertyChanged();
                ResetCanExecute();
            }
        }

        public ObservableCollection<QuestionViewModel> QuestionsComboBox { get; set; }
        private ObservableCollection<QuizViewModel> _quizzes { get; set; }


        public RelayCommand AddQuestionCommand { get; set; }
        public RelayCommand RemoveQuestionCommand { get; set; }
        public RelayCommand SaveQuizCommand { get; set; }
        public RelayCommand ShowAddQuestionCommand { get; set; }




        public AddQuizViewModel(KwisspelEntities context, ObservableCollection<QuizViewModel> quizzes)
        {
            _context = context;
            _quizzes = quizzes;
            _quiz = new QuizViewModel(new Quizze());
            _context.Quizzes.Add(_quiz.Model);
            QuestionsComboBox = new ObservableCollection<QuestionViewModel>(_context.Questions.ToList().Select(q => new QuestionViewModel(q)));

            AddQuestionCommand = new RelayCommand(AddQuestion, CanAddQuestion);
            RemoveQuestionCommand = new RelayCommand(RemoveQuestion, CanRemoveQuestion);
            ShowAddQuestionCommand = new RelayCommand(ShowAddQuestionWindow, CanAddNewQuestion);
            SaveQuizCommand = new RelayCommand(SaveQuiz, CanSaveQuiz);
        }

        public AddQuizViewModel(KwisspelEntities context, QuizViewModel quizViewModel, ObservableCollection<QuizViewModel> quizzes)
        {
            _context = context;
            _quizzes = quizzes;
            _quiz = quizViewModel;
            _context.Quizzes.Add(_quiz.Model);
            QuestionsComboBox = new ObservableCollection<QuestionViewModel>(_context.Questions.ToList().Select(q => new QuestionViewModel(q)));

            AddQuestionCommand = new RelayCommand(AddQuestion, CanAddQuestion);
            RemoveQuestionCommand = new RelayCommand(RemoveQuestion, CanRemoveQuestion);
            ShowAddQuestionCommand = new RelayCommand(ShowAddQuestionWindow, CanAddNewQuestion);
            SaveQuizCommand = new RelayCommand(SaveQuiz, CanSaveQuiz);
        }

        public void AddNewQuestion(QuestionViewModel newQuestion)
        {
            _quiz.AddQuestion(newQuestion);
            ResetCanExecute();
        }

        private void AddQuestion()
        {
            _quiz.AddQuestion(SelectedQuestionComboBox);
            QuestionsComboBox.Remove(SelectedQuestionComboBox);
            RaisePropertyChanged();
            ResetCanExecute();
        }

        private void RemoveQuestion()
        {
            QuestionsComboBox.Add(SelectedQuestionDataGrid);
            _quiz.RemoveQuestion(SelectedQuestionDataGrid);
            ResetCanExecute();
        }

        private void ShowAddQuestionWindow()
        {
            var addQuestionToQuizWindow = new AddQuestionToQuizWindow();
            addQuestionToQuizWindow.Show();
        }

        private void SaveQuiz()
        {
         
            if (!_quizzes.Contains(Quiz))
            {
                 _quizzes.Add(Quiz);
            }
            _context.SaveChanges();
        }

        private bool CanAddQuestion()
        {
            return _quiz.Questions.Count < 10 && SelectedQuestionComboBox != null;
        }
        private bool CanAddNewQuestion()
        {
            return _quiz.Questions.Count < 10;
        }

        private bool CanRemoveQuestion()
        {
            return _quiz.Questions.Count > 2;
        }

        private bool CanSaveQuiz()
        {
            return !string.IsNullOrEmpty(_quiz.Name) && _quiz.Questions.Count >= 2 && _quiz.Questions.Count <= 10;
        }

        private void ResetCanExecute()
        {
            AddQuestionCommand.RaiseCanExecuteChanged();
            RemoveQuestionCommand.RaiseCanExecuteChanged();
            ShowAddQuestionCommand.RaiseCanExecuteChanged();
            SaveQuizCommand.RaiseCanExecuteChanged();
        }

    }
}
