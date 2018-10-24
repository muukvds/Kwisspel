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
        private KwisspelEntities _context;
        public int Id
        {
            get { return _quizze.id; }
            set { _quizze.id = value; RaisePropertyChanged("Id"); }
        }

        public string Name
        {
            get { return _quizze.name; }
            set { _quizze.name = value; RaisePropertyChanged("Name"); }
        }

        private Quizze _quizze;

        public QuizViewModel(KwisspelEntities context)
        {
            _context = context;
            _quizze = new Quizze();
        }

        public QuizViewModel(Quizze q, KwisspelEntities context)
        {
            _context = context;
            _quizze = q;
        }
    }
}
