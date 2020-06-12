using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;

namespace KitchenZapp.Models
{
    [Serializable]
    public class Account : ModelBase
    {
        public int Id { get; set; }
        public string PersonalName { get; set; }
        public int DoorNumber { get; set; }
        public DateTime Birthday { get; set; }
        public string Phone { get; set; }
        public int TagID { get; set; }

        public ObservableCollection<BalanceItem> BalanceItems { get; set; } = new ObservableCollection<BalanceItem>();

        public double Balance => BalanceItems.Sum(o => -o.Sum);

        public bool IsBalanceNegative => Balance < 0;

        public Account()
        {
            BalanceItems.CollectionChanged += BalanceItems_CollectionChanged;
        }

        private void BalanceItems_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged("Balance");
            OnPropertyChanged("IsBalanceNegative");
        }
    }
}
