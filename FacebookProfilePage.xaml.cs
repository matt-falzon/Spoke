using System;
using System.Collections.Generic;
using FacebookLogin.Models;
using FacebookLogin.ViewModels;

using Xamarin.Forms;

namespace Spokesman
{
    public partial class FacebookProfilePage : ContentPage
    {
        public readonly string ClientId = "261774467623853";
        private FacebookProfile _fbProfile;
        private readonly string _fbToken;
        WebView webView;
        public FacebookProfilePage()
        {
			InitializeComponent();
            /*
            var appData = Application.Current as App;

            if (appData.xaProfile.Id != "" && appData.Token != "")
            {
                _fbProfile = appData.Profile;
                _fbToken = appData.Token;
                var vm = BindingContext as FacebookViewModel;
                getCurrentProfile(vm);
            }
            else
            {*/
				var apiRequest =
				"https://www.facebook.com/dialog/oauth?client_id="
				+ ClientId
				+ "&display=popup&response_type=token&redirect_uri=http://www.facebook.com/connect/login_success.html";

				webView = new WebView
				{
					Source = apiRequest,
					HeightRequest = 1
				};

				webView.Navigated += WebViewOnNavigated;

				Content = webView;
            //}

            //Login();

		}

		private async void WebViewOnNavigated(object sender, WebNavigatedEventArgs e)
		{

			var accessToken = ExtractAccessTokenFromUrl(e.Url);

			if (accessToken != "")
			{
				var vm = BindingContext as FacebookViewModel;
                webView.IsVisible = false;
                setActivityIndicatorView();
				await vm.SetFacebookUserProfileAsync(accessToken);

				//Content = MainStackLayout;
                await Navigation.PushModalAsync(new MainPage());
			}
		}

        private async void getCurrentProfile(FacebookViewModel profile)
        {
            await profile.SetFacebookUserProfileAsync(_fbToken);

            Content = MainStackLayout;
        }

		private string ExtractAccessTokenFromUrl(string url)
		{
			if (url.Contains("access_token") && url.Contains("&expires_in="))
			{
				var at = url.Replace("https://www.facebook.com/connect/login_success.html#access_token=", "");

				var accessToken = at.Remove(at.IndexOf("&expires_in="));

                var appData = Application.Current as App;
                appData.Token = accessToken;

				return accessToken;
			}

			return string.Empty;
		}

        async void Handle_Clicked(object sender, System.EventArgs e)
        {
            var appData = Application.Current as App;
            _fbProfile = appData.Profile;

            await Navigation.PushModalAsync(new MainPage());
        }

        async void Login()
        {
			var appData = Application.Current as App;
			_fbProfile = appData.Profile;

			await Navigation.PushModalAsync(new MainPage());
        }

        void setActivityIndicatorView()
        {
            var indicator = new ActivityIndicator
            {
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
            };

            Content = new StackLayout
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Children = 
                {
                    indicator
                }
            };
        }
    }
}