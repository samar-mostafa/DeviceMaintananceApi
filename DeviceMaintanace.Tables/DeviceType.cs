using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceMaintanace.Tables
{
    public class DeviceType
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public Device Device { get; set; }
    }
}
