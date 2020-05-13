using System;
using System.Collections.Generic;
using System.Linq;

namespace KitchenZapp.Models
{
    public class Account
    {
        public string Id { get; set; }
        public string PersonalName { get; set; }
        public int DoorNumber { get; set; }
        public DateTime Birthday { get; set; } = DateTime.UtcNow.Date;
        public string Phone { get; set; }
        public int TagID { get; set; }

        public List<BalanceItem> BalanceItems { get; set; } = new List<BalanceItem>();

        public double Balance => BalanceItems.Sum(o => o.Total);

        public bool IsBalanceNegative => Balance < 0;
    }
}
