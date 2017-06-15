﻿using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Spokesman
{
    public partial class RaceSeriesMenuPage : ContentPage
    {
        public RaceSeriesMenuPage()
        {
            InitializeComponent();

			var tapGestureRecognizer = new TapGestureRecognizer();
			tapGestureRecognizer.Tapped += (s, e) =>
			{
                navigate();
			};
			btnClose.GestureRecognizers.Add(tapGestureRecognizer);

			async void navigate()
			{
				await Navigation.PopModalAsync();
			}

			listView.ItemsSource = new List<string>
			{
				"Phat Wednesday 2017",
				"Toonie 2017",
				"Phat Wednesday 2016"
			};
        }
    }
}
