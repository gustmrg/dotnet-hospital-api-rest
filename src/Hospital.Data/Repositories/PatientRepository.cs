using Hospital.Business.Interfaces;
using Hospital.Business.Models;
using Hospital.Data.Context;

namespace Hospital.Data.Repositories;

public class PatientRepository : Repository<Patient>
{
    public PatientRepository(HospitalContext context) : base(context)
    {
    }
}