using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace netCoreRestApiEf.Model{

    public class Smartphone{

        [Key]
        public int id { get; set; }
        [Required]
        [MaxLength(50)]
        public string manufacturer { get; set; }
        [Required]
        [MaxLength(50)]
        public string color { get; set; } 
        [Required]
        public double price { get; set; }

    }

}