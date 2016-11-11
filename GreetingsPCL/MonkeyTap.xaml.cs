using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace GreetingsPCL
{
	public partial class MonkeyTap : ContentPage
	{
		const int sequenceTime = 750;
		protected const int flashDuration = 250;

		const double offLuminosity = 0.4;
		const double onLuminosity = 0.75;


		BoxView[] boxviews;
		Color[] colors = { Color.Red, Color.Blue, Color.Yellow ,Color.Green};
		List<int> sequence = new List<int>();
		int sequenceIndex;
		bool awaitingTaps;
		bool gameEnded;
		Random random = new Random();

		public MonkeyTap()
		{
			InitializeComponent();
			boxviews = new BoxView[] { boxview0, boxview1, boxview2, boxview3 };
			InitializeBoxViewColors();
		}

		void InitializeBoxViewColors()
		{
			for (int index = 0; index < 4; index++)
			{
				boxviews[index].Color = colors[index].WithLuminosity(offLuminosity);
			}
		}

		public void OnStartGameButtonClicked(object sender, EventArgs args)
		{
			System.Diagnostics.Debug.WriteLine("STARTING THE GAME ");
			gameEnded = false;
			StartGameButton.IsVisible = false;
			InitializeBoxViewColors();
			sequence.Clear();
			StartSequence();
		}
		void StartSequence()
		{
			sequence.Add(random.Next(4));
			sequenceIndex = 0;
			Device.StartTimer(TimeSpan.FromMilliseconds(sequenceTime), OnTimerClick);
		}

		bool OnTimerClick()
		{
			if (gameEnded)
				return false;
			FlashBoxView(sequence[sequenceIndex]);
			sequenceIndex++;
			awaitingTaps = sequenceIndex == sequence.Count;
			sequenceIndex = awaitingTaps ? 0 : sequenceIndex;
			return !awaitingTaps;
		}

		protected virtual void FlashBoxView(int index)
		{
			boxviews[index].Color = colors[index].WithLuminosity(onLuminosity);

			Device.StartTimer(TimeSpan.FromMilliseconds(flashDuration), () =>
			{
				if (gameEnded)
				{
					return false;
				}
				
				boxviews[index].Color = colors[index].WithLuminosity(offLuminosity);
				return false;
			});
		}





		protected void OnBoxViewTapped(object sender, EventArgs args)
		{ 
			System.Diagnostics.Debug.WriteLine("BOXVIEW TAPPED");

			if (gameEnded)
				return;
			
 			if (!awaitingTaps)
			{
				EndGame();
				return;
			}


  			BoxView tappedBoxView = (BoxView)sender;
			int index = Array.IndexOf(boxviews, tappedBoxView);
			if (index != sequence[sequenceIndex])
			{
				EndGame();
				return;
			}
			FlashBoxView(index);
			sequenceIndex++;
			awaitingTaps = sequenceIndex<sequence.Count;

			if (!awaitingTaps)
				StartSequence();

		}

		protected virtual void EndGame()
		{
			gameEnded = true;
			for (int index = 0; index < 4; index++)
				boxviews[index].Color = Color.Gray;
			StartGameButton.Text = "Try again?";
			StartGameButton.IsVisible = true;
		}
 
	}
}
