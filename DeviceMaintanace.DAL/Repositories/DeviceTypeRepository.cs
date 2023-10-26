using DeviceMaintanace.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceMaintanace.DAL.Repositories
{
    public class DeviceTypeRepository:Repository<DeviceType>
    {
        public DeviceTypeRepository(DeviceMaintanaceContext db):base(db)
        {

        }

        public DeviceType GetById(int id)
        {
            var entity = All.SingleOrDefault(b => b.Id == id);
            return entity;
        }

        public bool Exists(string name)
        {
            name = name.ToLower();
            return All.Any(b => b.Type.ToLower() == name);
        }





    }
}
