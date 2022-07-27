using System.ComponentModel.DataAnnotations;

namespace Hospital.API.DTO;

public class MedicineDTO
{
    [Key]
    public Guid Id { get; set; }
    
    [Required]
    [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
    public string Name { get; set; }
    
    [Required]
    [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
    public string Company { get; set; }
}