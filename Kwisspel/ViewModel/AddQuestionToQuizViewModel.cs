using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace Kwisspel.ViewModel
{
    public class AddQuestionToQuizViewModel : ViewModelBase
    {
        private QuestionViewModel _question;

        public QuestionViewModel Question
        {
            get { return _question; }
        }

        private AddQuizViewModel _addQuizViewModel;

        public ObservableCollection<CategoryViewModel> Categories { set; get; }


        public QuestionOptionViewModel SelectedQuestionOption
        {
            get; set;
        }

        private KwisspelEntities _context;


        public RelayCommand DeleteQuestionOptionCommand { get; set; }
        public RelayCommand AddQuestionOptionCommand { get; set; }
        public RelayCommand SaveQuestionCommand { get; set; }

        public AddQuestionToQuizViewModel(KwisspelEntities context, AddQuizViewModel addQuizViewModel)
        {
            _context = context;
            _question = new QuestionViewModel();
            _context.Questions.Add(_question.Model);
            _addQuizViewModel = addQuizViewModel;

            Categories = new ObservableCollection<CategoryViewModel>(_context.Categories.ToList().Select(c => new CategoryViewModel(c)));

            DeleteQuestionOptionCommand = new RelayCommand(DeleteQuestionOption, CanDeleteQuestionOption);
            AddQuestionOptionCommand = new RelayCommand(AddQuestionOption, CanAddNewQuestionOption);
            SaveQuestionCommand = new RelayCommand(SaveQuestion, CanSaveQuestion);
        }


        private void AddQuestionOption()
        {
            _question.AddQuestionOption(new QuestionOptionViewModel());
            ResetCanExecute();
        }


        private void SaveQuestion()
        {
            _addQuizViewModel.AddNewQuestion(Question);
        }

        private void DeleteQuestionOption()
        {
            _context.QuestionOptions.Remove(SelectedQuestionOption.Model);
            _question.DeleteQuestionOption(SelectedQuestionOption);
            ResetCanExecute();
        }

        private bool CanDeleteQuestionOption()
        {
            return Question.QuestionOptions.Count > 2;
        }

        private bool CanAddNewQuestionOption()
        {
            return Question.QuestionOptions.Count < 4;
        }

        private bool CanSaveQuestion()
        {
            return (Question.Question != null || Question.Question != "") && Question.QuestionOptions.Count >= 2;
        }

        private void ResetCanExecute()
        {
            AddQuestionOptionCommand.RaiseCanExecuteChanged();
            DeleteQuestionOptionCommand.RaiseCanExecuteChanged();
            SaveQuestionCommand.RaiseCanExecuteChanged();
        }

    }
}
