using DeviceMaintanance.Core.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceMaintanance.Core.Interfaces
{
    public interface IEmployeeService
    {
        Task<ServiceResult> AddAsync(EmployeeCommand command);
        Task<ServiceResult> EditAsync(EmployeeCommand command);
        Task<ServiceResult> DeleteAsync(string mobilnumber);
        ServiceResult GetAllEmployees();
        ServiceResult GetEmployeesByDepartmentId(int departmentId);
        ServiceResult GetEmployeesByBranchId(int branchId);

    }
}
