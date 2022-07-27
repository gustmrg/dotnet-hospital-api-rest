namespace Hospital.Business.Models;

public class Patient : Entity
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Gender { get; set; }
    // public string Address { get; set; }
    public string Phone { get; set; }
    public DateTime DateBirth { get; set; }
    public ICollection<Prescription> Prescriptions { get; set; }
}