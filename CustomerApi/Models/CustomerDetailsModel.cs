using System.ComponentModel.DataAnnotations;

namespace CustomerApi.Models
{
    public class CustomerDetailsModel
    {
        [Key]
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }   
        public string Email { get; set; }
    }
}
