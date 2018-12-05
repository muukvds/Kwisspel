using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kwisspel.ViewModel
{
   public class QuestionViewModel: ViewModelBase
    {
        private KwisspelEntities _context;
        public ObservableCollection<QuestionOptionViewModel> QuestionOptions { get; set; }
        public ObservableCollection<CategoryViewModel> Categories { get; set; }


        public int Id
        {
            get { return _question.id; }
        }

        public string Question
        {
            get { return _question.question; }
            set { _question.question = value; RaisePropertyChanged("Question"); Save(); }
        }

        private CategoryViewModel _category;

        public CategoryViewModel Category {
            get { return _category; }
            set { _category = value;  _question.Category = _category.Model; RaisePropertyChanged("Category"); Save(); }
        }

        private Question _question;

        public QuestionViewModel(KwisspelEntities context )
        {
            _context = context;
            _question = new Question();
            _context.Questions.Add(_question);

            QuestionOptions = new ObservableCollection<QuestionOptionViewModel>();
            Categories = new ObservableCollection<CategoryViewModel>(_context.Categories.ToList().Select(c => new CategoryViewModel(c,_context)));
           
            _context.Questions.Add(_question);
        }

        public QuestionViewModel(Question q, KwisspelEntities context)
        {
            _context = context;
            _question = q;

            QuestionOptions = new ObservableCollection<QuestionOptionViewModel>(_question.QuestionOptions.ToList().Select(o => new QuestionOptionViewModel(o,_context)));
            Categories = new ObservableCollection<CategoryViewModel>(_context.Categories.ToList().Select(c => new CategoryViewModel(c,_context)));

            _category = Categories.Where(c => c.Id == _question.Categories_id).First();

        }

        public void AddQuestionOption(QuestionOptionViewModel questionOptionViewModel)
        {
            QuestionOptions.Add(questionOptionViewModel);

            RaisePropertyChanged("QuestionOptions");
        }

        public void DeleteQuestionOption(QuestionOptionViewModel questionOptionViewModel)
        {
            QuestionOptions.Remove(questionOptionViewModel);
            questionOptionViewModel.Delete();
            RaisePropertyChanged("QuestionOptions");
        }

        private void Save()
        {

            if (Category != null && Question != null)
            {
                _context.SaveChanges();
            }

        }

        public void Delete()
        {
            var childData = _question.QuestionOptions.ToList();
            foreach (var data in childData)
            {
                _context.QuestionOptions.Remove(data);
            }
            _context.SaveChanges();
        
        _context.Questions.Remove(_question);
            _context.SaveChanges();
        }
    }
}
