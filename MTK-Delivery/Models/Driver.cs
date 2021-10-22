using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MTK_Delivery.Models
{
    public class Driver
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int id { get; set; }
        [Required]
        [StringLength(50)]
        public string fullName { get; set; }
        [Required]
        [StringLength(50)]
        public string address { get; set; }
        [Required]
        public int phoneNumber { get; set; }
        [Required]
        [StringLength(50000)]
        public string photo { get; set; }
        public string initialLocationofDay { get; set; }
        public int vehicleId { get; set; }
        [ForeignKey("vehicleId")]
        public virtual Vehicle Vehicle { get; set; }
    }
}
