using DeviceMaintanace.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceMaintanance.Core.ViewModels
{
    public class DevicesByDeviceTypeVM
    {
        public int DeviceTypeId { get; set; }
        public string Type { get; set; }
        public IList<DeviceVMForDeviceType> Devices { get; set; }
    }
}
