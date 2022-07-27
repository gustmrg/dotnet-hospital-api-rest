using Hospital.Data.Context;
using Hospital.Data.Repositories;

namespace Hospital.API.Configurations;

public static class DependencyInjectionConfig
{
    public static IServiceCollection ResolveDependencies(this IServiceCollection services)
    {
        services.AddScoped<HospitalContext>();
        services.AddScoped<PatientRepository>();
        services.AddScoped<MedicineRepository>();
        services.AddScoped<PrescriptionRepository>();
        
        return services;
    }
}