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
        public ObservableCollection<BalanceItemViewModel> Items { get; }
        public double Sum => Items.Sum(o => o.BalanceItem.Sum);
        public double BalanceAfterCalculation => Account.Balance - Sum;
        public bool IsBalanceAfterCalculationNegative => BalanceAfterCalculation < 0;

        public ICommand AddToItem { get; }
        public ICommand SubtractFromItem { get; }
        public ICommand Save { get; }

        public UpdateAccountBalanceViewModel(Account account)
        {
            Account = account;

            Items = new ObservableCollection<BalanceItemViewModel>
            {
                new BalanceItemViewModel(new BalanceItem
                {
                    Title = "Beer can",
                    SubTitle = "330 ml",
                    Price = 5,
                    Amount = 0
                }),
                new BalanceItemViewModel(new BalanceItem
                {
                    Title = "Soda can",
                    SubTitle = "330 ml",
                    Price = 6,
                    Amount = 0
                }),
                new BalanceItemViewModel(new BalanceItem
                {
                    Title = "Soda bottle",
                    SubTitle = "1.5 L",
                    Price = 15,
                    Amount = 0
                })
            };

            AddToItem = new Command<BalanceItemViewModel>(o => OnAdd(o));
            SubtractFromItem = new Command<BalanceItemViewModel>(o => OnSubtract(o));
            Save = new Command(o => OnSave());
        }

        void OnAdd(BalanceItemViewModel item)
        {
            item.Amount++;
            OnPropertyChanged("Sum");
            OnPropertyChanged("BalanceAfterCalculation");
            OnPropertyChanged("IsBalanceAfterCalculationNegative");
        }

        void OnSubtract(BalanceItemViewModel item)
        {
            if (item.Amount > 0)
            {
                item.Amount--;
                OnPropertyChanged("Sum");
                OnPropertyChanged("BalanceAfterCalculation");
                OnPropertyChanged("IsBalanceAfterCalculationNegative");
            }
        }

        public void OnSave()
        {
            foreach (BalanceItemViewModel balanceItemViewModel in Items)
            {
                if (balanceItemViewModel.BalanceItem.Amount > 0)
                {
                    balanceItemViewModel.BalanceItem.DateTime = DateTime.UtcNow.Date;
                    Account.BalanceItems.Add(balanceItemViewModel.BalanceItem);
                }
            }
        }
    }
}
