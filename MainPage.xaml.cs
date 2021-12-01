using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using RestSharp;
using Newtonsoft.Json;
using CryptoTracker.Model;
using Microsoft.AppCenter.Crashes;

namespace CryptoTracker
{
    public partial class MainPage : ContentPage
    {
        private string apiKey = "465A20FE-4799-4E6F-9F2F-56105706B54F";
        private string baseImageUrl = "https://s3.eu-central-1.amazonaws.com/bbxt-static-icons/type-id/png_32/";

        public MainPage()
        {
            InitializeComponent();
            coinListView.ItemsSource = GetCoins();
        }

        private void RefreshButton_Clicked(object sender, EventArgs e)
        {
            coinListView.ItemsSource = GetCoins();
        }

        private List<Coin> GetCoins()
        {
            List<Coin> coins;

            System.Net.ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicy) => { return true; };
            var client = new RestClient("https://rest.coinapi.io/v1/assets?filter_asset_id=BTC;ETH;XMR;USDT;DOGE");
            var request = new RestRequest(Method.GET);
            request.AddHeader("X-CoinAPI-Key", apiKey);

            var response = client.Execute(request);

            coins = JsonConvert.DeserializeObject<List<Coin>>(response.Content);

            foreach (var c in coins)
            {
                if (!String.IsNullOrEmpty(c.id_icon))
                    c.icon_URL = baseImageUrl + c.id_icon.Replace("-", "") + ".png";
                else
                    c.icon_URL = "";
            }
            return coins;

        }
    }
}
