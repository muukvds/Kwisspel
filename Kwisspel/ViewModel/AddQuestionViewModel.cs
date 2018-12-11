using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Kwisspel.ViewModel
{
    public class AddQuestionViewModel : ViewModelBase
    {
        private QuestionViewModel _question;

        public QuestionViewModel Question
        {
            get { return _question; }
        }

        private ObservableCollection<QuestionViewModel> _questionList;

        public ObservableCollection<CategoryViewModel> Categories { set; get; }


        public QuestionOptionViewModel SelectedQuestionOption
        {
            get; set;
        }

        private KwisspelEntities _context;


        public Action CloseAction { get; set; }

        public ICommand DeleteQuestionOptionCommand { get; set; }
        public ICommand AddQuestionOptionCommand { get; set; }
        public ICommand SaveQuestionCommand { get; set; }

        public AddQuestionViewModel(KwisspelEntities context, ObservableCollection<QuestionViewModel> questionList)
        {
            _context = context;
            _question = new QuestionViewModel();
            _context.Questions.Add(_question.Model);
            _questionList = questionList;

            Categories = new ObservableCollection<CategoryViewModel>(_context.Categories.ToList().Select(c => new CategoryViewModel(c)));

            DeleteQuestionOptionCommand = new RelayCommand(DeleteQuestionOption);
            AddQuestionOptionCommand = new RelayCommand(AddQuestionOption);
            SaveQuestionCommand = new RelayCommand(SaveQuestion);
        }

        public AddQuestionViewModel(QuestionViewModel question, KwisspelEntities context)
        {
            _context = context;
            _question = question;
            Categories= new ObservableCollection<CategoryViewModel>(_context.Categories.ToList().Select(c => new CategoryViewModel(c)));

            _question.Category = Categories.First(c => c.Id == _question.Model.Categories_id);
        
            DeleteQuestionOptionCommand = new RelayCommand(DeleteQuestionOption);
            AddQuestionOptionCommand = new RelayCommand(AddQuestionOption);
            SaveQuestionCommand = new RelayCommand(SaveQuestion);
        }

        private void AddQuestionOption()
        {
            _question.AddQuestionOption(new QuestionOptionViewModel());
        }

        private void SaveQuestion()
        {
            _context.SaveChanges();
            if (_questionList != null)
            {
                _questionList.Add(Question);
            }


        }

        private void DeleteQuestionOption()
        {
            _question.DeleteQuestionOption(SelectedQuestionOption);
        }

    }
}
