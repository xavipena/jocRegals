using JocRegals.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace JocRegals.ViewModels
{
    public class TimersViewModel : INotifyPropertyChanged
    {
        public string PageTitle { get; set; }
        public string PageSubTitle { get; set; }
        public string InfoLine { get; set; }

        private string numMinutes;
        public string NumMinutes
        {
            get { return numMinutes; }
            set
            {
                if (numMinutes != value)
                {
                    numMinutes = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public TimersViewModel()
        {
            PageTitle = Singleton.levelOneTitle;
            PageSubTitle = Singleton.levelTwoTitle;
            InfoLine = "Temps que dura la segona volta";
        }

        public bool NoMissingData()
        {
            bool populated = true;

            populated = populated && NumMinutes != string.Empty;

            return populated;
        }
    }

}
