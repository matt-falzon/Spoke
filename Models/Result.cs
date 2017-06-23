using System;
namespace Spokesman.Models
{
	public class Result
	{
		public Category category { get; set; }
		public int uid { get; set; }
		public int bibNumber { get; set; }
		public string firstName { get; set; }
		public string lastName { get; set; }
		public string gender { get; set; }
		public double time { get; set; }
		public int points { get; set; }

        public Result(Category c, int uid, int bib, string first, string last, string gender, double time, int points)
        {
            category = c;
            this.uid = uid;
            bibNumber = bib;
            firstName = first;
            lastName = last;
            this.gender = gender;
            this.time = time;
            this.points = points;
        }

        public Result() { }
    }
}
