using DeviceMaintanance.Core.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceMaintanance.Core.Interfaces
{
    public interface IBranchService
    {
        Task<ServiceResult> AddAsync(AddBranchCommand Command);
        Task<ServiceResult> EditAsync(int id, string name);
        Task<ServiceResult> DeleteAsync(int id);
        ServiceResult GetBranchById(int id);
        ServiceResult GetAllBranchesAsSelectList();
        ServiceResult GetBranchsByDepartmentId(int id);
        ServiceResult GetBranchesWithDepartmens();
        string GetBranchNameById(int id);
    }
}
