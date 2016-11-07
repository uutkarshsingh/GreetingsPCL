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
			};

			Button btn = new Button()
			{
				Text = "Tap the button ",
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)),
				FontAttributes = FontAttributes.Bold,
				FontFamily = Device.OnPlatform(	null,"Lobster-Regular.ttf#Lobster-Regular",null) ,
				HorizontalOptions = LayoutOptions.Center
			};
			this.Padding = new Thickness(0, 20, 0, 0);




			Color[] arrayOfColors =
			{
				 Color.White, Color.Silver, Color.Gray, Color.Black, Color.Red,
 				Color.Maroon, Color.Yellow, Color.Olive, Color.Lime, Color.Green,
 				Color.Aqua, Color.Teal, Color.Blue, Color.Navy, Color.Pink,
 				Color.Fuchsia, Color.Purple
			};


			string[] colorNames =
			{
				 "White", "Silver", "Gray", "Black", "Red",
 				"Maroon", "Yellow", "Olive", "Lime", "Green",
 				"Aqua", "Teal", "Blue", "Navy", "Pink",
 				"Fuchsia", "Purple"
			};


			StackLayout stackLayout = new StackLayout();
			stackLayout.Spacing = 0;
			for (int count = 0; count < colorNames.Length; count++)
			{ 
			 	Label label = new Label
				{
					Text = colorNames[count],
					TextColor = arrayOfColors[count],
					FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
				};
				stackLayout.Children.Add(label);

			}

			Button button = new Button
			{
				Text = "Tap me "
			};

			button.Clicked += (( object sender ,EventArgs args )=> {
				System.Diagnostics.Debug.WriteLine("Printing the buttons values");
				stackLayout.Children.Add(new Label
				{
					Text = "Button tapped at " + DateTime.Now.ToString("T")
				});
			}); 

			stackLayout.Children.Add(button);

			ScrollView scrollView = new ScrollView
			{
				Content = stackLayout
			};

			this.Content = scrollView;
		}
	}
}

