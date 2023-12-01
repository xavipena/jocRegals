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
    public partial class Final : ContentPage
    {
        public Final()
        {
            InitializeComponent();

            // Play fanfarre
            var player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current; 
            player.Load(Sound.Final); 
            player.Play();
        }
    }
}