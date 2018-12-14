using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Kwisspel.View;
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
            get => _selectedQuestion; 
            set {
                _selectedQuestion = value;
                RaisePropertyChanged();
            }
        }

        public ICommand DeleteQuestionCommand { get; set; }
        public ICommand AddQuestionCommand { get; set; }
        public ICommand EditQuestionCommand { get; set; }



        public QuestionManagementViewModel(KwisspelEntities context)
        {
            _context = context;

            DeleteQuestionCommand = new RelayCommand(DeleteQuestion);
            AddQuestionCommand = new RelayCommand(AddQuestion);
            EditQuestionCommand = new RelayCommand(EditQuestion);

            Categories = new ObservableCollection<CategoryViewModel>(_context.Categories.ToList().Select(c => new CategoryViewModel(c)));
            Questions = new ObservableCollection<QuestionViewModel>(_context.Questions.ToList().Select(q => new QuestionViewModel(q)));

        }

        private void DeleteQuestion()
        {


            var childData = _selectedQuestion.Model.QuestionOptions.ToList();
            foreach (var data in childData)
            {
                _context.QuestionOptions.Remove(data);
            }
   

            _context.Questions.Remove(_selectedQuestion.Model);
            Questions.Remove(_selectedQuestion);
            _context.SaveChanges();
        }

        private void AddQuestion()
        {
            AddQuestionWindow addQuestionWindow = new AddQuestionWindow();
            addQuestionWindow.Show();
        }
        private void EditQuestion()
        {
            EditQuestionWindow editQuestionWindow = new EditQuestionWindow();
            editQuestionWindow.Show();
        }

        private bool CanDeleteQuestion()
        {
            return SelectedQuestion != null;
        }
    }
}
