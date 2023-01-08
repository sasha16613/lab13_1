using lab13_1.Data;
using lab13_1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using lab13_1.Data;

namespace lab13_1
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            clientsList.ItemsSource = App.Database.GetItems();
            base.OnAppearing();
        }

        // обработка нажатия элемента в списке
        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Client selectedClient = (Client)e.SelectedItem;
            Tour selectedTour = App.database.GetTour(selectedClient);
            Visa selectedVisa = App.database.GetVisa(selectedTour);

            ClientPage clientPage = new ClientPage();

            clientPage.ClientName.Text = selectedClient.Name;
            clientPage.ClientSurname.Text = selectedClient.Surname;

            clientPage.TourPrice.Text = selectedTour.Price.ToString();
            clientPage.TourCountry.Text = selectedTour.Country;

            clientPage.VisaName.Text = selectedVisa.VisaName;
            clientPage.VisaPrice.Text = selectedVisa.VisaPrice.ToString();

            await Navigation.PushAsync(clientPage);
        }

        // обработка нажатия кнопки добавления
        private async void CreateClient(object sender, EventArgs e)
        {
            Client client = new Client();
            ClientPage clientPage = new ClientPage();
            clientPage.BindingContext = client;
            await Navigation.PushAsync(clientPage);
        }
    }
}
