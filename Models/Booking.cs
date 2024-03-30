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
        [ForeignKey("Acount")]
        public int IDAcount { get; set; }
        [ForeignKey("Food")]
        public int IDFood { get; set; }
    }
}
