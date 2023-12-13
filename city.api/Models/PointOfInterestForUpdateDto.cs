using System.ComponentModel.DataAnnotations;

namespace city.api.Models
{
    public class PointOfInterestForUpdateDto
    {
        [Required(ErrorMessage = "Enter Name !!!")]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(200)]
        public string? Description { get; set; }
    }
}
