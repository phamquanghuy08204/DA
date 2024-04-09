using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTLONKY5.Models
{
    public class Booking
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("Table")]
        public int IDTable { get; set; }
        [ForeignKey("Account")]
        public int IDAccount { get; set; }
        public string NameBooking { get; set; }
        public int sdtBooking { get; set; }
        public DateTime Date { get; set; }

        public DateTime Checkin { get; set; }

        public DateTime Checkout { get; set; }
        
        public int IDFood { get; set; }
    }
}
