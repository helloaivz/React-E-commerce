using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ReactEcommerceApp.Server.Models
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string? orderNo { get; set; }
        [ForeignKey("Products")]
        public int productId { get; set; }
        public int qty { get; set; }
    }
}