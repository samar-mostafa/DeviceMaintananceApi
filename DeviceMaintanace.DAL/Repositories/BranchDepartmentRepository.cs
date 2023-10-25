using DeviceMaintanace.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceMaintanace.DAL.Repositories
{
    public class BranchDepartmentRepository:Repository<BrancheDepartment>
    {
        public BranchDepartmentRepository(DeviceMaintanaceContext db):base(db)
        {

        }

    }
}
