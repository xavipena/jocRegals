using JocRegals.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using JocRegals.Pages;

namespace JocRegals.ViewModels
{
    public class SecondRoundViewModel : INotifyPropertyChanged
    {
        private bool _state;
        public bool State
        {
            get { return _state; }
            set { _state = value; OnPropertyChanged(); }
        }

        private string _result;
        public string Result
        {
            get { return _result; }
            set { _result = value; OnPropertyChanged(); }
        }

        private string _clock;
        public string Clock
        {
            get { return _clock; }
            set { _clock = value; OnPropertyChanged(); }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string GetCard()
        {
            string message = string.Empty;

            // roll a dice
            Random rnd = new Random();
            int dice = rnd.Next(1, 7); // 1d6

            switch (dice)
            {
                case 1:
                    message = "Tothom dona els seu regals a la seva dreta";
                    break;
                case 2:
                case 3:
                    message = "Dona un regal teu a qui no en tingui";
                    break;
                case 4:
                    message = "Agafa un regal del jugador de la teva dreta";
                    break;
                case 5:
                case 6:
                    message = "Agafa un regal de qui en tingui més";
                    break;
            }

            return message;
        }

        public int DiceRoll()
        {
            // roll the dice
            Random rnd = new Random();
            int dice = rnd.Next(1, 7); // 1d6

            if (dice >= 5) // 5,6
            {
                Result = "Agafa un regal de qui vulguis";
            }
            else if (dice >= 3) // 3,4
            {
                Result = GetCard();
            }
            else
            {
                Result = "Passes";
            }
            return dice;
        }
    }
}
