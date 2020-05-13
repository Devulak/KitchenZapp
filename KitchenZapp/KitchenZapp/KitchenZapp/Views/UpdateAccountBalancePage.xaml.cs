using KitchenZapp.Models;
using KitchenZapp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KitchenZapp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UpdateAccountBalancePage : ContentPage
    {
        private UpdateAccountBalanceViewModel ViewModel;

        public UpdateAccountBalancePage(UpdateAccountBalanceViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = ViewModel = viewModel;
        }

        private void OnSave_Clicked(object sender, EventArgs e)
        {
            ViewModel.OnSave();

            Navigation.PopModalAsync();
        }
    }
}