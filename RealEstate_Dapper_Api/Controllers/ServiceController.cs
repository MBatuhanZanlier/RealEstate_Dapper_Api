using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.ServiceDtos;
using RealEstate_Dapper_Api.Repositories.ServiceRepository;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceRepository _ServiceRepository;

        public ServiceController(IServiceRepository serviceRepository)
        {
            _ServiceRepository = serviceRepository;
        }

        [HttpGet] 
        public async Task<IActionResult> ServiceList()
        {
            var values= await _ServiceRepository.GetAllServiceAsync(); 
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> AddService(CreateServiceDto Service)
        {
            await _ServiceRepository.CreateServiceAsync(Service);
            return Ok("Başarıyla Eklendi");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteService(int id)
        {
            await _ServiceRepository.DeleteServiceAsync(id);
            return Ok("Başarıyla Silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateService(UpdateServiceDto Service)
        {
            await _ServiceRepository.UpdateServiceAsync(Service);
            return Ok("Başarıyla Güncellendi");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetbyIdService(int id)
        {
            var value = await _ServiceRepository.GetByIdServiceAsync(id);
            return Ok(value);
        }
    }
}
