using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Spokesman.Model;

using Xamarin.Forms;

namespace Spokesman
{
    public partial class RacesPage : ContentPage
    {
        private ObservableCollection<Rider> _riders;

        public RacesPage()
        {
            InitializeComponent();

            _riders = new ObservableCollection<Rider>();

            initializeList();




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

			raceList.ItemsSource = _riders;
        }

        async void Handle_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            var rider = e.SelectedItem as Rider;

            await Navigation.PushAsync(new RiderDetailPage(rider));
        }

        void Handle_Refreshing(object sender, System.EventArgs e)
        {
            throw new NotImplementedException();
        }

        void Handle_TextChanged(object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            raceList.ItemsSource = GetRiders(e.NewTextValue);
        }
    }
}
