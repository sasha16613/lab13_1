using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using lab13_1.Models;
using System.Runtime.InteropServices;

namespace lab13_1.Data
{
    public class ClientDB
    {
        SQLiteConnection database;
        public ClientDB(string databasePath)
        {

            database = new SQLiteConnection(databasePath);
            database.CreateTable<Client>();
            database.CreateTable<Tour>();
            database.CreateTable<Visa>();
        }

        public IEnumerable<Client> GetItems()
        {
            return database.Table<Client>().ToList();
        }

        public Client GetClient(string name)
        {
            return database.Table<Client>().FirstOrDefault(x => x.Name == name);
        }

        public Tour GetTour(Client client)
        {
            return database.Get<Tour>(database.Table<Tour>().FirstOrDefault(x => x.Client == client.ClientID).TourID);
        }

        public Visa GetVisa(Tour tour)
        {
            return database.Get<Visa>(database.Table<Visa>().FirstOrDefault(x => x.VisaID == tour.Visa_t).VisaID);
        }

        public int DeleteItem(int id)
        {
            //Client client = database.Find<Client>(id);

            //Tour tour = new Tour();
            //Tour tour = database.Table<Tour>().FirstOrDefault(x => x.Client == id);

            database.Delete<Visa>(database.Table<Tour>().FirstOrDefault(x => x.Client == id).Visa_t);
            database.Delete<Tour>(database.Table<Tour>().FirstOrDefault(x => x.Client == id).TourID);
            return database.Delete<Client>(id);
        }

        //public int SaveItem(Client item)
        //{
        //    if (item.ClientID != 0)
        //    {
        //        database.Update(item);
        //        return item.ClientID;
        //    }
        //    else
        //    {
        //        return database.Insert(item);
        //    }
        //}

        public int SaveItem(Client client, Tour tour, Visa visa)
        {
            if (database.Table<Client>().FirstOrDefault(x => x.Name == client.Name) != null)
            {
                database.Update(visa);
                database.Update(client);
                tour.Client = client.ClientID;
                tour.Visa_t = visa.VisaID;
                database.Update(tour);
                return client.ClientID;
            }
            else
            {
                database.Insert(visa);
                database.Insert(client);
                tour.Client = client.ClientID;
                tour.Visa_t = visa.VisaID;
                return database.Insert(tour);
                //return database.Insert(client);
            }
        }
    }
}
