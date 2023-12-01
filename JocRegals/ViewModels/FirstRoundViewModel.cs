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
    public class FirstRoundViewModel : INotifyPropertyChanged
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

        private string _message;
        public string Message
        {
            get { return _message; }
            set { _message = value; OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public bool DiceRoll()
        {
            bool getOne = false;

            // roll the dice
            Random rnd = new Random();
            int dice = rnd.Next(1, 7); // 1d6

            if (dice >= 5) 
            {
                Singleton.numberOfGifts -= 1;
                Result = "Agafa un regal del centre";
                Message = "Queden " + Singleton.numberOfGifts.ToString() + " regals a la taula";
                getOne = true;
            }
            else
            {
                Result = "Passes";
            }
            return getOne;
        }
    }
}
