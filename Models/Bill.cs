using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTLONKY5.Models
{
    public class Bill
    {
        [Key]
        public int ID { get; set; }
            
        public DateTime DateCheckin { get; set; }

        public DateTime DateCheckout { get; set; }
        [ForeignKey("Booking")]
        public string IDBooking { get; set; }

        public string TotalAmount { get; set; }
        [ForeignKey("Account")]
        public string IDAccount { get; set; }

    }
}
