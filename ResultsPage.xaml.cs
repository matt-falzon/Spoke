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
		private ObservableCollection<Rider> _riders;

        public ResultsPage()
        {
            InitializeComponent();

			_riders = new ObservableCollection<Rider>();

			initializeList();

            var seriesList = new List<String> { "Phat Wednesday 2016", "Phat Wednesday 2017" };

            Picker raceSeriesPicker = new Picker
            {
                Title = "Race Series",
                ItemsSource = seriesList
            };

			//tap recognizer for race series
			var raceSeriesTapRecognizer = new TapGestureRecognizer();

			raceSeriesTapRecognizer.Tapped += (s, e) =>
			{
                raceSeriesPicker.IsEnabled = true;
                raceSeriesPicker.IsVisible = true;
                raceSeriesPicker.Focus();
			};
			RaceSeriesBox.GestureRecognizers.Add(raceSeriesTapRecognizer);


			var names = new List<String>
			{
				"Race 1: racename", "Race 2: another race name", "Race 3: this is a third race", "Race 4: the last race"
			};

            var leagues = new List<String>
            {
                "Male Open(18+)", "Female Open(18+)", "Master Male(30-39)", "Veteran Male(40+)", "Junior Male(14-17)", "Male Grom (13 and under)", "Junior Female(17 and under)"
            };

            mainCarousel.ItemsSource = names;
            leagueCarousel.ItemsSource = leagues;

        }

		IEnumerable<Rider> GetRiders(string searchText = null)
		{
			var riders = new List<Rider>
			{
				new Rider("00001", "Jamie Carson", "Scotland", "imageurl", 22, "male"),
				new Rider("00002", "Stefan Koch", "Germany", "imageurl", 38, "male"),
				new Rider("00003", "Matt Falzon", "Australia", "imageurl", 26, "male"),
				new Rider("00004", "Cam Barter", "Canada", "imageurl", 22, "male"),
				new Rider("00005", "Jack Cropton", "Canada", "imageurl", 18, "male"),
				new Rider("00006", "Ed White", "England", "imageurl", 22, "male")
			};

			if (String.IsNullOrWhiteSpace(searchText))
				return riders;

			return riders.Where(c => c.name.StartsWith(searchText));
		}

		private void initializeList()
		{
			Rider[] dummyData =
			{
				new Rider("00001", "Jamie Carson", "Scotland", "imageurl", 22, "male"),
				new Rider("00002", "Stefan Koch", "Germany", "imageurl", 38, "male"),
				new Rider("00003", "Matt Falzon", "Australia", "imageurl", 26, "male"),
				new Rider("00004", "Cam Barter", "Canada", "imageurl", 22, "male"),
				new Rider("00005", "Jack Cropton", "Canada", "imageurl", 18, "male"),
				new Rider("00006", "Ed White", "England", "imageurl", 22, "male")
			};

			for (int i = 0; i < dummyData.Length; i++)
			{
				_riders.Add(dummyData[i]);
			}
            //raceList.ItemsSource = _riders;

		}



		void Handle_TextChanged(object sender, Xamarin.Forms.TextChangedEventArgs e)
		{
           // raceList.ItemsSource = GetRiders(e.NewTextValue);
		}

        async void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
			var rider = e.Item as Rider;

			await Navigation.PushAsync(new RiderDetailPage(rider));
        }
    }
}
