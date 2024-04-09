using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTLONKY5.Models
{
	public class Food
	{
		[Key]
		public int ID { get; set; }
		public string NameFood { get; set; }
		[ForeignKey("Category")]
		public int IDCategory { get; set;}
		public Category Category { get; set; }
		public string ImgFood { get; set; }
		public string Description { get; set; }
		public double PriceFood { get; set; }

	}
}
