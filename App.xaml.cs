using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;

namespace CryptoTracker
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            AppCenter.Start("ios= e652e118-f534-4044-9218-48f984e7915f;android= e652e118-f534-4044-9218-48f984e7915f;uwp= e652e118-f534-4044-9218-48f984e7915f;windowsdesktop=e652e118-f534-4044-9218-48f984e7915f", typeof(Analytics), typeof(Crashes));
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
