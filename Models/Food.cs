using System.ComponentModel.DataAnnotations;

namespace BTLONKY5.Models
{
	public class Food
	{
		[Key]
		public int ID { get; set; }
		public string NameFood { get; set; }
		public int IDCategory { get; set;}
		public string ImgFood { get; set; }
		public string Description { get; set; }
		public float PriceFood { get; set; }

	}
}
