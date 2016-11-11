using System;
using Xamarin.Forms;

namespace GreetingsPCL
{
	public partial class GreetingsPCLPage : ContentPage
	{
		public GreetingsPCLPage()
		{
			InitializeComponent();
		}
		public void OnBoxViewTapped(object sender, EventArgs arg)
		{
			System.Diagnostics.Debug.WriteLine("Tapped the BOXVIew");
		}
	}
}
