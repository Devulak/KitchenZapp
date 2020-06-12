using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using KitchenZapp.Services;
using KitchenZapp.Views;
using Plugin.NFC;
using System.Threading.Tasks;
using System.Threading;

namespace KitchenZapp
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<SimpleDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
            Task.Run(() =>
            {
                CrossNFC.Current.StartListening();
            });
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
            Task.Run(() =>
            {
                CrossNFC.Current.StartListening();
            });
        }
    }
}
