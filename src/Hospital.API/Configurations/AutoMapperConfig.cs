using AutoMapper;
using Hospital.API.DTO;
using Hospital.Business.Models;

namespace Hospital.API.Configurations;

public class AutoMapperConfig : Profile
{
    public AutoMapperConfig()
    {
        CreateMap<Patient, PatientDTO>().ReverseMap();
        CreateMap<Medicine, MedicineDTO>().ReverseMap();
        CreateMap<Prescription, PrescriptionDTO>().ReverseMap();
    }
}