using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            set { _question.id = value; RaisePropertyChanged("id"); }
        }

        public string Question
        {
            get { return _question.question1; }
            set { _question.question1 = value; RaisePropertyChanged("question1"); }
        }

        //public Category Categorie
        //{
        //    get { return _question.Category; }
        //    set { _question.Category = value; RaisePropertyChanged("question"); }
        //}


        private Question _question;

        public QuestionViewModel()
        {
            _question = new Question();
        }

        public QuestionViewModel(Question q)
        {
            _question = q;
        
            QuestionOptions = new ObservableCollection<QuestionOptionViewModel>(_question.QuestionOptions.ToList().Select(o => new QuestionOptionViewModel(o)));
            
        }
    }
}
