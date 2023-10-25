using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceMaintanace.Tables
{
    [Index(nameof(Name),IsUnique=true)]
    public class Department
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        public ICollection<Branch> Branches { get; set; }
        public IList<BrancheDepartment> BranchesDepartments { get; set; }
    }
}
