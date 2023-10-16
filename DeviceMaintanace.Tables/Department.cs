using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceMaintanace.Tables
{
    public class Department
    {
        public int Id { get; set; }
        public int Name { get; set; }

        public ICollection<Branch> Branches { get; set; }
        public IList<BrancheDepartment> BranchesDepartments { get; set; }
    }
}
