using KitchenZapp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace KitchenZapp.ViewModels
{
    public class UpdateAccountBalanceViewModel : BaseViewModel
    {
        public Account Account { get; }
        public ObservableCollection<BalanceItem> Items { get; }
        public double BalanceAfterCalculation => Account.Balance + Items.Sum(o => o.Total);
        public bool IsBalanceAfterCalculationNegative => BalanceAfterCalculation < 0;

        public ICommand AddToItem { get; }
        public ICommand SubtractFromItem { get; }
        public ICommand Save { get; }

        public UpdateAccountBalanceViewModel(Account account)
        {
            Account = account;

            Items = new ObservableCollection<BalanceItem>
            {
                new BalanceItem
                {
                    Description = "Beer can (330 ml)",
                    Price = 5,
                    Amount = 0
                },
                new BalanceItem
                {
                    Description = "Soda can (330 ml)",
                    Price = 6,
                    Amount = 0
                },
                new BalanceItem
                {
                    Description = "Soda bottle (1.5 L)",
                    Price = 15,
                    Amount = 0
                }
            };

            AddToItem = new Command<BalanceItem>(o => OnAdd(o));
            SubtractFromItem = new Command<BalanceItem>(o => OnSubtract(o));
            Save = new Command(o => OnSave());
        }

        void OnAdd(BalanceItem item)
        {
            item.Amount++;
            OnPropertyChanged("Items");
            OnPropertyChanged("BalanceAfterCalculation");
            OnPropertyChanged("IsBalanceAfterCalculationNegative");
        }

        void OnSubtract(BalanceItem item)
        {
            if (item.Amount > 0)
            {
                item.Amount--;
                OnPropertyChanged("Items");
                OnPropertyChanged("BalanceAfterCalculation");
                OnPropertyChanged("IsBalanceAfterCalculationNegative");
            }
        }

        void OnSave()
        {
            foreach (BalanceItem balanceItem in Items)
            {
                if (balanceItem.Amount <= 0)
                {
                    balanceItem.DateTime = DateTime.UtcNow.Date;
                    Account.BalanceItems.Add(balanceItem);
                }
            }
        }
    }
}
