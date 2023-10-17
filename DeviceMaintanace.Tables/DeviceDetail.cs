using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceMaintanace.Tables
{
    public class DeviceDetail
    {
        public int Id { get; set; }
        public string SerialNumber { get; set; }
        public DateTime EnteryDate { get; set; }
        public string ProblemDescription { get; set; }
        public bool BackToDevices { get; set; }
        public bool Status { get; set; }

        public string EmployeeMobilePhone { get; set; }

        [ForeignKey("EmployeeMobilePhone")]
        public Employee Employee { get; set; }

        public string ItEmployeeMobilePhone { get; set; }

        [ForeignKey("ItEmployeeMobilePhone")]
        public Employee ItEmployee { get; set; }
    }
}
