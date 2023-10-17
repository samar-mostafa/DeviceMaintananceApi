using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceMaintanace.Tables
{
    public class BrancheDepartment
    {
        
        public int BranchId { get; set; }
        public Branch Branch { get; set; }

      
        public int DepartmentId { get; set; }

        public Department Department { get; set; }
    }
}
