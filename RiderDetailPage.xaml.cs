using System;
using System.Collections.Generic;
using Spokesman.Model;
using Spokesman.Models;
using Xamarin.Forms;

namespace Spokesman
{
    public partial class RiderDetailPage : ContentPage
    {
        public RiderDetailPage(Result res)
        {
            InitializeComponent();

			Label label = new Label()
			{
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.Center,
				Text = res.firstName
			};

            Content = label;

        }
    }
}
