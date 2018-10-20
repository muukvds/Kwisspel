using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kwisspel.ViewModel
{
   public class QuestionListViewModel : ViewModelBase
    {
        public ObservableCollection<QuestionViewModel> Questions{ get; set; }

        private QuestionViewModel _selectedQuestion;

        public QuestionViewModel SelectedQustion {
            get { return _selectedQuestion; }
            set {
                _selectedQuestion = value;

            }
        }


    }
}
