using System;
using System.ComponentModel;

namespace KitchenZapp.Models
{
    [Serializable]
    public class BalanceItem : ModelBase
    {
        public string Id { get; set; }

        private string title;
        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                OnPropertyChanged();
            }
        }

        private string subTitle;
        public string SubTitle
        {
            get { return subTitle; }
            set
            {
                subTitle = value;
                OnPropertyChanged();
            }
        }

        private double price;
        public double Price
        {
            get { return price; }
            set
            {
                price = value;
                OnPropertyChanged();
                OnPropertyChanged("Sum");
                OnPropertyChanged("IsTotalNegative");
            }
        }

        private int amount;
        public int Amount
        {
            get { return amount; }
            set
            {
                amount = value;
                OnPropertyChanged();
                OnPropertyChanged("Sum");
                OnPropertyChanged("IsTotalNegative");
            }
        }

        private DateTime dateTime;
        public DateTime DateTime
        {
            get { return dateTime; }
            set
            {
                dateTime = value;
                OnPropertyChanged();
            }
        }

        public double Sum => Price * Amount;

        public bool IsTotalNegative => Sum < 0;
    }
}
