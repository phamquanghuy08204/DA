

using System.ComponentModel.DataAnnotations;

namespace BTLONKY5.Models
{
    public class Table
    {
        [Key]
        public int Id { get; set; }
        public bool Status { get; set; }
        public int Capacity { get; set; }
    }
}
