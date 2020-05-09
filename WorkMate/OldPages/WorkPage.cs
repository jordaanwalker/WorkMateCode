/*using System;
using System.Collections.Generic;
using WorkMate.Models;
using Xamarin.Forms;

namespace WorkMate.Views
{
    public class WorkPage : ContentPage
    {

        Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();

        public WorkPage()

        {


            this.Title = "WorkMate";

            StackLayout stackLayout = new StackLayout();
            Button button = new Button();
            Button button1 = new Button();
            Button button2 = new Button();
            button.Text = "Start Day";
            button1.Text = "Add Job";
            button2.Text = "End Day";
            button.Clicked += Button_Clicked;
            //button1.Clicked += Button_Clicked1;
            //button2.Clicked += Button_Clicked2;
            stackLayout.Children.Add(button);
            stackLayout.Children.Add(button1);
            stackLayout.Children.Add(button2);

            Content = stackLayout;


        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new AddStartDay());

        }

        /*
        private async void Button_Clicked1(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new AddJob());
        }

        
        private async void Button_Clicked2(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new AddEndDay());
        }

    

    }
}*/