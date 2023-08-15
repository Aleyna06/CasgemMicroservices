﻿using CasgemMicroservices.Services.Cargo.BusinessLayer.Abstract;
using CasgemMicroservices.Services.Cargo.EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CasgemMicroservices.Services.Cargo.WepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoStatesController : ControllerBase
    {
        private readonly ICargoStateService _cargoStateService;

        public CargoStatesController(ICargoStateService cargoStateService)
        {
            _cargoStateService = cargoStateService;
        }
        [HttpGet]
        public IActionResult CargoStateList()
        {
            var values = _cargoStateService.GetAll();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public IActionResult CargoStateGet(int id)
        {
            var values = _cargoStateService.GetById(id);
            return Ok(values);

        }
        [HttpPost]
        public IActionResult CargoStateCreate(CargoState cargoState)
        {
            _cargoStateService.Insert(cargoState);
            return Ok("Kargo Durumu  Eklendi");
        }
        [HttpPut]
        public IActionResult CargoStateUpdate(CargoState cargoState)
        {
            _cargoStateService.Update(cargoState);
            return Ok("Kargo Durumu Güncellendi");
        }
        [HttpDelete]
        public IActionResult CargoStateDelete(CargoState cargoState)
        {
            _cargoStateService.Delete(cargoState);
            return Ok("Kargo Durumu Silindi");
        }
    }
}
