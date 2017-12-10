using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace MonopolyCash
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();
            //Se va a la detailPage de menuPage que es la que tiene el hamburger menu, despues la navegacion se hara con el atributo Detail de MenuPage
            MainPage = new MenuPage();
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
