using DeviceMaintanance.Core;
using Microsoft.AspNetCore.Mvc;

namespace DeviceMaintananceApi
{
    public class AppControllerBase:ControllerBase
    {
        public AppControllerBase()
        {

        }

        protected IActionResult Result(ServiceResult result)
        {
            if (result.IsSuccessed)            
                return Ok(result.Result);  
            else            
                return Error(result);           
        }

        protected IActionResult Error(ServiceResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(error.Key, error.Value);
            }
            return BadRequest(ModelState);
        }
    }
}
