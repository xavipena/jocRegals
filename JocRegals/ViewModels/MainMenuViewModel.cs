using JocRegals.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace JocRegals.ViewModels
{
    public class MainMenuViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<MenuOption> MainMenuOps { get; set; }

        private bool _state;
        public bool State
        {
            get { return _state; }
            set { _state = value; OnPropertyChanged(); }
        }
        public string _data_1;
        public string _data_2;
        public string _data_3;
        public string Data_1
        {
            get { return _data_1; }
            set { _data_1 = value; OnPropertyChanged(); }
        }
        public string Data_2
        {
            get { return _data_2; }
            set { _data_2 = value; OnPropertyChanged(); }
        }
        public string Data_3
        {
            get { return _data_3; }
            set { _data_3 = value; OnPropertyChanged(); }
        }

        public MainMenuViewModel()
        {
            MainMenuOps = new ObservableCollection<MenuOption>();
            MenuOptionList mainOptions = LoadMenuOptions();
            foreach (MenuOption mo in mainOptions)
            {
                MainMenuOps.Add(mo);
            }
            Data_1 = "Jugadors... 0";
            Data_2 = "Minuts..... 0";
            Data_3 = "Regals..... 0";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private MenuOptionList LoadMenuOptions()
        {
            MenuOptionList mopl = new MenuOptionList
            {
                new MenuOption
                {
                    MenuID = 1,
                    Description = "Afegir el nom dels jugadors",
                    IimageSource = "noImage.png"
                },
                new MenuOption
                {
                    MenuID = 2,
                    Description = "Donar el temps del rellotge",
                    IimageSource = "clock.png"
                },
                new MenuOption
                {
                    MenuID = 3,
                    Description = "Comptar els obsequis",
                    IimageSource = "gift.png"
                }
            };
            return mopl;
        }

        public void SaveCurrentSelection(int option)
        {
            Singleton.levelOneSelection = option;
            foreach (MenuOption mo in MainMenuOps)
            {
                if (mo.MenuID == option)
                {
                    Singleton.levelOneTitle = mo.Description;
                }
            }
        }

        public void UpdateScreenTotals()
        {
            Data_1 = "Jugadors... " + Singleton.listOfPlayers.Count.ToString();
            Data_2 = "Minuts..... " + Singleton.gameMinutes.ToString();
            Data_3 = "Regals..... " + Singleton.numberOfGifts.ToString();

            // if completed, can continue
            if (Singleton.listOfPlayers.Count > 0
             && Singleton.gameMinutes > 0
             && Singleton.numberOfGifts > 0)
            {
                // Show button to continue
                State = true;
            }
            else State = false;
        }

        public void LoadSampleData()
        {
            for (int i = 1; i <= 3; i++)
            {
                Player player = new Player()
                {
                    PlayerID = Singleton.listOfPlayers.Count() + 1,
                    PlayerPhoto = "noImage.png",
                    PlayerName = "Player " + i.ToString()
                };
                Singleton.listOfPlayers.Add(player);
            }
            Singleton.gameMinutes = 1;
            Singleton.numberOfGifts = 2;
        }
    }
}
