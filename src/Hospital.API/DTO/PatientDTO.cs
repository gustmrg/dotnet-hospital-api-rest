using System.ComponentModel.DataAnnotations;

namespace Hospital.API.DTO;

public class PatientDTO
{
    [Key]
    public Guid Id { get; set; }
    
    [Required]
    [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
    public string Name { get; set; }
    
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public int Age { get; set; }
    
    [Required]
    [StringLength(40, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 1)]
    public string Gender { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public DateTime DateBirth { get; set; }
}