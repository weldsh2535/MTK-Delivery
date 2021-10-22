using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MTK_Delivery.Models
{
    public class FoodContent
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int id { get; set; }
        [Required]
        [StringLength(50)]
        public string ContentName { get; set; }
         [StringLength(500)]
        public string ContentDescription { get; set; }
        [Required]
        [StringLength(50)]
        public int qty { get; set; }
        public int foodId { get; set; }
       [ForeignKey("foodId")]
       public virtual Food Food { get; set; }
    }
}
