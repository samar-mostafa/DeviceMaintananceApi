using DeviceMaintanance.Core.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceMaintanance.Core.Interfaces
{
    public interface IDepartmentService
    {
        Task<ServiceResult> AddAsync(AddDepartmentCommand Command);
        Task<ServiceResult> EditAsync(int id, string name);
        Task<ServiceResult> DeleteAsync(int id);
        ServiceResult GetDepartmentById(int id);
        ServiceResult GetAllDepartmentsAsSelectList();
        ServiceResult GetDepartmentsByBranchId(int id);
        ServiceResult GetDepartmensWithBranches();
    }
}
