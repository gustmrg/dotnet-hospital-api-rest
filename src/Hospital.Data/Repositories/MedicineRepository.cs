using Hospital.Business.Models;
using Hospital.Data.Context;

namespace Hospital.Data.Repositories;

public class MedicineRepository : Repository<Medicine>
{
    public MedicineRepository(HospitalContext context) : base(context)
    {
        
    }
}