using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MTK_Delivery.Models
{
    public class Account
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int id { get; set; }
        [Required]
        [StringLength(50)]
        public string email { get; set; }
        [Required]
        [StringLength(50)]
        public string phonenumber { get; set; }
        [Required]
        [StringLength(50)]
        public string password { get; set; }
        [Required]
        [StringLength(50)]
        public string FullName { get; set; }
        [Required]
        [StringLength(50)]
        public string active { get; set; }
        [Required]
        [StringLength(50)]
        public string type { get; set; }
        internal string _LocationId { get; set; }
        [NotMapped]
        public Location LocationId
        {
            get { return _LocationId == null ? null : JsonConvert.DeserializeObject<Location>(_LocationId); }
            set { _LocationId = JsonConvert.SerializeObject(value); }
        }
    }
  
    

}
