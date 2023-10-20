using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Customer.api.Models
{
    [Table("customer",Schema = "dbo")]
    public class CustomerModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("customer_id")]
        public int CustomerId { get; set; }

        [Column("customer_name")]
        public string CustomerName  { get; set; }

        [Column("mobile_no")]
        public string MobileNo { get; set; }
        [Column("email")]
        public string Email { get; set; }
    }
}
