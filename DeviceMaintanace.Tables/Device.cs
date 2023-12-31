﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceMaintanace.Tables
{
    public class Device
    {
        [Key]
        public string SerialNumber { get; set; }
        public string DeviceModel { get; set; }
        public int DeviceTypeId { get; set; }
        public DeviceType DeviceType { get; set; }
    }
}
