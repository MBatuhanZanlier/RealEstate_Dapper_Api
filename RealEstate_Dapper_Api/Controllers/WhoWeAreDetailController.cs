using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.WhoWeAreDetailDtos;
using RealEstate_Dapper_Api.Repositories.WhoWeAreRepository;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WhoWeAreDetailController : ControllerBase
    {
        private readonly IWhoWeAreDetailRepository _repository;

        public WhoWeAreDetailController(IWhoWeAreDetailRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public async Task<IActionResult> WhoWeAreDetailList()
        {
            var values =await _repository.GetAllWhoWeAreAsync();
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateWhoWeAreDetail(CreateWhoWeAreDetailDto createWhoWeAreDetail)
        {
            _repository.CreateWhoWeAreDetailAsync(createWhoWeAreDetail);
            return Ok("Başaryıla oluşturuldu");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWhoWeAreDetail(int id)
        {
            _repository.DeleteWhoWeAreDetailAsync(id);
            return Ok("Kategori Başarılı Bir Şekilde  Silindi");

        }
        [HttpPut]
        public async Task<IActionResult> UpdateWhoWeAreDetail(UpdateWhoWeAreDetailDto updateWhoWeAreDetailDto)
        {
            _repository.UpdateWhoWeAreDetailAsync(updateWhoWeAreDetailDto);
            return Ok("Başarıyla güncellendi");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetWhoWeAreDetail(int id)
        {
            var values = await _repository.GeyByIdWhoAreAsync(id);
            return Ok(values);
        }
    }
}
