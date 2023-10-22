using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceMaintanace.Tables
{
    public class Branch
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<Department> Departments { get; set; }
        public IList<BrancheDepartment> BranchesDepartments { get; set; }

    }
}
