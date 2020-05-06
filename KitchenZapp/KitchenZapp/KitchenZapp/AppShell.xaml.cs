using KitchenZapp.Views;
using Plugin.NFC;
using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace KitchenZapp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            CrossNFC.Current.OnMessageReceived += OnMessageReceived;
        }

        private async void OnMessageReceived(ITagInfo tagInfo)
        {
            int tagId = BitConverter.ToInt32(tagInfo.Identifier, 0);

            await Navigation.PushModalAsync(new NavigationPage(new NewItemPage()));

            /*User user = ((UsersViewModel)BindingContext).GetFirstOrDefaultUserWithTagId(tagId);

            if (user != null)
            {
                await Navigation.PushAsync(new PersonalUsage((UsersViewModel)BindingContext, user));
            }
            else
            {
                await Navigation.PushAsync(new Registation((UsersViewModel)BindingContext, tagId));
            }*/
        }
    }
}
