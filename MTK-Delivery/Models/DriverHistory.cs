using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MTK_Delivery.Models
{
    public class DriverHistory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int id { get; set; }
        [Required]
        [StringLength(50)]
        public string location { get; set; }
         [Required]
        [StringLength(50)]
        public string type { get; set; }
        [StringLength(50)]
        public DateTime timestamp { get; set; }
        public int dervirId { get; set; }
        [ForeignKey("dervirId")]
        public virtual Driver Driver { get; set; }
    }
}
