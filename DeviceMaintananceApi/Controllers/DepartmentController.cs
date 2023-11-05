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
        public async Task<IActionResult> AddDepartment([FromBody] AddDepartmentCommand command)
        {
            ServiceResult result = await _service.AddAsync(command);
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
        public IActionResult GetAllDepartment()
        {
            ServiceResult result =  _service.GetAllDepartmentsAsSelectList();

            return Result(result);
        }
        [HttpGet("GetDepartmentById")]
        public IActionResult GetDepartmentById(int id)
        {
            ServiceResult result =  _service.GetDepartmentById(id);

            return Result(result);
        }

        [HttpGet("GetDepartmentsByBranchId")]
        public IActionResult GetDepartmentsByBranchId(int id)
        {
            ServiceResult result =  _service.GetDepartmentsByBranchId(id);
            return Result(result);
        }

        [HttpGet("GetDepartmensWithBranches")]
        public IActionResult GetDepartmensWithBranches()
        {
            ServiceResult result =  _service.GetDepartmensWithBranches();
            return Result(result);
        }

    }
}
