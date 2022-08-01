namespace Hospital.Business.Models;

public class Prescription : Entity
{
    public DateTime DatePrescription { get; set; }
    
    public ICollection<Medicine> Medicines { get; set; }
    public List<MedicinePrescription> MedicinePrescriptions { get; set; }
}