using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceMaintanance.Core.Commands
{
    public class AddDeviceCommand:EditDeviceCommand
    {
        [Required(ErrorMessage ="يجب ادخال السيريال"),MaxLength(7,ErrorMessage ="يجب ادخال 7 حروف فقط")]
        public string SerialNumber { get; set; }
      
    }

    public class EditDeviceCommand
    {
       
        [Required]
        public string DeviceModel { get; set; }
        [Required]
        public int DeviceTypeId { get; set; }
    }
}
