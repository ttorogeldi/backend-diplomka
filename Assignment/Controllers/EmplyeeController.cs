using Assignment.DTO;
using Assignment.Interfaces;
using Assignment.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployees _employeeService;

        public EmployeeController(IEmployees employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            try
            {
                var employees = _employeeService.GetEmployeeDetails();
                return Ok(new GeneralResponseDTO(true, "Employees retrieved successfully", employees));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new GeneralResponseDTO(false, ex.Message));
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            try
            {
                var employee = _employeeService.GetEmployeeDetails(id);
                if (employee == null)
                {
                    return NotFound(new GeneralResponseDTO(false, "Employee not found"));
                }
                return Ok(new GeneralResponseDTO(true, "Employee retrieved successfully", employee));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new GeneralResponseDTO(false, ex.Message));
            }
        }

        [HttpPost]
        public IActionResult AddEmployee(Employee employee)
        {
            try
            {
                _employeeService.AddEmployee(employee);
                return CreatedAtAction(nameof(GetEmployeeById), new { id = employee.EmployeeID }, new GeneralResponseDTO(true, "Employee added successfully", employee));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new GeneralResponseDTO(false, ex.Message));
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateEmployee(int id, Employee employee)
        {
            try
            {
                if (id != employee.EmployeeID)
                {
                    return BadRequest(new GeneralResponseDTO(false, "Invalid employee ID"));
                }
                _employeeService.UpdateEmployee(employee);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new GeneralResponseDTO(false, ex.Message));
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            try
            {
                var employee = _employeeService.DeleteEmployee(id);
                if (employee == null)
                {
                    return NotFound(new GeneralResponseDTO(false, "Employee not found"));
                }
                return Ok(new GeneralResponseDTO(true, "Employee deleted successfully", employee));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new GeneralResponseDTO(false, ex.Message));
            }
        }
    }
}
