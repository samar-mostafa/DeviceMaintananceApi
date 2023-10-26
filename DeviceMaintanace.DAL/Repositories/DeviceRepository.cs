using DeviceMaintanace.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceMaintanace.DAL.Repositories
{
    public class DeviceRepository:Repository<Device>
    {
        public DeviceRepository(DeviceMaintanaceContext db):base(db)
        {

        }

        public Device GetById(string serialNumber)
        {
            var entity = All.SingleOrDefault(d=>d.SerialNumber == serialNumber );
            return entity;
        }

        public bool Exists(string serialNumber)
        {
            serialNumber = serialNumber.ToLower();
            return All.Any(d=>d.SerialNumber.ToLower() == serialNumber);
        }
    }
}
