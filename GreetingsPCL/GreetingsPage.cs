using System;

using Xamarin.Forms;

namespace GreetingsPCL
{
	public class GreetingsPage : ContentPage
	{
		public GreetingsPage()
		{
			Label lbl = new Label()
			{
				Text = "Greetings from Xamarin forms"
			};

			Button btn = new Button()
			{
				Text = "Tap the button ",
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
				FontAttributes = FontAttributes.Bold,
				FontFamily = Device.OnPlatform(	null,"Lobster-Regular.ttf#Lobster-Regular",null)
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

