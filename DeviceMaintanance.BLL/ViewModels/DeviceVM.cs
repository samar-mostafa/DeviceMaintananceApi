using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceMaintanance.Core.ViewModels
{
    public class DeviceVM
    {
        public string SerialNumber { get; set; }
       
        public string DeviceModel { get; set; }
       
        public string DeviceType { get; set; }
    }

    public class DeviceVMForDeviceType
    {
        public string SerialNumber { get; set; }

        public string DeviceModel { get; set; }
    }
}
