using System;
using Xamarin.Forms;
namespace Spokesman.Model
{
    public class Rider
    {
        public string ID { get; set; }
        public string name { get; set; }
        public string country { get; set; }
        public string imageUrl { get; set; }
        public int age { get; set; }
        public string sex { get; set; }
        public ImageSource imgSrc { get; set; }

        public Rider(string ID, string name, string country, string imageUrl, int age, string sex)
        {
            this.ID = ID;
            this.name = name;
            this.country = country;
            this.imageUrl = imageUrl;
            this.age = age;
            this.sex = sex;
            //imgSrc = GetImageUriSource(country, 60);
        }

        public ImageSource GetImageUriSource(string strUrl, double cacheDurationMinutes)
		{
			if (string.IsNullOrEmpty(strUrl))
				return null;

			// escape the url
			strUrl = Uri.EscapeUriString(strUrl);


			if (!Uri.IsWellFormedUriString(strUrl, UriKind.RelativeOrAbsolute))
				return null;

			Uri imgUri = new Uri(strUrl);

			return new UriImageSource()
			{
				CachingEnabled = true,
				Uri = imgUri,
				CacheValidity = TimeSpan.FromMinutes(cacheDurationMinutes)
			};
		}
    }
}
