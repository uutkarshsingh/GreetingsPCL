using System;

using Xamarin.Forms;

namespace GreetingsPCL
{
	public class GreetingsPage : ContentPage
	{
		public GreetingsPage()
		{
			//There are some methods in which we can chekc whether the device belongs to a particular variety
			//I have mentioned those in the comments.
			this.BackgroundColor = Color.Default;

			if (Device.OS == TargetPlatform.iOS)
			{
				System.Diagnostics.Debug.WriteLine("Checkign whether the application is in the the iOS platform ");
			}
			else if (Device.OS == TargetPlatform.Android)
			{
				System.Diagnostics.Debug.WriteLine("ANDROID PLATFORM");
			}
			Label lbl = new Label()
			{
				Text = "Greetings from Xamarin forms",
				HorizontalOptions = LayoutOptions.Center,
				HorizontalTextAlignment = TextAlignment.Center,
				BackgroundColor = Color.Accent,
				TextColor = Color.Accent
			};

			Button btn = new Button()
			{
				Text = "Tap the button ",
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
				FontAttributes = FontAttributes.Bold,
				FontFamily = Device.OnPlatform(	null,"Lobster-Regular.ttf#Lobster-Regular",null) ,
				BackgroundColor = Color.Accent,
				TextColor = Color.Accent,
				HorizontalOptions = LayoutOptions.Center
			};
			this.Padding = new Thickness(0, 20, 0, 0);
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

