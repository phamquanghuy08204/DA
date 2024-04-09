using System.ComponentModel.DataAnnotations;

namespace BTLONKY5.Models
{
    public class Account
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "Bạn phải nhập vào User Name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Bạn phải nhập vào Password")]
        public string PassWord { get; set; }

        public int Role { get; set; }

       // public string Img { get; set; }
    }
}
