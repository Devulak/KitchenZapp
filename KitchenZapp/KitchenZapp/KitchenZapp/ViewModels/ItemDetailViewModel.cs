using System;

using KitchenZapp.Models;

namespace KitchenZapp.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Account Item { get; set; }

        public ItemDetailViewModel(Account item = null)
        {
            Title = item?.PersonalName;
            Item = item;
        }
    }
}
