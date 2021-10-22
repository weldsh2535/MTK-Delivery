using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MTK_Delivery.Models
{
    public class Restaurant
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int id { get; set; }
         [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        public string Type { get; set; }
        [Required]
        public DateTime StartWorkingHour { get; set; }
        [Required]
        public DateTime EndWorkingHour { get; set; }
        public int AreaSpace { get; set; }
        [Required]
        [StringLength(50)]
        public string PhoneNumber { get; set; }
        [Required]
        [StringLength(50)]
        public string GM { get; set; }
        [Required]
        [StringLength(50)]
        public string ContactPerson { get; set; }
         [Required]
        [StringLength(50)]
        public string Email { get; set; }
        [Required]
        [StringLength(500000000)]
        public string Photo { get; set; }
        [Required]
        [StringLength(50)]
        public string status { get; set; }
         [Required]
        [StringLength(50)]
        public string ResId { get; set; }
        [Required]
        public int accountId { get; set; }
        internal string _categoryId { get; set; }
        [NotMapped]
        public string[] CategoryId
        {
            get { return _categoryId == null ? null : JsonConvert.DeserializeObject<string[]>(_categoryId); }
            set { _categoryId = JsonConvert.SerializeObject(value); }
        }
        internal string _location { get; set; }
        [NotMapped]
        public Location location
        {
            get { return _location == null ? null : JsonConvert.DeserializeObject<Location>(_location); }
            set { _location = JsonConvert.SerializeObject(value); }
        }
    }
  

}
