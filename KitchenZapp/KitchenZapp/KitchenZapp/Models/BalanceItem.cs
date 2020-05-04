using System;

namespace KitchenZapp.Models
{
    public class BalanceItem
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Amount { get; set; } = 1;

        public double Total => -Price * Amount;

        public bool IsTotalNegative => Total < 0;
    }
}
