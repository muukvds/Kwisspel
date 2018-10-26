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
    public class QuestionManagementViewModel : ViewModelBase
    {

        private KwisspelEntities _context;
        public ObservableCollection<QuestionViewModel> Questions { get; set; }
        public ObservableCollection<CategoryViewModel> Categories { get; set; }

        private QuestionViewModel _selectedQuestion;

        public QuestionViewModel SelectedQuestion
        {
            get { return _selectedQuestion; }
            set {
                _selectedQuestion = value;
                base.RaisePropertyChanged();
            }
        }

        public ICommand DeleteQuestionCommand { get; set; }

        public QuestionManagementViewModel(KwisspelEntities context)
        {
            _context = context;

            DeleteQuestionCommand = new RelayCommand(DeleteQuestion);

            Categories = new ObservableCollection<CategoryViewModel>(_context.Categories.ToList().Select(c => new CategoryViewModel(c, _context)));
            Questions = new ObservableCollection<QuestionViewModel>(_context.Questions.ToList().Select(q => new QuestionViewModel(q, _context)));

        }

        private void DeleteQuestion()
        {
            SelectedQuestion.Delete();
            Questions.Remove(SelectedQuestion);
    
          
        }

        private bool CanDeleteQuestion()
        {
            return SelectedQuestion != null;
        }
    }
}
