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
    public partial class Timers : ContentPage
    {
        private readonly TimersViewModel vm;
        public Timers()
        {
            InitializeComponent();
            vm = new TimersViewModel();
            BindingContext = vm;
        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            if (vm.NoMissingData())
            {
                if (int.TryParse(vm.NumMinutes.ToString(), out Singleton.gameMinutes))
                {
                    Navigation.PopAsync(); // go back
                }
                else
                {
                    DisplayAlert("Avís", "Cal que sigui un número", "OK");
                }
            }
            else
            {
                DisplayAlert("Avís", "Cal posar un número", "OK");
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            vm.NumMinutes = Singleton.gameMinutes.ToString();
        }
    }
}