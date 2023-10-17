using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceMaintanace.Tables
{
    public class History
    {
        public int Id { get; set; }
        public int DeadId { get; set; }
        public int MaintananceId { get; set; }

        public Dead Dead { get; set; }
        public Maintanance Maintanance { get; set; }
    }
}
