﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceMaintanace.Tables
{
    public class Employee
    {
        [Key]        
        public string MobilePhone { get; set; }
        public string NationalId { get; set; }
        public string Name { get; set; }       
        public int BrancheId { get; set; }
      
        public int DepartmentId { get; set; }


        [ForeignKey("BrancheId,DepartmentId")]
        public BrancheDepartment BrancheDepartment { get; set; }

    }
}
