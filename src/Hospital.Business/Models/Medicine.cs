namespace Hospital.Business.Models;

public class Medicine : Entity
{
    public string Name { get; set; }
    public string Company { get; set; }
    
    public ICollection<Prescription> Prescriptions { get; set; }
    public List<MedicinePrescription> MedicinePrescriptions { get; set; }
}