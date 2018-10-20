using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kwisspel.ViewModel
{
    public class QuizViewModel: ViewModelBase
    {
        public int Id
        {
            get { return _quizze.id; }
            set { _quizze.id = value; RaisePropertyChanged("id"); }
        }

        public string Name
        {
            get { return _quizze.name; }
            set { _quizze.name = value; RaisePropertyChanged("name"); }
        }

        private Quizze _quizze;

        public QuizViewModel()
        {
            _quizze = new Quizze();
        }

        public QuizViewModel(Quizze q)
        {
            _quizze = q;
        }
    }
}
