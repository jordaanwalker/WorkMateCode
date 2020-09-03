using System;
using Microsoft.WindowsAzure.MobileServices;
using WorkMate.Models;
using Xamarin.Forms;


namespace WorkMate
{
    

    public partial class StartDay : ContentPage
    {

        public static MobileServiceClient client = new MobileServiceClient("");

        //Code used to for path to local database
        //string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "WorkMate.db3");
        public StartDay()

        {
            InitializeComponent();
        }

        private bool Validate()
        {

            // perform test for each field on page
            if (string.IsNullOrEmpty(_supervisorName.Text))
            {
                DisplayAlert("--REQUIRED--", "Please enter Supervisor Name", "OK");
                return false;
            }

            if (string.IsNullOrEmpty(_vehicleMileage.Text))
            {
                DisplayAlert("--REQUIRED--", "Please enter Vehicle Mileage", "OK");
                return false;
            }
            // repeat for next field - some fields may have different, 
            // or multiple validations, depending on your business rules

            // if all validations pass, then return true
            return true;
        }
        //Code that create the startOfDay table in the local Database
        //var db = new SQLiteConnection(_dbPath);
        //db.CreateTable<startOfDay>();


        async void Button_Clicked(object sender, EventArgs e)
        {

            if (Validate())
            {

                startOfDay startofDay = new startOfDay()
                {
                    id = _id.Text,
                    supervisorName = _supervisorName.Text,
                    worker1Name = _worker1.Text,
                    worker2Name = _worker2.Text,
                    worker3Name = _worker3.Text,
                    worker4Name = _worker4.Text,
                    vehicleMileage = _vehicleMileage.Text

                };
                await client.GetTable<startOfDay>().InsertAsync(startofDay);
                await DisplayAlert(null, "--DAY STARTED--", "Ok");
                await Navigation.PopModalAsync();
               
            }
        }
    }
    }

    
