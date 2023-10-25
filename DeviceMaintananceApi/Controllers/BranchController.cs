using DeviceMaintanance.Core.Commands;
using DeviceMaintanance.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DeviceMaintanance.Core.Interfaces;
using DeviceMaintanance.Core;
using DeviceMaintanance.Core.ViewModels;

namespace DeviceMaintananceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : AppControllerBase
    {
        private readonly IBranchService _branchService;

        public BranchController(IBranchService branchService)
        {
            _branchService = branchService;
        }

        [HttpPost("AddBranch")]
        public async Task<IActionResult> AddBranch([FromBody] AddBranchCommand branch)
        {
            ServiceResult result =  await _branchService.AddAsync(branch);
            return Result(result);
        }

        [HttpDelete("DeleteBranch")]
        public async Task<IActionResult> DeleteBranch(int id)
        {
            var res =await _branchService.DeleteAsync(id);
            return Result(res);
        }

        [HttpPut("EditBranch")]
        public async Task<IActionResult> EditBranch(int id, string name)
        {
            var res = await _branchService.EditAsync(id,name);
            return Result(res);
        }

        [HttpGet("GetAllBranches")]
        public async Task<IActionResult> GetAllBranches()
        {
            ServiceResult result = await _branchService.GetAllBranches();
            
            return Result(result);
        }

        [HttpGet("GetBranchById")]
        public async Task<IActionResult> GetBranchById(int id)
        {
            ServiceResult result = await _branchService.GetBranchById(id);

            return Result(result);
        }



    }
}
