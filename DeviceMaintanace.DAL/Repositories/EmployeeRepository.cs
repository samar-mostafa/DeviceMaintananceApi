using DeviceMaintanace.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceMaintanace.DAL.Repositories
{
    public class EmployeeRepository : Repository<Employee>
    {
        public EmployeeRepository(DeviceMaintanaceContext db) : base(db)
        {
           
        }

        public Employee GetById(string mobilphone)
        {
            var entity = All.SingleOrDefault(b => b.MobilePhone == mobilphone);
            return entity;
        }

        public bool Exists(string name)
        {
            name = name.ToLower();
            return All.Any(b => b.Name.ToLower() == name);
        }
    }
}
