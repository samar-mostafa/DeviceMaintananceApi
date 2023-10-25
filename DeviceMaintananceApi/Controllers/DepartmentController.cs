using DeviceMaintanance.Core.Commands;
using DeviceMaintanance.Core;
using DeviceMaintanance.Core.Interfaces;
using DeviceMaintanance.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DeviceMaintananceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : AppControllerBase
    {
        private readonly IDepartmentService _service;
        public DepartmentController(IDepartmentService _service)
        {
            this._service = _service;
        }

        [HttpPost("AddDepartment")]
        public async Task<IActionResult> AddDepartment([FromBody] AddDepartmentCommand branch)
        {
            ServiceResult result = await _service.AddAsync(branch);
            return Result(result);
        }
        [HttpDelete("DeleteDepartment")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            var res = await _service.DeleteAsync(id);
            return Result(res);
        }

        [HttpPut("EditDepartment")]
        public async Task<IActionResult> EditDepartment(int id,string name)
        {
            var res = await _service.EditAsync(id,name);
            return Result(res);
        }
        [HttpGet("GetAllDepartment")]
        public async Task<IActionResult> GetAllDepartment()
        {
            ServiceResult result = await _service.GetAllDepartments();

            return Result(result);
        }
        [HttpGet("GetDepartmentById")]
        public async Task<IActionResult> GetDepartmentById(int id)
        {
            ServiceResult result = await _service.GetDepartmentById(id);

            return Result(result);
        }

        [HttpGet("GetDepartmentsByBranchId")]
        public async Task<IActionResult> GetDepartmentsByBranchId(int id)
        {
            ServiceResult result = await _service.GetDepartmentsByBranchId(id);
            return Result(result);
        }

        [HttpGet("GetDepartmensWithBranches")]
        public async Task<IActionResult> GetDepartmensWithBranches()
        {
            ServiceResult result = await _service.GetDepartmensWithBranches();
            return Result(result);
        }

    }
}
