using KitchenZapp.Models;
using KitchenZapp.ViewModels;
using KitchenZapp.Views;
using Plugin.NFC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace KitchenZapp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            //if (CrossNFC.IsSupported)
            //{
            //    if (CrossNFC.Current.IsAvailable)
            //    {
            //        if (CrossNFC.Current.IsEnabled)
            //        {
            //            CrossNFC.Current.OnMessageReceived += Current_OnMessageReceived;
            //        }
            //    }
            //}
            CrossNFC.Current.OnMessageReceived += OnMessageReceived;
        }

        private async void OnMessageReceived(ITagInfo tagInfo)
        {
            int tagID = BitConverter.ToInt32(tagInfo.Identifier, 0);
            await DisplayAlert("NFC chip found!", tagID.ToString(), "OK");

            ItemsViewModel itemsViewModel = new ItemsViewModel();

            Account account = itemsViewModel.Items.FirstOrDefault(o => o.TagID == tagID);

            if (account != null) // Found
            {
                await Navigation.PushModalAsync(new NavigationPage(new AccountEditPage(new ItemDetailViewModel(account))));
            }
            else // Not found, open register window
            {
                await Navigation.PushModalAsync(new NavigationPage(new NewItemPage()));
            }
        }
    }
}
