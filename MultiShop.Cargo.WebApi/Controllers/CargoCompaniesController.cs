using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoCompanyDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCompaniesController : ControllerBase
    {
        private readonly ICargoCompanyService _cargoCompanyService;

        public CargoCompaniesController(ICargoCompanyService cargoCompanyService)
        {
            _cargoCompanyService = cargoCompanyService;
        }

        [HttpGet]
        public IActionResult CargoCompanyList()
        {
            var values = _cargoCompanyService.TGetAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateCargoCatergory(CreateCargoCompanyDto crateCargoCompanyDto)
        {
            CargoCompany cargoCompany = new CargoCompany
            {
                CargoCompanyName = crateCargoCompanyDto.CargoCompanyName
            };
            _cargoCompanyService.TInsert(cargoCompany);
            return Ok("Kargo Şirketi Başarıyla Oluşturuldu");
        }

        [HttpDelete]
        public IActionResult RemoveCargoCatergory(int id)
        {
            _cargoCompanyService.TDelete(id);
            return Ok("Kargo Şirketi Başarıyla Silindi");
        }

        [HttpGet("{id}")]
        public IActionResult GetCargoCatergoryById(int id)
        {
            var value = _cargoCompanyService.TGetById(id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateCargoCompany(UpdateCargoCompanyDto updateCargoCompanyDto)
        {
            var value = _cargoCompanyService.TGetById(updateCargoCompanyDto.CargoCompanyId);
            value.CargoCompanyName = updateCargoCompanyDto.CargoCompanyName;
            _cargoCompanyService.TUpdate(value);
            return Ok("Kargo Şirketi Başarıyla güncellendi");
        }
    }
}
