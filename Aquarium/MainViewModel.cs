using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aquarium
{
    partial class MainViewModel : ObservableObject
    {

        static HttpClient httpClient = new HttpClient();
        CancellationTokenSource cancellationToken= new();
        [ObservableProperty]
        private string ipAddress;
        [ObservableProperty]
        private int waterLevel = 80;
        [ObservableProperty]
        private int temperature = 22;
        [RelayCommand]
        public async Task Update()
        {
            cancellationToken.Cancel();
            cancellationToken = new();
                _ = UpdateWaterLevel(cancellationToken.Token);
                _ = UpdateTemperature(cancellationToken.Token);
        }
        [RelayCommand]
        public async Task FlushWater()
        {
            try
            {
                await App.Current.MainPage.DisplayAlert("Flush water", "Flushing water, make sure you monitor the water level","Ok");
                await httpClient.GetAsync($"http://{IpAddress}/FlushWater");

            }
            catch (Exception)
            {

            }
        }
        [RelayCommand]
        public async Task FillWater()
        {
            try
            {
                await App.Current.MainPage.DisplayAlert("Filling water", "Filling water, make sure you monitor the water level", "Ok");
                //await httpClient.GetAsync($"http://{IpAddress}/FillWater");

            }
            catch (Exception)
            {

            }
        }
        [RelayCommand]
        public async Task FeedFish()
        {
            try
            {
                await App.Current.MainPage.DisplayAlert("Feed fish", "Feeding fish!", "Ok");
                //await httpClient.GetAsync($"http://{IpAddress}/FillWater");

            }
            catch (Exception)
            {

            }
        }
        [RelayCommand]
        public async Task Stop()
        {
            try
            {
                await App.Current.MainPage.DisplayAlert("Stopping", "Stopping...", "Ok");
                await httpClient.GetAsync($"http://{IpAddress}/Stop");

            }
            catch (Exception)
            {

            }
        }
        private async Task UpdateWaterLevel(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
                try
                {
                    var res = await httpClient.GetAsync($"http://{IpAddress}/WaterLevel");
                    WaterLevel = int.Parse(await res.Content.ReadAsStringAsync());
                    
                }
                catch (Exception)
                {

                }

        }
        private async Task UpdateTemperature(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
                try
                {
                    var res = await httpClient.GetAsync($"http://{IpAddress}/Temperature");
                    Temperature = int.Parse(await res.Content.ReadAsStringAsync());

                }
                catch (Exception)
                {

                }

        }
    }
}
