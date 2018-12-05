using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
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

        private QuestionOptionViewModel _selectedQuestionOption;

        public QuestionOptionViewModel SelectedQuestionOption
        {
            get { return _selectedQuestionOption; }
            set { _selectedQuestionOption = value; }
        }

        private KwisspelEntities _context;

        public ICommand DeleteQuestionOptionCommand { get; set; }
        public ICommand AddQuestionOptionCommand { get; set; }

        public AddQuestionViewModel(KwisspelEntities context)
        {
            _context = context;
            _question = new QuestionViewModel(_context);

            DeleteQuestionOptionCommand = new RelayCommand(DeleteQuestionOption);
            AddQuestionOptionCommand = new RelayCommand(AddQuestionOption);

        }

        private void AddQuestionOption()
        {
            _question.AddQuestionOption(new QuestionOptionViewModel(_question.Id, _context));
        }

        private void DeleteQuestionOption()
        {
            _question.AddQuestionOption(new QuestionOptionViewModel(_question.Id, _context));
        }

    }
}
