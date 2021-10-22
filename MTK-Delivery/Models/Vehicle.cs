using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MTK_Delivery.Models
{
    public class Vehicle
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int id { get; set; }
        [Required]
        [StringLength(50)]
        public string Plate { get; set; }
         [StringLength(50)]
        public string Type { get; set; }
        [StringLength(50)]
        public string Model { get; set; }
        [Required]
        public int MotorNumber { get; set; }

    }
}
