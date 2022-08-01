namespace Hospital.Business.Models;

public class MedicinePrescription
{
    public Guid MedicineId { get; set; }
    public Medicine Medicine { get; set; }
    public Guid PrescriptionId { get; set; }
    public Prescription Prescription { get; set; }
}