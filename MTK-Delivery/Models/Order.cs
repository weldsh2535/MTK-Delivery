using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MTK_Delivery.Models
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int id { get; set; }
        [Required]
        [StringLength(50)]
        public string RestaurantId { get; set; }
        [Required]
        public DateTime DateTime { get; set; }
        [Required]
        public string Customer { get; set; }
        [Required]
        public int Total { get; set; }
        [Required]
        [StringLength(50)]
        public string Driver { get; set; }
        [Required]
        [StringLength(50)]
        public string Vehicle { get; set; }
        [Required]
        [StringLength(50)]
        public string orderLocation { get; set; }
        [Required]
        [StringLength(50)]
        public string customerStatus { get; set; }
        internal string _location { get; set; }
        [NotMapped]
        public Location location
        {
            get { return _location == null ? null : JsonConvert.DeserializeObject<Location>(_location); }
            set { _location = JsonConvert.SerializeObject(value); }
        }
        public List<Status> statuses { get; set; }
        public List<RestaurantStatus> restaurantStatuses { get; set; }
        public List<OrderStatus> orderStatuses { get; set; }
    }
     
}
