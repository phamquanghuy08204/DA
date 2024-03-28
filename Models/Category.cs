using System.ComponentModel.DataAnnotations;

namespace BTLONKY5.Models
{
	public class Category
	{
		[Key]

		public int ID { get; set; }

		[Display(Name = "Tên loại thức ăn")]
		public string NameCategory { get; set; }
	}
}
