using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTLONKY5.Models
{
    public class BillInfo
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("Bill")]
        public int IDBill { get; set; }
        [ForeignKey("Food")]
        public int IDFood { get; set; }
        public float Amount { get; set; }
    }
}
