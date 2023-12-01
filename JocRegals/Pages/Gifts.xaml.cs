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
    public partial class Gifts : ContentPage
    {
        readonly GiftsViewModel vm;

        public Gifts()
        {
            vm = new GiftsViewModel();
            BindingContext = vm;
            InitializeComponent();
        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            if (vm.NoMissingData())
            {
                if (int.TryParse(vm.NumGifts.ToString(), out Singleton.numberOfGifts))
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
                DisplayAlert("Avís", "Cal posar un número superior a zero", "OK");
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            vm.NumGifts = Singleton.numberOfGifts.ToString();
        }
    }

}