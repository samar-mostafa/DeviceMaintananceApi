using DeviceMaintanance.Core.Commands;
using DeviceMaintanance.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DeviceMaintananceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceController : AppControllerBase
    {
        private readonly IDeviceService _deviceService;

        public DeviceController(IDeviceService deviceService)
        {
            _deviceService = deviceService;
        }
        [HttpPost("AddDeviceType")]
        public async Task<IActionResult> AddDeviceType([FromBody] string type)
        {
            var result = await _deviceService.AddDeviceTypeAsync(type);
            return Result(result);
        }

        [HttpPost("AddDevice")]
        public async Task<IActionResult> AddDevice([FromBody] AddDeviceCommand command)
        {
            var result = await _deviceService.AddDeviceAsync(command);
            return Result(result);
        }

        [HttpPut("EditDevice/{id}")]
        public async Task<IActionResult> EditDevice(string id, [FromBody] EditDeviceCommand command)
        {
            var result = await _deviceService.EditDeviceAsync(id, command);
            return Result(result);
        }

        [HttpPut("EditDeviceType/{id}")]
        public async Task<IActionResult> EditDeviceType(int id, string type)
        {
            var result = await _deviceService.EditDeviceTypeAsync(id, type);
            return Result(result);
        }

        [HttpGet("GetAllDevicesAsSelectList")]
        public IActionResult GetAllDevicesAsSelectList()
        {
            var result = _deviceService.GetAllDevicesAsSelectList();
            return Result(result);
        }

        [HttpGet("GetAllDeviceTypesAsSelectList")]
        public IActionResult GetAllDeviceTypesAsSelectList()
        {
            var result = _deviceService.GetAllDeviceTypesAsSelectList();
            return Result(result);
        }

       
        [HttpGet("GetDevicesByDeviceTypeId")]
        public IActionResult GetDevicesByDeviceTypeId(int id)
        {
            var result=_deviceService.GetDevicesByDeviceTypeId(id);
            return Result(result);
        }

        [HttpGet("GetDeviceBySerial")]
        public IActionResult GetDeviceBySerial(string serial)
        {
            var result = _deviceService.GetDeviceBySerial(serial);
            return Result(result);
        }





    }
}
