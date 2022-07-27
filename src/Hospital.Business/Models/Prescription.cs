namespace Hospital.Business.Models;

public class Prescription : Entity
{
    public DateTime DatePrescription { get; set; }
    public Guid PatientId { get; set; }

    public Patient Patient { get; set; }
    public List<Medicine> Medicines { get; set; }
}