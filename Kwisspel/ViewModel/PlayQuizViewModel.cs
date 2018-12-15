using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace Kwisspel.ViewModel
{
   public class PlayQuizViewModel : ViewModelBase
    {

        private QuizViewModel _quiz;

        public QuizViewModel Quiz
        {
            get { return _quiz; }
        }

        private QuestionViewModel _currentQuestion;

        public QuestionViewModel CurrentQuestion
        {
            get { return _currentQuestion; }
            set
            {
                _currentQuestion = value;
                RaisePropertyChanged();
            }
        }

        private int _questionIndex;

        private int _answersCorrect;

        public int AnswersCorrect
        {
            get { return _answersCorrect; }
            private set
            {
                _answersCorrect = value;  
                RaisePropertyChanged();
            }
        }

        public string ButtonOneText
        {
            get
            {
                if (CurrentQuestion.QuestionOptions.Count > 0)
                {
                    ShowButtonOne = true;
                    return CurrentQuestion.QuestionOptions[0].Anwser;
                }
                ShowButtonOne = false;
                return "";
            }
        }

        public string ButtonTwoText
        {
            get
            {
                if (CurrentQuestion.QuestionOptions.Count > 1)
                {
                    ShowButtonTwo = true;
                    return CurrentQuestion.QuestionOptions[1].Anwser;
                }

                ShowButtonTwo = false;

                return "";
            }
        }

        public string ButtonThreeText
        {
            get
            {
                if (CurrentQuestion.QuestionOptions.Count > 2)
                {
                    ShowButtonThree = true;
                    return CurrentQuestion.QuestionOptions[2].Anwser;
                }
                ShowButtonThree = false;

                return "";
            }
        }

        public string ButtonFourText
        {
            get
            {
                if (CurrentQuestion.QuestionOptions.Count > 3)
                {
                    ShowButtonFour = true;
                    return CurrentQuestion.QuestionOptions[3].Anwser;
                }
                ShowButtonFour = false;

                return "";
            }
        }



        private bool _showButtonOne;
        public bool ShowButtonOne
        {
            get { return _showButtonOne;}
            set
            {
                _showButtonOne = value;
                RaisePropertyChanged();
            }
        }

        private bool _showButtonTwo;
        public bool ShowButtonTwo
        {
            get { return _showButtonTwo;}
            set
            {
                _showButtonTwo = value;
                RaisePropertyChanged();
            }
        }

        private bool _showButtonThree;
        public bool ShowButtonThree
        {
            get { return _showButtonThree;}
            set
            {
                _showButtonThree = value;
                RaisePropertyChanged();
            }
        }

        private bool _showButtonFour;
        public bool ShowButtonFour
        {
            get { return _showButtonFour;}
            set { _showButtonFour = value;
                RaisePropertyChanged(); }
        }

        private bool _showEndScreen;
        public bool ShowEndScreen
        {
            get { return _showEndScreen;}
            set
            {
                _showEndScreen = value;
                RaisePropertyChanged();
            }
        }

        public RelayCommand PressButtonOneCommand { get; set; }
        public RelayCommand PressButtonTwoCommand { get; set; }
        public RelayCommand PressButtonThreeCommand { get; set; }
        public RelayCommand PressButtonFourCommand { get; set; }

        public PlayQuizViewModel(QuizViewModel quiz)
        {
            _quiz = quiz;
            _questionIndex = 0;
            CurrentQuestion = Quiz.Questions[_questionIndex];
            ShowEndScreen = false;
            PressButtonOneCommand = new RelayCommand(PressButtonOne);
            PressButtonTwoCommand = new RelayCommand(PressButtonTwo);
            PressButtonThreeCommand = new RelayCommand(PressButtonThree);
            PressButtonFourCommand = new RelayCommand(PressButtonFour);

        }

        private void PressButtonOne()
        {
            if (CurrentQuestion.QuestionOptions[0].IsAnwser)
            {
                AnswersCorrect++;
            }
           NextQuestion();
        }

        private void PressButtonTwo()
        {
            if (CurrentQuestion.QuestionOptions[1].IsAnwser)
            {
                AnswersCorrect++;
            }
            NextQuestion();
        }

        private void PressButtonThree()
        {
            if (CurrentQuestion.QuestionOptions[2].IsAnwser)
            {
                AnswersCorrect++;
            }
            NextQuestion();
        }

        private void PressButtonFour()
        {
            if (CurrentQuestion.QuestionOptions[3].IsAnwser)
            {
                AnswersCorrect++;
            }
            NextQuestion();
        }

        private void NextQuestion()
        {
            _questionIndex++;

            if (_quiz.Questions.Count > _questionIndex)
            {
                CurrentQuestion = _quiz.Questions[_questionIndex];
            }
            else
            {
                EndGame();
            }
        }

        private void EndGame()
        {
            ShowEndScreen = true;
            ShowButtonOne = false;
            ShowButtonTwo = false;
            ShowButtonThree = false;
            ShowButtonFour = false;
        }

    }
}
