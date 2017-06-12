using System;
using System.Collections.ObjectModel;
using Spokesman.Model;
using Xamarin.Forms;
using System.Collections.Generic;

namespace Spokesman
{
	public class CarouselPage : ContentView
	{
		public DotButtonsLayout dotLayout;
		public Xamarin.Forms.CarouselView carousel;

		public class Details
		{
			public int position { get; set; }
			public string Header { get; set; }
			public string Content { get; set; }
			public ObservableCollection<Rider> obscollection { get; set; }
		}
		public class values
		{
			public string value { get; set; }
		}
		public CarouselPage()
		{
			ObservableCollection<Rider> first = new ObservableCollection<Rider>
			{
				new Rider("00001", "Jamie Carson", "Scotland", "imageurl", 22, "male", "2:52.618", "0", 200),
				new Rider("00002", "Stefan Koch", "Germany", "imageurl", 38, "male", "2:54.791", "+2.173", 160),
				new Rider("00003", "Matt Falzon", "Australia", "imageurl", 26, "male", "2:57.281", "+4.663", 140),
				new Rider("00004", "Cam Barter", "Canada", "imageurl", 22, "male", "2:58.111", "+5.493", 125),
				new Rider("00005", "Jack Cropton", "Canada", "imageurl", 18, "male", "2:59.912", "+7.294", 110),
				new Rider("00006", "Ed White", "England", "imageurl", 22, "male", "3:00.249", "+7.631", 95)
		};

			ObservableCollection<Rider> second = new ObservableCollection<Rider>
			{
				new Rider("00001", "Jamie Carson2", "Scotland", "imageurl", 22, "male", "2:52.618", "0", 200),
				new Rider("00002", "Stefan Koch2", "Germany", "imageurl", 38, "male", "2:54.791", "+2.173", 160),
				new Rider("00003", "Matt Falzon2", "Australia", "imageurl", 26, "male", "2:57.281", "+4.663", 140),
				new Rider("00004", "Cam Barter2", "Canada", "imageurl", 22, "male", "2:58.111", "+5.493", 125),
				new Rider("00005", "Jack Cropton2", "Canada", "imageurl", 18, "male", "2:59.912", "+7.294", 110),
				new Rider("00006", "Ed White2", "England", "imageurl", 22, "male", "3:00.249", "+7.631", 95)
		};

			ObservableCollection<Rider> third = new ObservableCollection<Rider>
			{
				new Rider("00001", "Jamie Carson3", "Scotland", "imageurl", 22, "male", "2:52.618", "0", 200),
				new Rider("00002", "Stefan Koch3", "Germany", "imageurl", 38, "male", "2:54.791", "+2.173", 160),
				new Rider("00003", "Matt Falzon3", "Australia", "imageurl", 26, "male", "2:57.281", "+4.663", 140),
				new Rider("00004", "Cam Barter3", "Canada", "imageurl", 22, "male", "2:58.111", "+5.493", 125),
				new Rider("00005", "Jack Cropton3", "Canada", "imageurl", 18, "male", "2:59.912", "+7.294", 110),
				new Rider("00006", "Ed White3", "England", "imageurl", 22, "male", "3:00.249", "+7.631", 95)
		};

			ObservableCollection<Details> collection = new ObservableCollection<Details>{
				new Details{ obscollection = first, Header="first", Content="Lorem ipsum dolor sit amet, conselectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore." },
				new Details{obscollection = second, Header="second", Content="Eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad mimim veni." },
				new Details{obscollection = third, Header="third", Content="Ut anim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat."},
		};

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

				ListView lstview = new ListView()
				{
					HorizontalOptions = LayoutOptions.FillAndExpand,
					VerticalOptions = LayoutOptions.FillAndExpand,
					SeparatorVisibility = SeparatorVisibility.Default,
					ItemTemplate = new DataTemplate((typeof(cell))),
					BackgroundColor = Color.Transparent,
                    RowHeight=35
				};
				lstview.SetBinding(ListView.ItemsSourceProperty, "obscollection");

				lstview.ItemSelected += (object sender, SelectedItemChangedEventArgs e) =>
				{
					if (e.SelectedItem == null)
					{
						return;
					}

					var item = e.SelectedItem as Rider;

					//DisplayAlert("Item Selected", item.name, "Ok");

					((ListView)sender).SelectedItem = null;

				};


				stacksample.Children.Add(lstview);

				return stacksample;
			});

			carousel.ItemTemplate = template;

			carousel.PositionSelected += pageChanged;

			carousel.ItemsSource = collection;

			dotLayout = new DotButtonsLayout(collection.Count, Color.FromHex("#311F2D") , 15);


            foreach (DotButton dot in dotLayout.dots)

				dot.Clicked += dotClicked;

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
            Image flag = new Image()
			{
				HorizontalOptions = LayoutOptions.Start,
				VerticalOptions = LayoutOptions.Center
            };
            flag.SetBinding(Image.SourceProperty, "countryImg");

            Label nameLabel = new Label()
            {
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Center,
                TextColor = Color.Black,
                FontSize = 14
			};
			nameLabel.SetBinding(Label.TextProperty, "name");

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
			gapLabel.SetBinding(Label.TextProperty, "gap");


			StackLayout stack = new StackLayout()
			{
				Children = { flag, nameLabel, timeLabel, gapLabel },
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,
                Orientation = StackOrientation.Horizontal
			};

            Grid grid = new Grid()
            {
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand,
            };

            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.15, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.45, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.2, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(0.2, GridUnitType.Star) });

            grid.Children.Add(flag, 0, 0);
            grid.Children.Add(nameLabel, 1, 0);
            grid.Children.Add(timeLabel, 2, 0);
            grid.Children.Add(gapLabel, 3, 0);

			View = grid;

		}

	}

}

