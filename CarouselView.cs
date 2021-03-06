﻿﻿using System;
using System.Collections.ObjectModel;
using Spokesman.Model;
using Spokesman.Models;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;

namespace Spokesman
{
    public class CarouselPage : ContentView
    {
        public DotButtonsLayout dotLayout;
        public Xamarin.Forms.CarouselView carousel;
		private HttpClient _client = new HttpClient();
		private ObservableCollection<RootJSON> _riders;
        private const string currentUrl = "https://www.spokesman.online/api/race/current";
        int carouselCount = 0;
        public List<string> title = new List<string>();

        public class Details
        {
            public int position { get; set; }
            public string Header { get; set; }
            public string Content { get; set; }
            public ObservableCollection<Result> obscollection { get; set; }
        }
        public class values
        {
            public string value { get; set; }
        }

        public CarouselPage()
        {
            ObservableCollection<Result> currentRace = new ObservableCollection<Result>();

            //var title = new Label { FontSize = 14 };

			ObservableCollection<Details> collection = new ObservableCollection<Details>{
				new Details{ obscollection = currentRace},
		    };
            getData(currentUrl);

			async void getData(string url)
			{
				var content = await _client.GetStringAsync(url);
				var json = JsonConvert.DeserializeObject<RootJSON>(content);
                ObservableCollection<Result> nextRace = new ObservableCollection<Result>();
				Stage stage = json.stage;
                //Previous previous = json.previous;

                string previousDate = null;
                title.Add(stage.name); 
                if (json.previous != null)
                    previousDate = json.previous.date;
                
				List<Result> results = stage.results;
                /*
				for (int i = 0; i < stage.results.Count; i++)
				{
					System.Diagnostics.Debug.WriteLine(stage.results[i].category.name + " " + stage.results[i].firstName + " " + stage.results[i].lastName);
				}*/


                if (url == "https://www.spokesman.online/api/race/current")
                {
                    for (int i = 0; i < results.Count; i++)
                    {
                        //data.Add(second[i].firstName);
                        //System.Diagnostics.Debug.WriteLine(results[i].firstName);
                        currentRace.Add(results[i]);
                    }
                }
                else
                {
					for (int i = 0; i < results.Count; i++)
					{
						//data.Add(second[i].firstName);
						
						nextRace.Add(results[i]);
					}
                    collection.Add(new Details { obscollection = nextRace, Header = stage.name } );
                }

                System.Diagnostics.Debug.WriteLine(stage.name);

                if(previousDate != null)
                {
                    getData("https://www.spokesman.online/api/race/Phat%20Wednesday/" + previousDate);
                }

			}

            BackgroundColor = Color.FromHex("#FFFFFF");

            StackLayout body = new StackLayout()
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            carousel = new Xamarin.Forms.CarouselView()
            {
                BackgroundColor = Color.Transparent,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };


            DataTemplate template = new DataTemplate(() =>
            {

                var stacksample = new StackLayout()
                {
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    VerticalOptions = LayoutOptions.FillAndExpand,
                    BackgroundColor = Color.Transparent
                };

                Label label = new Label()
                {
                    //only grabs the first title
                   //Text=title[0]
	            };

                ListView lstview = new ListView()
                {
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    VerticalOptions = LayoutOptions.FillAndExpand,
                    SeparatorVisibility = SeparatorVisibility.Default,
                    ItemTemplate = new DataTemplate((typeof(cell))),
                    BackgroundColor = Color.Transparent,
                    RowHeight = 35
                };
                lstview.SetBinding(ListView.ItemsSourceProperty, "obscollection");

                lstview.ItemSelected += (object sender, SelectedItemChangedEventArgs e) =>
                {
                    if (e.SelectedItem == null)
                    {
                        return;
                    }

                    var item = e.SelectedItem as Result;

                    //DisplayAlert("Item Selected", item.firstName, "Ok");
                    detailPage(item);

                    ((ListView)sender).SelectedItem = null;

                };

                stacksample.Children.Add(label);
                stacksample.Children.Add(lstview);

                return stacksample;
            });

            carousel.ItemTemplate = template;

            carousel.PositionSelected += pageChanged;

            carousel.ItemsSource = collection;

            dotLayout = new DotButtonsLayout(collection.Count, Color.FromHex("#311F2D"), 15);

            foreach (DotButton dot in dotLayout.dots)

            dot.Clicked += dotClicked;

            //body.Children.Add(title);

            body.Children.Add(carousel);

            body.Children.Add(dotLayout);

            StackLayout stack = new StackLayout()
            {
                Children = { body },
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Color.White
            };

            Padding = new Thickness(0, Device.OnPlatform(5, 0, 0), 0, 0);

            Content = stack;

        }
        private void pageChanged(object sender, SelectedPositionChangedEventArgs e)
        {
            var position = (int)(e.SelectedPosition);
            for (int i = 0; i < dotLayout.dots.Length; i++)
                if (position == i)
                {
                    dotLayout.dots[i].Opacity = 1;
                }
                else
                {
                    dotLayout.dots[i].Opacity = 0.2;
                }
        }

        private void dotClicked(object sender)
        {
            var button = (DotButton)sender;
            int index = button.index;
            carousel.Position = index;
        }

        private async void detailPage(Result res)
        {
            await Navigation.PushAsync(new RiderDetailPage(res));
        }

        public class DotButtonsLayout : StackLayout
        {
            public DotButton[] dots;
            public DotButtonsLayout(int dotCount, Color dotColor, int dotSize)
            {

                dots = new DotButton[dotCount];

                Orientation = StackOrientation.Horizontal;
                VerticalOptions = LayoutOptions.Center;
                HorizontalOptions = LayoutOptions.Center;
                Spacing = 20;

                for (int i = 0; i < dotCount; i++)
                {
                    dots[i] = new DotButton
                    {
                        HeightRequest = dotSize,
                        WidthRequest = dotSize,
                        BackgroundColor = dotColor,
                        Opacity = 0.2
                    };
                    dots[i].index = i;
                    dots[i].layout = this;
                    Children.Add(dots[i]);
                }
                dots[0].Opacity = 1;
            }
        }


        public class DotButton : BoxView
        {
            public int index;
            public DotButtonsLayout layout;
            public event ClickHandler Clicked;
            public delegate void ClickHandler(DotButton sender);
            public DotButton()
            {
                var clickCheck = new TapGestureRecognizer()
                {
                    Command = new Command(() =>
                        {
                            if (Clicked != null)
                            {
                                Clicked(this);
                            }
                        })
                };
                GestureRecognizers.Add(clickCheck);
            }
        }

        public class cell : ViewCell
        {
            public cell()
            {
                /*
                Image flag = new Image()
                {
                    HorizontalOptions = LayoutOptions.Start,
                    VerticalOptions = LayoutOptions.Center
                };
                flag.SetBinding(Image.SourceProperty, "countryImg");
                */
                Label firstNameLabel = new Label()
                {
                    HorizontalOptions = LayoutOptions.Start,
                    VerticalOptions = LayoutOptions.Center,
                    TextColor = Color.Black,
                    FontSize = 14
                };
                firstNameLabel.SetBinding(Label.TextProperty, "firstName");

				Label lastNameLabel = new Label()
				{
					HorizontalOptions = LayoutOptions.Start,
					VerticalOptions = LayoutOptions.Center,
					TextColor = Color.Black,
					FontSize = 14
				};

				lastNameLabel.SetBinding(Label.TextProperty, "lastName");

                Label timeLabel = new Label()
                {
                    HorizontalOptions = LayoutOptions.Start,
                    VerticalOptions = LayoutOptions.Center,
                    TextColor = Color.Black,
                    FontSize = 12
                };
                timeLabel.SetBinding(Label.TextProperty, "time");

                Label gapLabel = new Label()
                {
                    HorizontalOptions = LayoutOptions.Start,
                    VerticalOptions = LayoutOptions.Center,
                    TextColor = Color.Black,
                    FontSize = 12
                };
                gapLabel.SetBinding(Label.TextProperty, "points");


                StackLayout stack = new StackLayout()
                {
                    Children = { firstNameLabel, lastNameLabel, timeLabel, gapLabel },
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    VerticalOptions = LayoutOptions.FillAndExpand,
                    Orientation = StackOrientation.Horizontal
                };

                Grid grid = new Grid()
                {
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    VerticalOptions = LayoutOptions.FillAndExpand,
                };

                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.30, GridUnitType.Star) });
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.30, GridUnitType.Star) });
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.2, GridUnitType.Star) });
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.2, GridUnitType.Star) });

                grid.Children.Add(firstNameLabel, 0, 0);
                grid.Children.Add(lastNameLabel, 1, 0);
                grid.Children.Add(timeLabel, 2, 0);
                grid.Children.Add(gapLabel, 3, 0);

                View = grid;

            }

        }

    }

}