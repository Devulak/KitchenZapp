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
        public static readonly BindableProperty BalanceItemProperty = BindableProperty.Create(nameof(BalanceItem), typeof(BalanceItemViewModel), typeof(BalanceItemView), null);
        public static readonly BindableProperty BalanceItemRealProperty = BindableProperty.Create(nameof(BalanceItemReal), typeof(BalanceItem), typeof(BalanceItemView), null);

        public BalanceItemViewModel BalanceItem
        {
            get => (BalanceItemViewModel)GetValue(BalanceItemProperty);
            set => SetValue(BalanceItemProperty, value);
        }
        public BalanceItem BalanceItemReal
        {
            get => (BalanceItem)GetValue(BalanceItemRealProperty);
            set
            {
                SetValue(BalanceItemRealProperty, value);
                SetValue(BalanceItemProperty, new BalanceItemViewModel(value));
            }
        }

        public BalanceItemView()
        {
            InitializeComponent();
        }
    }
}