using FacebookLogin.Models;
using Xamarin.Forms;

namespace Spokesman
{
    public partial class App : Application
    {
        private const string ProfileKey = "Profile";
        private const string TokenKey = "Token";

        public App()
        {
            InitializeComponent();

            MainPage = new LoginPage();
            //MainPage = new HomePage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        public FacebookProfile Profile
		{
			get
			{
				if (Properties.ContainsKey(ProfileKey))
					return (FacebookLogin.Models.FacebookProfile)Properties[ProfileKey];

				return null;
			}
			set
			{
				Properties[ProfileKey] = value;
			}
		}

		public string Token
		{
			get
			{
				if (Properties.ContainsKey(TokenKey))
					return Properties[TokenKey].ToString();

				return "";
			}
			set
			{
				Properties[TokenKey] = value;
			}
		}
    }
}
