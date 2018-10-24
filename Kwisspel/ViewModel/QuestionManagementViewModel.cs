using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kwisspel.ViewModel
{
    public class QuestionManagementViewModel : ViewModelBase
    {

        private KwisspelEntities _context;
        public ObservableCollection<QuestionViewModel> Questions { get; set; }
        public ObservableCollection<CategoryViewModel> Categories { get; set; }

        private QuestionViewModel _selectedQuestion;

        public QuestionViewModel SelectedQuestion
        {
            get { return _selectedQuestion; }
            set { _selectedQuestion = value;
                base.RaisePropertyChanged();
            }
        }

        public QuestionManagementViewModel(KwisspelEntities context)
        {
            _context = context;
     
            Categories = new ObservableCollection<CategoryViewModel>(_context.Categories.ToList().Select(c => new CategoryViewModel(c, _context)));
            Questions = new ObservableCollection<QuestionViewModel>(_context.Questions.ToList().Select(q => new QuestionViewModel(q, _context)));

        }
    }
}
