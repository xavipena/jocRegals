using JocRegals.Models;
using JocRegals.ViewModels;
using JocRegals.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JocRegals.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlayerRoll : ContentPage
    {
        readonly PlayerRollViewModel vm;

        public PlayerRoll()
        {
            InitializeComponent();
            vm = new PlayerRollViewModel();
            BindingContext = vm;
            vm.AltState = true;
            vm.State = false;
        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            vm.StartRoller();
            if (vm.PlayerName != string.Empty)
            {
                // Show OK button
                vm.AltState = false;
                vm.State = true;
            }
        }

        private void ImageButtonContinue_Clicked(object sender, EventArgs e)
        {
            switch (Singleton.currentRound)
            {
                case Round.First:
                    Navigation.PushAsync(new FirstRound());
                    break;

                case Round.Second:
                    Navigation.PushAsync(new SecondRound());
                    break;

                default:
                    Navigation.PopAsync();
                    break;
            }
        }
    }
}