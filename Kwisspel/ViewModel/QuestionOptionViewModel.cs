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
        }

        public string Anwser
        {
            get { return _questionOption.anwser; }
            set { _questionOption.anwser = value; RaisePropertyChanged("Anwser"); }
        }

        public bool IsAnwser
        {
            get { return _questionOption.isAnwser; }
            set { _questionOption.isAnwser = value; RaisePropertyChanged("IsAnwser"); }
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
            _questionOption.Questions_id = QuestionId;

            _context.QuestionOptions.Add(_questionOption);
        }

        public void Delete()
        {

            _context.QuestionOptions.Remove(_questionOption);
        }

        private void Save()
        {

            if (Anwser != null)
            {
                _context.SaveChanges();
            }
        }

    }
}
