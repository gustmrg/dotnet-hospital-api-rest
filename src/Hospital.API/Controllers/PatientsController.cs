using AutoMapper;
using Hospital.API.DTO;
using Hospital.Business.Models;
using Hospital.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PatientsController : ControllerBase
{
    private readonly PatientRepository _patientRepository;
    private readonly IMapper _mapper;

    public PatientsController(PatientRepository patientRepository, IMapper mapper)
    {
        _patientRepository = patientRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Obter todos os pacientes cadastrados.
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<PatientDTO>>> GetAll()
    {
        var patients = _mapper.Map<IEnumerable<PatientDTO>>(await _patientRepository.GetAll());
        return Ok(patients);
    }
    
    /// <summary>
    /// Obter o paciente cadastrado pelo seu id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<PatientDTO>> GetById(Guid id)
    {
        var patient = _mapper.Map<PatientDTO>(await _patientRepository.GetById(id));

        if (patient == null) return NotFound();
        
        return Ok(patient);
    }
    
    /// <summary>
    /// Cadastra um novo paciente.
    /// </summary>
    /// <param name="patientDto"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult<PatientDTO>> Add(PatientDTO patientDto)
    {
        if (!ModelState.IsValid) return BadRequest();

        var patient = _mapper.Map<Patient>(patientDto);
        await _patientRepository.Add(patient);
        return Ok(patient);
    }
    
}