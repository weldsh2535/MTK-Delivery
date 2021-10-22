using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MTK_Delivery.Models
{
    public class OrderDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int id { get; set; }
        [Required]
        public int Qty { get; set; }
        [Required]
        public float Price { get; set; }
        public int foodId { get; set; }
        public int orderId { get; set; }
        [ForeignKey("foodId")]
        public virtual Food Food { get; set; }
        [ForeignKey("orderId")]
        public virtual Order Order { get; set; }
    }
}
