using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MTK_Delivery.Models
{
    public class Message
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int id { get; set; }
        [Required]
        [StringLength(50)]
        public string sessionId { get; set; }
        [Required]
        [StringLength(5000)]
        public string msgcontent { get; set; }
         [Required]
        public DateTime date { get; set; }
        [Required]
        [StringLength(500)]
        public string userId { get; set; }
        [Required]
        [StringLength(500)]
        public string driverId { get; set; }
    }
}
