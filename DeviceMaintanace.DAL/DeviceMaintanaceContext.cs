using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceMaintanace.DAL
{
    public class DeviceMaintanaceContext:DbContext
    {
        public DeviceMaintanaceContext(DbContextOptions<DeviceMaintanaceContext>options):base(options)
        {
                
        }

        #region overrides
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
        }
        #endregion


        #region entities
        #endregion


    }
}
