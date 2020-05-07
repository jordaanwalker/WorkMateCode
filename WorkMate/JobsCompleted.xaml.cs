using System;
using Microsoft.WindowsAzure.MobileServices;
using WorkMate.Models;
using Xamarin.Forms;

namespace WorkMate
{
    public partial class JobsCompleted : ContentPage
    {
        public static MobileServiceClient client = new MobileServiceClient("https://workmateprj.azurewebsites.net");

        //string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "WorkMate.db3");
        public JobsCompleted()
        {
            InitializeComponent();
        }

        private bool Validate()
        {

            if (string.IsNullOrEmpty(_job1.Text))
            {
                DisplayAlert("--REQUIRED--", "Please enter completed jobs(s)", "OK");
                return false;
            }

            // if all validations pass, then return true
            return true;
        }
        async void Button_Clicked(object sender, EventArgs e)
        {
            if (Validate())
            {
                //var db = new SQLiteConnection(_dbPath);
                //db.CreateTable<jobsCompleted>();

                jobsCompleted jobscompleted = new jobsCompleted()
                {
                  id = _id.Text,
                  job1 = _job1.Text,
                  job2 = _job2.Text,
                  job3 = _job3.Text,
                  job4 = _job4.Text,
                  job5 = _job5.Text
                };
                await client.GetTable<jobsCompleted>().InsertAsync(jobscompleted);
                await DisplayAlert(null, "--COMPLETED JOBS ENTERED--", "Ok");
                await Navigation.PopModalAsync();
            }

        }
    }
}
