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
        public ObservableCollection<QuestionOptionViewModel> QuestionOptions { get; set; }


        public int Id
        {
            get { return _question.id; }
        }

        public string Question
        {
            get { return _question.question; }
            set { _question.question = value; RaisePropertyChanged();}
        }

        private CategoryViewModel _category;

        public CategoryViewModel Category {
            get { return _category; }
            set { _category = value;  _question.Category = _category.Model; RaisePropertyChanged(); }
        }

        private Question _question;

        public Question Model
        {
            get { return _question; }
        }

        public QuestionViewModel()
        {
            _question = new Question();

            QuestionOptions = new ObservableCollection<QuestionOptionViewModel>();
           
        }

        public QuestionViewModel(Question q)
        {
            _question = q;
            _category = new CategoryViewModel(_question.Category);
            QuestionOptions = new ObservableCollection<QuestionOptionViewModel>(_question.QuestionOptions.ToList().Select(o => new QuestionOptionViewModel(o)));

        }

        public void AddQuestionOption(QuestionOptionViewModel questionOptionViewModel)
        {
            QuestionOptions.Add(questionOptionViewModel);
            _question.QuestionOptions.Add(questionOptionViewModel.Model);

            RaisePropertyChanged();
        }

        public void DeleteQuestionOption(QuestionOptionViewModel questionOptionViewModel)
        {
            _question.QuestionOptions.Remove(questionOptionViewModel.Model);
            RaisePropertyChanged();
        }
    }
}
