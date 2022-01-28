using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MTK_Delivery.Models
{
    public class Cart_Item
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int id { get; set; }
        [Required]
        public int cartId { get; set; }
        [Required]
        public int foodId { get; set; }
        [Required]
        public int price { get; set; }
        public int quantity { get; set; }
        public int discount { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public string content { get; set; }
    }
}
