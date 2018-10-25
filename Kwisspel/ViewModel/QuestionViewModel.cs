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
            get { return _question.question1; }
            set { _question.question1 = value; RaisePropertyChanged("Question"); }
        }

        private CategoryViewModel _category;

        public CategoryViewModel Category {
            get { return _category; }
            set { _category = value;  _question.Category = _category.Model; RaisePropertyChanged("Category"); Save();}
        }

        private Question _question;

        public QuestionViewModel(KwisspelEntities context )
        {
            _context = context;
            _question = new Question();
        
            Categories = new ObservableCollection<CategoryViewModel>(_context.Categories.ToList().Select(c => new CategoryViewModel(c,_context)));
            
            _category = Categories.Where(c => c.Id == _question.Categories_id).First();
        }

        public QuestionViewModel(Question q, KwisspelEntities context)
        {
            _context = context;
            _question = q;

            QuestionOptions = new ObservableCollection<QuestionOptionViewModel>(_question.QuestionOptions.ToList().Select(o => new QuestionOptionViewModel(o,_context)));
            Categories = new ObservableCollection<CategoryViewModel>(_context.Categories.ToList().Select(c => new CategoryViewModel(c,_context)));

            _category = Categories.Where(c => c.Id == _question.Categories_id).First();
        }

        private void Save()
        {
            using (var context = new KwisspelEntities())
            {
                context.Entry(_question).State = EntityState.Modified;

                context.Questions.Attach(_question);
                //_question.Categories_id = 0;
                context.SaveChanges();
            }
        }
    }
}
