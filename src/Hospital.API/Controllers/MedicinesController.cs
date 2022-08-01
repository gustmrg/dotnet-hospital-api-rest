using AutoMapper;
using Hospital.API.DTO;
using Hospital.Business.Models;
using Hospital.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MedicinesController : ControllerBase
{
    private readonly MedicineRepository _medicineRepository;
    private readonly IMapper _mapper;

    public MedicinesController(MedicineRepository medicineRepository, IMapper mapper)
    {
        _medicineRepository = medicineRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Obter todos os remédios cadastrados.
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<MedicineDTO>>> GetAll()
    {
        var medicines = _mapper.Map<IEnumerable<MedicineDTO>>(await _medicineRepository.GetAll());
        return Ok(medicines);
    }
    
    /// <summary>
    /// Obter o remédio cadastrado pelo seu id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<MedicineDTO>> GetById(Guid id)
    {
        var medicine = _mapper.Map<MedicineDTO>(await _medicineRepository.GetById(id));

        if (medicine == null) return BadRequest();

        return Ok(medicine);
    }

    /// <summary>
    /// Cadastra um novo remédio.
    /// </summary>
    /// <param name="medicineDto"></param>
    /// <returns></returns>
    [HttpPost]
    public async Task<ActionResult<MedicineDTO>> Add(MedicineDTO medicineDto)
    {
        if (!ModelState.IsValid) return BadRequest();

        var medicine = _mapper.Map<Medicine>(medicineDto);
        await _medicineRepository.Add(medicine);
        return Ok(medicineDto);
    }
    
    // Update
    
    // Remove

}