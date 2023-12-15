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
    public partial class MainMenu : ContentPage
    {
        private readonly MainMenuViewModel vm;

        public MainMenu()
        {
            InitializeComponent();
            vm = new MainMenuViewModel();
            BindingContext = vm;
            vm.State = false;
            // -----------------------------
            // TOREMOVE
            // test data
            // -----------------------------
            //vm.LoadSampleData();
            // -----------------------------
        }

        private async void Handle_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            // MenuOption men = ((ListView)sender).SelectedItem as MenuOption;
            // if (men == null)
            // this is:
            if (!(((ListView)sender).SelectedItem is MenuOption men))
            {
                return;
            }

            // Clear selection
            ((ListView)sender).SelectedItem = null;

            Singleton.icon = men.IimageSource;
            vm.SaveCurrentSelection(men.MenuID);
            switch (men.MenuID)
            {
                case Options.PLAYERS:
                    await Navigation.PushAsync(new Players());
                    break;

                case Options.TIMERS:
                    await Navigation.PushAsync(new Timers());
                    break;

                case Options.GIFTS:
                    await Navigation.PushAsync(new Gifts());
                    break;
            }
        }
        private void ImageButtonContinue_Clicked(object sender, EventArgs e)
        {
            // Go to second round
            Singleton.currentRound = Round.First;
            Navigation.PushAsync(new PlayerRoll());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            vm.UpdateScreenTotals();
        }
    }
}