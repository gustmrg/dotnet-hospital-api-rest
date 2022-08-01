using AutoMapper;
using Hospital.API.DTO;
using Hospital.Business.Models;
using Hospital.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PrescriptionsController : ControllerBase
{
    private readonly PrescriptionRepository _prescriptionRepository;
    private readonly IMapper _mapper;

    public PrescriptionsController(PrescriptionRepository prescriptionRepository, IMapper mapper)
    {
        _prescriptionRepository = prescriptionRepository;
        _mapper = mapper;
    }

    // Apenas para testes
    [HttpGet]
    public async Task<ActionResult<List<PrescriptionDTO>>> GetAll()
    {
        var prescriptions = _mapper.Map<List<PrescriptionDTO>>(await _prescriptionRepository.GetAll());
        return Ok(prescriptions);
    }

    [HttpPost]
    public async Task<ActionResult<PrescriptionDTO>> Add(PrescriptionDTO prescriptionDto)
    {
        if (!ModelState.IsValid) return BadRequest();

        var prescription = _mapper.Map<Prescription>(prescriptionDto);
        await _prescriptionRepository.Add(prescription);
        return Ok(prescriptionDto);
    }
}