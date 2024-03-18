using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ReactEcommerceApp.Server.Models
{
    public class Cart
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)] 
        public string? transactionid { get; set; }
        [ForeignKey("Products")] 
        public int productId { get; set; }
        public int qty { get; set; }
        public virtual Product? Product { get; set; }
    }
}