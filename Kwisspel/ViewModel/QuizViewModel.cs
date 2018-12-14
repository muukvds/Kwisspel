using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        }

        public string Name
        {
            get { return _quizze.name; }
            set { _quizze.name = value; RaisePropertyChanged(); }
        }

        public ObservableCollection<QuestionViewModel> Questions { get; set; }

        private Quizze _quizze;

        public Quizze Model
        {
            get { return _quizze; }
        }

        public QuizViewModel()
        {
            _quizze = new Quizze();
            Questions = new ObservableCollection<QuestionViewModel>(_quizze.Questions.ToList().Select(q => new QuestionViewModel(q)));
        }

        public QuizViewModel(Quizze quiz)
        {
            _quizze = quiz;
            Questions = new ObservableCollection<QuestionViewModel>(_quizze.Questions.ToList().Select(q => new QuestionViewModel(q)));
        }

        public void AddQuestion(QuestionViewModel questionViewModel)
        {
            Questions.Add(questionViewModel);
            _quizze.Questions.Add(questionViewModel.Model);
            RaisePropertyChanged();
        }

        public void RemoveQuestion(QuestionViewModel questionViewModel)
        {
            Questions.Remove(questionViewModel);
            _quizze.Questions.Remove(questionViewModel.Model);
            RaisePropertyChanged();
        }

    }
}
