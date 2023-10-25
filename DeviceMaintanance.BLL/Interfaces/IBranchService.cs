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
        Task<ServiceResult> GetBranchById(int id);
        Task<ServiceResult> GetAllBranchesAsSelectList();
    }
}
