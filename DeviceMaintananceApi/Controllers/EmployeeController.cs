using DeviceMaintanace.Tables;
using DeviceMaintanance.Core;
using DeviceMaintanance.Core.Commands;
using DeviceMaintanance.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace DeviceMaintananceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : AppControllerBase
    {
        private readonly IEmployeeService service;

        public EmployeeController(IEmployeeService _service)
        {
            service = _service;
        }


        [HttpPost("AddEmployee")]
        public async Task<IActionResult> AddEmployee([FromBody] EmployeeCommand command)
        {
            ServiceResult result = await service.AddAsync(command);
            return Result(result);

        }


        [HttpPost("DeleteEmployee")]
        public async Task<IActionResult> DeleteEmployee(string mobilNumber)
        {
            ServiceResult result = await service.DeleteAsync(mobilNumber);
            return Result(result);
        }


        [HttpPost("EditEmployee")]
        public async Task<IActionResult> EditEmployee([FromBody]EmployeeCommand command)
        {
            ServiceResult result = await service.EditAsync(command);
            return Result(result);
        }

        [HttpGet("GetEmployees")]
        public IActionResult GetEmployees()
        {
            ServiceResult result = service.GetAllEmployees();
            return Result(result);
        }

        [HttpGet("GetEmployeesByBranchId/{branchId}")]
        public IActionResult GetEmployeesByBranchId(int branchId)
        {
            ServiceResult result = service.GetEmployeesByBranchId(branchId);
            return Result(result);
        }

        [HttpGet("GetEmployeesByDepartmentId/{departmentId}")]
        public IActionResult GetEmployeesByDepartmentId(int departmentId)
        {
            ServiceResult result = service.GetEmployeesByDepartmentId(departmentId);
            return Result(result);
        }


    }
}
