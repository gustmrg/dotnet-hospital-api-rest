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

    [HttpGet]
    public async Task<ActionResult<IEnumerable<MedicineDTO>>> GetAll()
    {
        var medicines = _mapper.Map<MedicineDTO>(await _medicineRepository.GetAll());
        return Ok(medicines);
    }
    
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<MedicineDTO>> GetById(Guid id)
    {
        var medicine = _mapper.Map<MedicineDTO>(await _medicineRepository.GetById(id));

        if (medicine == null) return BadRequest();

        return Ok(medicine);
    }
}