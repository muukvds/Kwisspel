using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kwisspel.ViewModel
{
    public class QuestionOptionViewModel : ViewModelBase
    {

        private KwisspelEntities _context;
        public int Id
        {
            get { return _questionOption.id; }
        }

        public int QuestionId
        {
            get { return _questionOption.Questions_id; }
            set { _questionOption.Questions_id = value; RaisePropertyChanged("QuestionId"); _context.SaveChanges(); }
        }

        public string Anwser
        {
            get { return _questionOption.anwser; }
            set { _questionOption.anwser = value; RaisePropertyChanged("Anwser"); _context.SaveChanges(); }
        }

        public bool IsAnwser
        {
            get { return _questionOption.isAnwser; }
            set { _questionOption.isAnwser = value; RaisePropertyChanged("IsAnwser"); _context.SaveChanges(); }
        }

        private QuestionOption _questionOption;


        public QuestionOptionViewModel(QuestionOption o, KwisspelEntities context )
        {
            _context = context;
            _questionOption = o;
        }

        public QuestionOptionViewModel(int QuestionId, KwisspelEntities context)
        {
            _context = context;
            _questionOption = new QuestionOption();
            this.QuestionId = QuestionId;
        }
    }
}
