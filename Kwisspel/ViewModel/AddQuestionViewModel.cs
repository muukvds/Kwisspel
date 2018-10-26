using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public AddQuestionViewModel(KwisspelEntities context)
        {
            _context = context;
            _question = new QuestionViewModel(_context);
        }

    }
}
