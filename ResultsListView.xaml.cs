using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Spokesman.Model;
using FFImageLoading.Forms;

using Xamarin.Forms;
namespace Spokesman
{
    public partial class ResultsListView : StackLayout
    {
        private ObservableCollection<Rider> _riders;

        public ResultsListView()
        {
            InitializeComponent();

            _riders = new ObservableCollection<Rider>();

            initializeList();


        }

        IEnumerable<Rider> GetRiders(string searchText = null)
        {
            var riders = new List<Rider>
            {
                new Rider("00001", "Jamie Carson", "Scotland", "imageurl", 22, "male", "2:52.618", "0", 200),
                new Rider("00002", "Stefan Koch", "Germany", "imageurl", 38, "male", "2:54.791", "+2.173", 160),
                new Rider("00003", "Matt Falzon", "Australia", "imageurl", 26, "male", "2:57.281", "+4.663", 140),
                new Rider("00004", "Cam Barter", "Canada", "imageurl", 22, "male", "2:58.111", "+5.493", 125),
                new Rider("00005", "Jack Cropton", "Canada", "imageurl", 18, "male", "2:59.912", "+7.294", 110),
                new Rider("00006", "Ed White", "England", "imageurl", 22, "male", "3:00.249", "+7.631", 95)
            };

            if (String.IsNullOrWhiteSpace(searchText))
                return riders;

            return riders.Where(c => c.name.StartsWith(searchText));
        }

        private void initializeList()
        {
            Rider[] dummyData =
            {
				new Rider("00001", "Jamie Carson", "Scotland", "imageurl", 22, "male", "2:52.618", "0", 200),
				new Rider("00002", "Stefan Koch", "Germany", "imageurl", 38, "male", "2:54.791", "+2.173", 160),
				new Rider("00003", "Matt Falzon", "Australia", "imageurl", 26, "male", "2:57.281", "+4.663", 140),
				new Rider("00004", "Cam Barter", "Canada", "imageurl", 22, "male", "2:58.111", "+5.493", 125),
				new Rider("00005", "Jack Cropton", "Canada", "imageurl", 18, "male", "2:59.912", "+7.294", 110),
				new Rider("00006", "Ed White", "England", "imageurl", 22, "male", "3:00.249", "+7.631", 95)
            };

            for (int i = 0; i < dummyData.Length; i++)
            {
                _riders.Add(dummyData[i]);
            }

            raceList.ItemsSource = _riders;
        }



        async void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            var rider = e.Item as Rider;

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
