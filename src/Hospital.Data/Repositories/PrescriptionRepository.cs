using Hospital.Business.Models;
using Hospital.Data.Context;

namespace Hospital.Data.Repositories;

public class PrescriptionRepository : Repository<Prescription>
{
    public PrescriptionRepository(HospitalContext context) : base(context)
    {
    }
}