using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceMaintanace.Tables
{
    public class Dead
    {
        public int Id { get; set; }
        public string mobilePhone { get; set; }

        public string ITLEADER { get; set; }
        public string FIRSTMEMBER { get; set; }
        public string SECONDMEMBER { get; set; }
        public DateTime DeadDate { get; set; }
        public string Reason { get; set; }
        public int DeviceDetailId { get; set; }
        public DeviceDetail DeviceDetail { get; set; }

        [ForeignKey("mobilePhone")]
        public Employee Employee { get; set; }

        [ForeignKey("ITLEADER")]
        public Employee EmployeeITLEADER { get; set; }

        [ForeignKey("FIRSTMEMBER")]
        public Employee EmployeeFIRSTMEMBER { get; set; }

        [ForeignKey("SECONDMEMBER")]
        public Employee EmployeeSECONDMEMBER { get; set; }
    }
}
