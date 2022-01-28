using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MTK_Delivery.Models
{
    public class Cart
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int id { get; set; }
        [Required]
        public int userId { get; set; }
        [Required]
        public string restaurantId { get; set; }
        [Required]
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public string content { get; set; }
   }
}
