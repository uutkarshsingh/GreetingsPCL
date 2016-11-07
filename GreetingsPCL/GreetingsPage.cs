using System;

using Xamarin.Forms;

namespace GreetingsPCL
{
	public class GreetingsPage : ContentPage
	{
		public GreetingsPage()
		{
			Label lbl = new Label();
			lbl.Text = "Greetings from Xamarin forms";
			this.Content = lbl;		
		}
	}
}

