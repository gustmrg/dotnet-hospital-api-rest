using System.ComponentModel.DataAnnotations;

namespace Hospital.API.DTO;

public class PrescriptionDTO
{
    [Key]
    public Guid Id { get; set; }
    
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public DateTime DatePrescription { get; set; }
    
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public Guid PatientId { get; set; }

    public PatientDTO Patient { get; set; }
    
    public List<MedicineDTO> Medicines { get; set; }
}