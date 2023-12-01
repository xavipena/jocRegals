using JocRegals.Models;
using JocRegals.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace JocRegals.ViewModels
{
    public class PlayerRollViewModel : INotifyPropertyChanged
    {
        private bool _state;
        private bool _altState;
        public bool State
        {
            get { return _state; }
            set { _state = value; OnPropertyChanged(); }
        }
        public bool AltState
        {
            get { return _altState; }
            set { _altState = value; OnPropertyChanged(); }
        }

        private string _plName;
        public string PlayerName
        {
            get { return _plName; }
            set
            {
                if (_plName != value)
                {
                    _plName = value; OnPropertyChanged();
                }
            }
        }

        private string _pTitle;
        public string PageTitle
        {
            get { return _pTitle; }
            set { _pTitle = value; OnPropertyChanged(); }
        }

        readonly int players = 0;
        bool rolling = true;

        public PlayerRollViewModel()
        {
            players = Singleton.listOfPlayers.Count;
            PageTitle = Singleton.currentRound == Round.First ? "Primera volta" : "Segona volta";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void StartRoller()
        {
            while (rolling)
            {
                DiceRoll();
                StopRoller();
            }
        }

        public void StopRoller()
        {
            rolling = false;
        }

        public void DiceRoll()
        {
            // roll the dice
            Random rnd = new Random();
            int dice = rnd.Next(1, players +1);

            // get name
            foreach (Player player in Singleton.listOfPlayers)
            {
                if (player.PlayerID == dice)
                {
                    PlayerName = player.PlayerName;
                    break;
                }
            }
        }
    }
}
