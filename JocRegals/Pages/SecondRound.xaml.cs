using JocRegals.Configuration;
using JocRegals.Models;
using JocRegals.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Timers;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JocRegals.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SecondRound : ContentPage
    {
        private readonly SecondRoundViewModel vm;
        private int seconds = 0;
        private int minutes = 0;
        private System.Timers.Timer aTimer;

        public SecondRound()
        {
            InitializeComponent();
            vm = new SecondRoundViewModel();
            BindingContext = vm;
            vm.State = false;
            minutes = Singleton.gameMinutes;

            SetTimer();
        }

        private void SetTimer()
        {
            vm.Clock = string.Format("{0:00}:{1:00}", minutes, seconds);

            aTimer = new System.Timers.Timer(1000);
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            seconds -= 1;
            if (seconds < 0 )
            {
                seconds = 59;
                minutes -= 1;
                if (minutes < 0)
                {
                    seconds = 0;
                    minutes = 0;
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        aTimer.Stop();
                        aTimer.Dispose();
                        Singleton.currentRound = Round.End;
                        Navigation.PushAsync(new Final());
                    });
                }
            }
            vm.Clock = string.Format("{0:00}:{1:00}", minutes, seconds);
        }

        private void Dice_Clicked(object sender, EventArgs e)
        {
            string soundFile = string.Empty;

            var player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
            int roll = vm.DiceRoll();
            switch (roll)
            {
                case 6:
                case 5:
                    soundFile = Sound.Success;
                    break;

                case 4:
                case 3:
                    soundFile = Sound.Surprise;
                    break;

                case 2:
                case 1:
                    soundFile = Sound.Failure;
                    break;
            }
            player.Load(soundFile);
            player.Play();
        }

        private void Continue_Clicked(object sender, EventArgs e)
        {
            // Go to second round
            Singleton.currentRound = Round.End;
            Navigation.PushAsync(new Final());
        }

        protected override bool OnBackButtonPressed()
        {
            base.OnBackButtonPressed();
            aTimer.Stop();
            aTimer.Dispose();
            return true;
        }
    }
}