using System;
namespace Spokesman.Models
{
    public class RootJSON
	{
		public Stage stage { get; set; }
		public Previous previous { get; set; }
		public int id { get; set; }
		public string name { get; set; }
		public string date { get; set; }
		public string series { get; set; }
		public int seriesId { get; set; }
		public string location { get; set; }
	}
}
