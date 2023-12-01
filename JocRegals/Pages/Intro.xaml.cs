using JocRegals.Configuration;
using JocRegals.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.Xaml;

namespace JocRegals.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Intro : ContentPage
    {
        public Intro()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            
            btnGo.Clicked += (object sender, EventArgs e) =>
            {
                Navigation.PushAsync(new MainMenu());
            };

            btnPlay.Clicked += (object sender, EventArgs e) =>
            {
                var player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
                if (player.IsPlaying) return;
                player.Load(Sound.Intro);
                player.Play();
            };
        }
    }
}