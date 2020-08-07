using System.ComponentModel.DataAnnotations;

namespace netCoreRestApiEf.Dtos
{

    public class SmartphoneCreateDto
    {       
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