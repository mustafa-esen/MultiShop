using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoCompanyDtos;
using MultiShop.Cargo.DtoLayer.Dtos.CargoOperationDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoOperationsController : ControllerBase
    {
        private readonly ICargoOperationService _cargoOperationService;

        public CargoOperationsController(ICargoOperationService cargoOperationService)
        {
            _cargoOperationService = cargoOperationService;
        }

        [HttpGet]
        public IActionResult CargoOperationList()
        {
            var values = _cargoOperationService.TGetAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateCargoOperation(CreateCargoOperationDto createCargoOperationDto)
        {
            CargoOperation CargoOperation = new CargoOperation
            {
               Barcode = createCargoOperationDto.Barcode,
               Description = createCargoOperationDto.Description,
               OperationDate = createCargoOperationDto.OperationDate,
            };
            _cargoOperationService.TInsert(CargoOperation);
            return Ok("Kargo Operasyonu Başarıyla Oluşturuldu");
        }

        [HttpDelete]
        public IActionResult RemoveCargoOperation(int id)
        {
            _cargoOperationService.TDelete(id);
            return Ok("Kargo Operasyonu Başarıyla Silindi");
        }

        [HttpGet("{id}")]
        public IActionResult GetCargoOperationById(int id)
        {
            var value = _cargoOperationService.TGetById(id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateCargoOperation(UpdateCargoOperationDto updateCargoOperationDto)
        {
            var value = _cargoOperationService.TGetById(updateCargoOperationDto.CargoOperationId);
            value.Barcode = updateCargoOperationDto.Barcode;
            value.Description = updateCargoOperationDto.Description;
            value.OperationDate = updateCargoOperationDto.OperationDate;
            _cargoOperationService.TUpdate(value);
            return Ok("Kargo Operasyonu Başarıyla Güncellendi");
        }
    }
}
