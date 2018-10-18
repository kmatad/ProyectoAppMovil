using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace XmMovies
{
	public partial class App : Application
	{
        public const string WebServiceUrl = "https://api.themoviedb.org/3/";
        public const string ApiKey = "7f0249c7eb0033f5119c659cb689ce8e";
        public const string WebServiceImagePath = "https://image.tmdb.org/t/p/w500_and_h282_face";
        public App ()
		{
			InitializeComponent();

			MainPage = new NavigationPage(new TabsPage());
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
