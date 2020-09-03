using System;
using System.IO;
using Microsoft.WindowsAzure.MobileServices;
using WorkMate.Models;
using Xamarin.Forms;

namespace WorkMate
{
    public partial class EndDay : ContentPage
    {
        //connection string to Azure Web App
        public static MobileServiceClient client = new MobileServiceClient("");

        //creating old local database path
       // string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "WorkMate.db3");

        public EndDay()
        {
            InitializeComponent();
        }

        private bool Validate()
        {

            // perform test for each field on page
            if (string.IsNullOrEmpty(_vehicleMileage.Text))
            {
                DisplayAlert("--REQUIRED--", "Please enter Vehicle Mileage", "OK");
                return false;
            }

            if (string.IsNullOrEmpty(_fuelIntake.Text))
            {
                DisplayAlert("--REQUIRED--", "Please enter Fuel Intake, if none enter 'N/A' ", "OK");
                return false;
            }
 
            // if all validations pass, then return true
            return true;
        }
        async void Button_Clicked(object sender, EventArgs e)
        {
            if (Validate())
            {
                /*
                First attempt at creating a local database
                */
                // var db = new SQLiteConnection(_dbPath);
                //db.CreateTable<endOfDay>();

                endOfDay endofDay = new endOfDay()
                {
                    id = _id.Text,
                    vehicleMileage = _vehicleMileage.Text,
                    fuelIntake = _fuelIntake.Text
                };

                //Sync to Azure SQL Database
                await client.GetTable<endOfDay>().InsertAsync(endofDay);
                await DisplayAlert(null, "--DAY ENDED--", "Ok");
                await Navigation.PopModalAsync();
            }

        }
    }
}
