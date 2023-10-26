using DeviceMaintanance.Core.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceMaintanance.Core.Interfaces
{
    public interface IDeviceService
    {
        Task<ServiceResult> AddDeviceTypeAsync(string deviceType);
        Task<ServiceResult> EditDeviceTypeAsync(int id, string name);
        
        ServiceResult GetAllDeviceTypesAsSelectList();
        Task<ServiceResult> AddDeviceAsync(AddDeviceCommand command);
        Task<ServiceResult> EditDeviceAsync(string serial, EditDeviceCommand command);
        ServiceResult GetDeviceBySerial(string serial);
        ServiceResult GetAllDevicesAsSelectList();
        ServiceResult GetDevicesByDeviceTypeId(int id);
    }
}
