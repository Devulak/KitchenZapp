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
        public UpdateAccountBalancePage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = viewModel;
        }
    }
}