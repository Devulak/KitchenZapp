using KitchenZapp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace KitchenZapp.ViewModels
{
    public class UpdateAccountBalanceViewModel : BaseViewModel
    {
        public Account Account { get; set; }
        public ObservableCollection<BalanceItem> Items { get; set; }
        public BalanceItem BalanceItemBeer { get; set; }
        public BalanceItem BalanceItemSoda { get; set; }
        public BalanceItem BalanceItemBigSoda { get; set; }
        public double BalanceAfterCalculation => Account.Balance + BalanceItemBeer.Total + BalanceItemSoda.Total + BalanceItemBigSoda.Total;
        public bool IsBalanceAfterCalculationNegative => BalanceAfterCalculation < 0;

        public ICommand AddToItem { get; }
        public ICommand SubtractFromItem { get; }

        public UpdateAccountBalanceViewModel(Account account)
        {
            Account = account;

            BalanceItemBeer = new BalanceItem
            {
                Description = "Beer can (330 ml)",
                Price = 5,
                Amount = 0
            };

            BalanceItemSoda = new BalanceItem
            {
                Description = "Soda can (330 ml)",
                Price = 6,
                Amount = 0
            };

            BalanceItemBigSoda = new BalanceItem
            {
                Description = "Soda bottle (1.5 L)",
                Price = 15,
                Amount = 0
            };

            AddToItem = new Command<BalanceItem>(o => OnAdd(o));
            SubtractFromItem = new Command<BalanceItem>(o => OnSubtract(o));
        }

        void OnAdd(BalanceItem item)
        {
            item.Amount++;
            OnPropertyChanged("BalanceItemBeer");
        }

        void OnSubtract(BalanceItem item)
        {
            if (item.Amount > 0)
            {
                item.Amount--;
            }
        }
    }
}
