using System;
using Microsoft.WindowsAzure.MobileServices;
using WorkMate.Models;
using Xamarin.Forms;


namespace WorkMate
{
    

    public partial class StartDay : ContentPage
    {

        public static MobileServiceClient client = new MobileServiceClient("https://workmateprj.azurewebsites.net");

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

            if (string.IsNullOrEmpty(_worker1.Text))
            {
                DisplayAlert("--REQUIRED--", "Please enter Worker's Name", "OK");
                return false;
            }
            // repeat for next field - some fields may have different, 
            // or multiple validations, depending on your business rules

            // if all validations pass, then return true
            return true;
        }

        async void Button_Clicked(object sender, EventArgs e)
        {

            if (Validate())
            {
                //ar db = new SQLiteConnection(_dbPath);
                //db.CreateTable<startOfDay>();


                startOfDay startofDay = new startOfDay()
                {
                    id = _id.Text,
                    supervisorName = _supervisorName.Text,
                    worker1Name = _worker1.Text,
                    worker2Name = _worker2.Text,
                    worker3Name = _worker3.Text,
                    worker4Name = _worker4.Text,
                    vehicleMilage = _vehicleMileage.Text

                };
                await client.GetTable<startOfDay>().InsertAsync(startofDay);
                await DisplayAlert(null, "--DAY STARTED--", "Ok");
                await Navigation.PopModalAsync();
               
            }
        }
    }
    }

    
