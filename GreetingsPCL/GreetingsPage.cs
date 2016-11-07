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

			Button btn = new Button()
			{
				Text = "Tap the button ",
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
				FontAttributes = FontAttributes.Bold,
				FontSize = 24
			};

			this.Content = new StackLayout()
			{
				Children = {
					btn ,
					lbl
				}
			};
		}
	}
}

