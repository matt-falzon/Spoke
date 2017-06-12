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
        public string countryImg { get { return "flag/" + country; }}
        public int number { get; set; }
        public string time { get; set; }
        public string gap { get; set; }
        public int points { get; set; }

        public Rider(string ID, string name, string country, string imageUrl, int age, string sex, string time, string gap, int points)
        {
            this.ID = ID;
            this.name = name;
            this.country = country;
            this.imageUrl = imageUrl;
            this.age = age;
            this.sex = sex;
            this.time = time;
            this.gap = gap;
            this.points = points; 
        }
    }
}
