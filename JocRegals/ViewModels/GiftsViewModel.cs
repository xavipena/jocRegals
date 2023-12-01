using JocRegals.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace JocRegals.ViewModels
{
    internal class GiftsViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<MenuOption> SubMenu { get; set; }
        public string PageTitle { get; set; }
        public string PageSubTitle { get; set; }
        public string InfoLine { get; set; }
        private string _numGifts;
        public string NumGifts
        {
            get { return _numGifts; }
            set
            {
                if (_numGifts != value)
                {
                    _numGifts = value;
                    OnPropertyChanged();
                }
            }
        }
        public GiftsViewModel()
        {
            PageTitle = Singleton.levelOneTitle;
            PageSubTitle = Singleton.levelTwoTitle;
            InfoLine = "Nombre de reglas a sobre de la taula";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public bool NoMissingData()
        {
            bool populated = true;

            populated = populated && NumGifts != string.Empty;

            return populated;
        }
    }
}
