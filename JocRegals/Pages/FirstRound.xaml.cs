using JocRegals.Configuration;
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
    public partial class FirstRound : ContentPage
    {
        private readonly FirstRoundViewModel vm;

        public FirstRound()
        {
            InitializeComponent();
            vm = new FirstRoundViewModel();
            BindingContext = vm;
            vm.State = false;
        }

        private void Dice_Clicked(object sender, EventArgs e)
        {
            if (Singleton.numberOfGifts > 0)
            {
                var player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
                string sound = vm.DiceRoll() ? Sound.Success : Sound.Failure;
                player.Load(sound);
                player.Play();
                if (Singleton.numberOfGifts <= 0)
                {
                    vm.State = true;
                }
            }
            else vm.Message = "Ara passem a la segona volta!";
        }

        private void Continue_Clicked(object sender, EventArgs e)
        {
            // Go to second round
            Singleton.currentRound = Round.Second;
            Navigation.PushAsync(new PlayerRoll());
        }
    }
}