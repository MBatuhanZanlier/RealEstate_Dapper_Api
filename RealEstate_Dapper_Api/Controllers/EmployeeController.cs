using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.EmployeeDtos;
using RealEstate_Dapper_Api.Repositories.EmployeeRepositoreies;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    { 
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet] 
        public async Task<IActionResult> EmployeeList()
        {
            var values= await _employeeRepository.GetAllEmployeeAsync(); 
            return Ok(values);  
        }
        [HttpPost] 
        public async Task<IActionResult> CreateEmploye(CreateEmployeeDto createEmployeeDto)
        {
           _employeeRepository.CreateEmployeeAsync(createEmployeeDto);
            return Ok("Başarıyla Eklendi");
        }
        [HttpDelete("{id}")] 
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            _employeeRepository.DeleteEmployeeAsync(id);
            return Ok("Başarıyla Silindi");
        }
        [HttpPut] 
        public async Task<IActionResult> UpdateEmployee(UpdateEmployeeDto updateEmployeeDto)
        {
          _employeeRepository.UpdateEmployeeAsync(updateEmployeeDto);
            return Ok("Başarıyla Güncellendi"); 
        }
        [HttpGet("{id}")] 
        public async Task<IActionResult>  GetByıdEmployee(int id)
        {
            var values= await _employeeRepository.GetbyIdEmployeeAsync(id); 
            return Ok(values);
        }
    }
}
