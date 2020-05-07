using System;
using Xamarin.Forms;

namespace WorkMate
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();

        }

        //Basic Login Validation for pre selected username and password
        async void Button_Clicked(object sender, EventArgs e)
        {
            if (_username.Text == "admin" && _password.Text == "root")
            {
                await Navigation.PushModalAsync(new NavigationPage(new MainPage()));
            }
            else
            {
                await DisplayAlert("", "--NOT AUTHORISED--", "OK");
            }


        }

        protected override bool OnBackButtonPressed()
        {
            return true;
        }
    }
    }

