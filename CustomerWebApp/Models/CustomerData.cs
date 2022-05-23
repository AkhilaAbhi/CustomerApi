using System.ComponentModel.DataAnnotations;

namespace CustomerWebApp.Models
{
    public class CustomerData
    {
        public int CustomerId { get; set; }
        [Required]
        public string CustomerName { get; set; }
        public string Address { get; set; }
        [Required]
        [StringLength(10)]
        [DataType(DataType.PhoneNumber)]
        public string ContactNumber { get; set; }

        [Required]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }
    }
}
