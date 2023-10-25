using DeviceMaintanace.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceMaintanance.Core.ViewModels
{
    internal class BranchDepartmentsVM
    {
        public string BranchName { get; set; }


        public IList<DepartmentVM> Departments { get; set; }
       
    }
}
