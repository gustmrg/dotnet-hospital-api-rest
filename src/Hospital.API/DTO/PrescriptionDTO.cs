using System.ComponentModel.DataAnnotations;

namespace Hospital.API.DTO;

public class PrescriptionDTO
{
    [Key]
    public Guid Id { get; set; }
    
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public DateTime DatePrescription { get; set; }

    public ICollection<MedicineDTO> Medicines { get; set; }
}