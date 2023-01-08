using lab13_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace lab13_1
{
    public partial class ClientPage : ContentPage
    {
        public ClientPage()
        {
            InitializeComponent();
        }

        private void SaveClient(object sender, EventArgs e)
        {
            Client client = new Client();
            Tour tour = new Tour();
            Visa visa = new Visa();

            client.Name = ClientName.Text;
            client.Surname = ClientSurname.Text;

            tour.Price = int.Parse(TourPrice.Text);
            tour.Country = TourCountry.Text;

            visa.VisaPrice = int.Parse(VisaPrice.Text);
            visa.VisaName = VisaName.Text;
            //var client = (Client)BindingContext;
            //var tour = (Tour)BindingContext;

            //tour.Client = client.ClientID;

            if (!String.IsNullOrEmpty(client.Name))
            {
                //App.Database.SaveItem(client);

                App.Database.SaveItem(client, tour, visa);
            }
            this.Navigation.PopAsync();
        }

        private void DeleteClient(object sender, EventArgs e)
        {
            //Client client = new Client();
            //Tour tour = new Tour();

            //client.Name = ClientName.Text;
            //client.Surname = ClientSurname.Text;

            //tour.Price = int.Parse(TourPrice.Text);
            //tour.Country = TourCountry.Text;

            //var client = (Client)BindingContext;
            //var tour = (Tour)BindingContext;

            App.Database.DeleteItem(App.database.GetClient(ClientName.Text).ClientID);
            //App.Database.DeleteItem(tour.TourID);
            this.Navigation.PopAsync();
        }
        private void Cancel(object sender, EventArgs e)
        {
            this.Navigation.PopAsync();
        }
    }
}
