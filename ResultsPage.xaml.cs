using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Spokesman.Model;
using Xamarin.Forms;

namespace Spokesman
{
	public partial class ResultsPage : ContentPage
	{
		public ObservableCollection<Rider> _riders { get; set; }

		protected override void OnAppearing()
		{
			base.OnAppearing();
		}

		public ResultsPage()
		{
			BindingContext = _riders;

			InitializeComponent();

			//_riders = new ObservableCollection<Rider>();

			//initializeList();


			var seriesList = new List<String> { "Phat Wednesday 2016", "Phat Wednesday 2017" };

			var names = new List<String>
			{
				"Race 1: racename", "Race 2: another race name", "Race 3: this is a third race", "Race 4: the last race"
			};

			var leagues = new List<String>
			{
				"Male Open(18+)", "Female Open(18+)", "Master Male(30-39)", "Veteran Male(40+)", "Junior Male(14-17)", "Male Grom (13 and under)", "Junior Female(17 and under)"
			};

			//mainCarousel.ItemsSource = names;

			//leagueCarousel.ItemsSource = leagues;

			var raceSeriesTapGesture = new TapGestureRecognizer();
			raceSeriesTapGesture.Tapped += (s, e) =>
			{
				raceSeriesMenu();
			};
			RaceSeriesBox.GestureRecognizers.Add(raceSeriesTapGesture);
            raceSeriesLabel.GestureRecognizers.Add(raceSeriesTapGesture);
            raceSeriesDownArrow.GestureRecognizers.Add(raceSeriesTapGesture);
            raceSeriesTitle.GestureRecognizers.Add(raceSeriesTapGesture);

			async void raceSeriesMenu()
			{
				await Navigation.PushModalAsync(new RaceSeriesMenuPage());
			}

			var raceCategoryTapGesture = new TapGestureRecognizer();
			raceCategoryTapGesture.Tapped += (s, e) =>
			{
				raceCategoryMenu();
			};
			sortByDownArrow.GestureRecognizers.Add(raceCategoryTapGesture);
			sortByTitle.GestureRecognizers.Add(raceCategoryTapGesture);
			SortByBox.GestureRecognizers.Add(raceCategoryTapGesture);
			SortByLabel.GestureRecognizers.Add(raceCategoryTapGesture);


			async void raceCategoryMenu()
			{
				await Navigation.PushModalAsync(new RaceCategoryMenuPage());
			}

		}

        void BtnMaleOpenClicked(object sender, System.EventArgs e)
        {
            DisplayAlert("Click", "Male Open", "SWEET!");
        }
		void BtnFemaleOpenClicked(object sender, System.EventArgs e)
		{
			DisplayAlert("Click", "Female Open", "SWEET!");
		}
		void BtnMasterMaleClicked(object sender, System.EventArgs e)
		{
			DisplayAlert("Click", "Master Male", "SWEET!");
		}
		void BtnMasterFemaleClicked(object sender, System.EventArgs e)
		{
			DisplayAlert("Click", "Master Female", "SWEET!");
		}
		void BtnVetMaleClicked(object sender, System.EventArgs e)
		{
			DisplayAlert("Click", "Veteran Male", "SWEET!");
		}
		void BtnJnrMaleClicked(object sender, System.EventArgs e)
		{
			DisplayAlert("Click", "Junior Male", "SWEET!");
		}
		void BtnGromMaleClicked(object sender, System.EventArgs e)
		{
			DisplayAlert("Click", "Grom Male", "SWEET!");
		}
		void BtnJnrFemaleClicked(object sender, System.EventArgs e)
		{
			DisplayAlert("Click", "Junior Female", "SWEET!");
		}

	
    }

	//public class Rider
}