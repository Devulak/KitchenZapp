using KitchenZapp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KitchenZapp.ViewModels
{
    public class BalanceItemViewModel : BaseViewModel
    {
        public BalanceItem BalanceItem { get; }

        public BalanceItemViewModel(BalanceItem balanceItem)
        {
            BalanceItem = balanceItem;
        }

        public int Amount
        {
            get { return BalanceItem.Amount; }
            set
            {
                BalanceItem.Amount = value;
                OnPropertyChanged();
                OnPropertyChanged("Sum");
                OnPropertyChanged("HasAmount");
            }
        }

        public double Sum => Amount * BalanceItem.Price;

        public bool HasAmount => Amount > 0;
    }
}
