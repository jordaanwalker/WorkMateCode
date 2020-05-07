using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace WorkMate
{

    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

        }
        protected override bool OnBackButtonPressed()
        {
            return true;
        }

        async void Button_Clicked(object sender, EventArgs args)
        {
            await Navigation.PushModalAsync(new NavigationPage(new StartDay()));

        }
        async void Button_Clicked1(object sender, EventArgs args)
        {
            await Navigation.PushModalAsync(new NavigationPage(new JobsCompleted()));

        }

        async void Button_Clicked2(object sender, EventArgs args)
        {
            await Navigation.PushModalAsync(new NavigationPage (new EndDay()));

        }

       async void Button_Clicked3(object sender, EventArgs args)
        {
            await Navigation.PushModalAsync(new NavigationPage(new LoginPage()));

        }


    }

    }

