using JocRegals.Models;
using JocRegals.ViewModels;
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
    public partial class Players : ContentPage
    {
        readonly PlayersViewModel vm;

        public Players()
        {
            InitializeComponent();
            vm = new PlayersViewModel();
            BindingContext = vm;
            vm.PlayerName = string.Empty;
        }

        private void ImageButtonAdd_Clicked(object sender, EventArgs e)
        {
            if (vm.NoMissingData())
            {
                // Add name to list
                Player pl = new Player
                {
                    PlayerName = vm.PlayerName,
                    PlayerID = Singleton.listOfPlayers.Count() + 1,
                    PlayerPhoto = "noImage.png"
                };
                Singleton.listOfPlayers.Add(pl);
                vm.PlayerList.Add(pl);
                vm.PlayerName = string.Empty;
            }
            else
            {
                DisplayAlert("Error", "No has informat d'un nom", "OK");
            }
        }

        private void ImageButtonEnd_Clicked(object sender, EventArgs e)
        {
            vm.SavePlayersList();
            this.Navigation.PopAsync(); // go back
        }

        async void Handle_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (!(((ListView)sender).SelectedItem is Player))
            {
                return;
            }
            // Clear selection
            ((ListView)sender).SelectedItem = null;

            // do something with await...
            await DisplayAlert("Hey", "Hey", "OK");
        }

        public void Delete(Object Sender, EventArgs args)
        {
            ImageButton button = (ImageButton)Sender;
            StackLayout stack = (StackLayout)button.Parent;
            StackLayout listViewItem = (StackLayout)stack.Parent;
            /*
             * Image    0
             * label    1 <--
             * label    2
             * button   3
             */
            Label label = (Label)listViewItem.Children[1];
            int id = Int32.Parse(label.Text);
            vm.RemovePlayer(id);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            vm.ReadPlayersList();
        }
    }
}