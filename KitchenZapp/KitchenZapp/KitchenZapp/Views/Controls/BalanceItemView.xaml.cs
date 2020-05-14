using KitchenZapp.Models;
using KitchenZapp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KitchenZapp.Views.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BalanceItemView : ContentView
    {
        public static readonly BindableProperty BalanceItemProperty = BindableProperty.Create(nameof(BalanceItem), typeof(BalanceItem), typeof(BalanceItemView), null);

        public BalanceItem BalanceItem
        {
            get => (BalanceItem)GetValue(BalanceItemProperty);
            set => SetValue(BalanceItemProperty, value);
        }

        public BalanceItemView()
        {
            InitializeComponent();
        }
    }
}