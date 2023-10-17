using DeviceMaintanace.Tables;
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
            modelBuilder.Entity<Branch>().
                HasMany(b => b.Departments)
                .WithMany(d => d.Branches)
                .UsingEntity<BrancheDepartment>(
                bd =>
                {
                    bd.HasOne(bd => bd.Branch)
                                   .WithMany(b => b.BranchesDepartments)
                                   .HasForeignKey(bd => bd.BranchId);


                    bd.HasOne(bd => bd.Department)
                                    .WithMany(d => d.BranchesDepartments)
                                    .HasForeignKey(bd => bd.DepartmentId);

                    bd.HasKey(bd => new { bd.BranchId ,bd.DepartmentId });
                });
           
        }
        #endregion


        #region entities
        public DbSet< Branch>Branches { get; set; }
        public DbSet<Department>Departments { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<DeviceType>deviceTypes { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<DeviceStatus> DeviceStatuses { get; set; }
        public DbSet<BrancheDepartment> BrancheDepartments { get; set; }

        #endregion


    }
}
