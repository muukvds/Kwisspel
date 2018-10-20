using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kwisspel.ViewModel
{
    public class QuestionOptionViewModel : ViewModelBase
    {
        public int Id
        {
            get { return _questionOption.id; }
            set { _questionOption.id = value; RaisePropertyChanged("id"); }
        }

        public string Anwser
        {
            get { return _questionOption.anwser; }
            set { _questionOption.anwser = value; RaisePropertyChanged("anwser"); }
        }

        public bool IsAnwser
        {
            get { return _questionOption.isAnwser; }
            set { _questionOption.isAnwser = value; RaisePropertyChanged("isAnwser"); }
        }

        private QuestionOption _questionOption;

        public QuestionOptionViewModel(QuestionOption o)
        {
            _questionOption = o;
        }

        public QuestionOptionViewModel()
        {
            _questionOption = new QuestionOption();
        }
    }
}
