using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MTK_Delivery.Models
{
    public class Food
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        public float Price { get; set; }
        [StringLength(5000)]
        public string Description { get; set; }
        [Required]
        public DateTime CookingTime { get; set; }
        [Required]
        public DateTime DeliveryTime { get; set; }
         [StringLength(50000)]
        public string picture { get; set; }
        [Required]
        [StringLength(50)]
        public string type { get; set; }
         [StringLength(50)]
        public string restaurantId { get; set; }
        [Required]
        [StringLength(50)]
        public string foodId { get; set; }
        public int categoryId { get; set; }
        [ForeignKey("categoryId")]
        public virtual Category Category { get; set; }
    }
}
