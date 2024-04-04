using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTLONKY5.Models
{
    public class BookingFood
    {
		[Key]
        public int ID { get; set; }
		[ForeignKey("Booking")]
		public int IDBooking { get; set; }
		[ForeignKey("Food")]
		public int IDFood { get; set; }
		public int Count { get; set; }
	}
}
