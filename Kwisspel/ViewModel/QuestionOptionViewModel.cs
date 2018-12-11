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

        public int Id
        {
            get { return QuestionOption.id; }
        }

        public int QuestionId
        {
            get { return QuestionOption.Questions_id; }
        }

        public string Anwser
        {
            get { return QuestionOption.anwser; }
            set { QuestionOption.anwser = value; RaisePropertyChanged(); }
        }

        public bool IsAnwser
        {
            get { return QuestionOption.isAnwser; }
            set { QuestionOption.isAnwser = value; RaisePropertyChanged(); }
        }

        private QuestionOption QuestionOption;

        public QuestionOption Model
        {
            get { return QuestionOption; }
        }

        public QuestionOptionViewModel(QuestionOption o)
        {
            QuestionOption = o;
        }

        public QuestionOptionViewModel()
        {
            QuestionOption = new QuestionOption();
        }
    }
}
