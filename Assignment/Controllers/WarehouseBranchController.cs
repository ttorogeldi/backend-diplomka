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
    public class WarehouseBranchController : ControllerBase
    {
        private readonly IWarehouseBranches _warehouseBranchService;

        public WarehouseBranchController(IWarehouseBranches warehouseBranchService)
        {
            _warehouseBranchService = warehouseBranchService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllWarehouseBranches()
        {
            try
            {
                var warehouseBranches = await _warehouseBranchService.GetWarehouseBranches();
                return Ok(new GeneralResponseDTO(true, "Warehouse branches retrieved successfully", warehouseBranches));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new GeneralResponseDTO(false, ex.Message));
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetWarehouseBranchById(int id)
        {
            try
            {
                var warehouseBranch = await _warehouseBranchService.GetWarehouseBranchById(id);
                if (warehouseBranch == null)
                {
                    return NotFound(new GeneralResponseDTO(false, "Warehouse branch not found"));
                }
                return Ok(new GeneralResponseDTO(true, "Warehouse branch retrieved successfully", warehouseBranch));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new GeneralResponseDTO(false, ex.Message));
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddWarehouseBranch(WarehouseBranch warehouseBranch)
        {
            try
            {
                await _warehouseBranchService.AddWarehouseBranch(warehouseBranch);
                return CreatedAtAction(nameof(GetWarehouseBranchById), new { id = warehouseBranch.Id }, new GeneralResponseDTO(true, "Warehouse branch added successfully", warehouseBranch));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new GeneralResponseDTO(false, ex.Message));
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateWarehouseBranch(int id, WarehouseBranch warehouseBranch)
        {
            try
            {
                if (id != warehouseBranch.Id)
                {
                    return BadRequest(new GeneralResponseDTO(false, "Invalid warehouse branch ID"));
                }
                await _warehouseBranchService.UpdateWarehouseBranch(warehouseBranch);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new GeneralResponseDTO(false, ex.Message));
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWarehouseBranch(int id)
        {
            try
            {
                var warehouseBranch = await _warehouseBranchService.DeleteWarehouseBranch(id);
                if (warehouseBranch == null)
                {
                    return NotFound(new GeneralResponseDTO(false, "Warehouse branch not found"));
                }
                return Ok(new GeneralResponseDTO(true, "Warehouse branch deleted successfully", warehouseBranch));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new GeneralResponseDTO(false, ex.Message));
            }
        }
    }
}
