    using System;
    using System.IO;
    using Xamarin.Forms;
    using WorkMate.Models;



namespace WorkMate.Views
{
    public class AddStartDay : ContentPage
    {

        private Entry _supervisor;
        private Entry _worker1;
        private Entry _worker2;
        private Entry _worker3;
        private Entry _worker4;
        private Entry _mileage;
        private Button _saveButton;


        //string _dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "startofDay.db3");

        public AddStartDay()
        {
            this.Title = "Start Of Day";


            StackLayout stackLayout = new StackLayout();

            _supervisor = new Entry();
            _supervisor.Keyboard = Keyboard.Text;
            _supervisor.Placeholder = "Supervisor's Name";
            stackLayout.Children.Add(_supervisor);

            _worker1 = new Entry();
            _worker1.Keyboard = Keyboard.Text;
            _worker1.Placeholder = "Worker's Name";
            stackLayout.Children.Add(_worker1);

            _worker2 = new Entry();
            _worker2.Keyboard = Keyboard.Text;
            _worker2.Placeholder = "Worker's Name";
            stackLayout.Children.Add(_worker2);

            _worker3 = new Entry();
            _worker3.Keyboard = Keyboard.Text;
            _worker3.Placeholder = "Worker's Name";
            stackLayout.Children.Add(_worker3);

            _worker4 = new Entry();
            _worker4.Keyboard = Keyboard.Text;
            _worker4.Placeholder = "Worker's Name";
            stackLayout.Children.Add(_worker4);

            _mileage = new Entry();
            _mileage.Keyboard = Keyboard.Text;
            _mileage.Placeholder = "Mileage of Vehicle";
            stackLayout.Children.Add(_mileage);


            _saveButton = new Button();
            _saveButton.Text = "Start Day?";
            _saveButton.Clicked += _saveButton_Clicked;
            stackLayout.Children.Add(_saveButton);

            Content = stackLayout;


        }

        private bool Validate()
        {

            if (string.IsNullOrEmpty(_supervisor.Text))
            {
                DisplayAlert("--REQUIRED--", "Please enter Supervisor Name", "OK");
                return false;
            }

            if (string.IsNullOrEmpty(_worker1.Text))
            {
                DisplayAlert("--REQUIRED--", "Please enter Worker's Name", "OK");
                return false;
            }
      
            return true;
        }


        private async void _saveButton_Clicked(object sender, EventArgs e)
        {
 
            if (Validate())
            {

                
                //var db = new SQLiteConnection(_dbPath);
                //db.CreateTable<startOfDay>();

                //var maxPK = db.Table<startOfDay>().OrderByDescending(c => c.Id).FirstOrDefault();


                startOfDay startofDay = new startOfDay()
                {
                    supervisorName = _supervisor.Text,
                    worker1Name = _worker1.Text,
                    worker2Name = _worker2.Text,
                    worker3Name = _worker3.Text,
                    worker4Name = _worker4.Text,
                    vehicleMilage = _mileage.Text,
                    //fuelIntake = _fuelIntake.Text
                };
                //db.Insert(startofDay);
                await DisplayAlert(null, "--DAY STARTED--", "Ok");
                await Navigation.PopModalAsync();
            }
          
        }
    }
}
    