using System;
using System.Collections.Generic;
using Spokesman.Model;
using Xamarin.Forms;

namespace Spokesman
{
    public partial class RiderDetailPage : ContentPage
    {
        public RiderDetailPage(Rider rider)
        {
            InitializeComponent();

			Label label = new Label()
			{
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center,
				Text = rider.name
			};

            Content = label;

        }
    }
}
