using JocRegals.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace JocRegals.ViewModels
{
    class PlayersViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Player> PlayerList { get; set; }

        public string PageTitle { get; set; }
        public string PageSubTitle { get; set; }
        public string InfoLine { get; set; }

        private string _playerName;
        public string PlayerName
        {
            get { return _playerName; }
            set
            {
                if (_playerName != value)
                {
                    _playerName = value;
                    OnPropertyChanged();
                }
            }
        }

        public PlayersViewModel()
        {
            PlayerList = new ObservableCollection<Player>();

            PageTitle = Singleton.levelOneTitle;
            PageSubTitle = Singleton.levelTwoTitle;
            InfoLine = "Jugadors que poden rebre els regals";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public bool NoMissingData()
        {
            bool populated = true;

            populated = populated && PlayerName != string.Empty;

            return populated;
        }

        public void ReadPlayersList()
        {
            PlayerList.Clear();

            foreach (var player in Singleton.listOfPlayers)
            {
                PlayerList.Add(player);
            }
        }

        public void SavePlayersList()
        {
            Singleton.listOfPlayers.Clear();

            foreach (Player player in PlayerList)
            {
                Singleton.listOfPlayers.Add(player);
            }
        }

        public void RemovePlayer(int pl)
        {
            foreach (Player player in PlayerList)
            {
                if (player.PlayerID == pl)
                {
                    PlayerList.Remove(player);
                    break;
                }
            }
        }
    }
}
