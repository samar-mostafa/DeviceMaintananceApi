using DeviceMaintanace.DAL.Repositories;
using DeviceMaintanace.Tables;
using DeviceMaintanance.Core.Commands;
using DeviceMaintanance.Core.Interfaces;
using DeviceMaintanance.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceMaintanance.Core.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly EmployeeRepository _repo;
        private readonly IBranchService branchService;
        private readonly IDepartmentService departmentService;

        public EmployeeService(EmployeeRepository repo,IBranchService branchService,IDepartmentService departmentService)
        {
            _repo = repo;
            this.branchService = branchService;
            this.departmentService = departmentService;
        }
        public async Task<ServiceResult> AddAsync(EmployeeCommand command)
        {
            var entity = new Employee
            {
                MobilePhone = command.MobilePhone,
                Name = command.Name,
                NationalId = command.NationalId,
                BrancheId = command.BrancheId,
                DepartmentId = command.DepartmentId
            };
            _repo.Insert(entity);
            await _repo.SaveChangeAsnc();
            var model = new EmployeeVM
            {
                MobilePhone = entity.MobilePhone,
                Name = entity.Name,
                NationalId = entity.NationalId,
                BranchName = branchService.GetBranchNameById(entity.BrancheId),
                DepartmentName = departmentService.GetDepartmentNameById(entity.DepartmentId)
            };
            return ServiceResult.Success(model);
        }

        public async Task<ServiceResult> DeleteAsync(string mobilnumber)
        {
            var entity = _repo.GetById(mobilnumber);
            _repo.Delete(entity);
            await _repo.SaveChangeAsnc();
            var model = new EmployeeVM
            {
               MobilePhone = entity.MobilePhone,
               Name = entity.Name,
               NationalId = entity.NationalId,
               BranchName=branchService.GetBranchNameById(entity.BrancheId),
               DepartmentName=departmentService.GetDepartmentNameById(entity.DepartmentId)
            };
            return ServiceResult.Success(model);
        }

        public async Task<ServiceResult> EditAsync(EmployeeCommand command)
        {
            var entity = _repo.GetById(command.MobilePhone);
            entity.Name = command.Name; 
            entity.NationalId = command.NationalId; 
            entity.BrancheId=command.BrancheId;
            entity.DepartmentId = command.DepartmentId;

            _repo.Update(entity);
            await _repo.SaveChangeAsnc();

            var model = new EmployeeVM
            {
                MobilePhone = entity.MobilePhone,
                Name = entity.Name,
                NationalId = entity.NationalId,
                BranchName = branchService.GetBranchNameById(entity.BrancheId),
                DepartmentName = departmentService.GetDepartmentNameById(entity.DepartmentId)
            };
            return ServiceResult.Success(model);
        }

        public ServiceResult GetAllEmployees()
        {
            var data = _repo.AllUntracked.Select(e => new EmployeeVM
            {
                MobilePhone = e.MobilePhone,
                Name = e.Name,
                NationalId = e.NationalId,
                BranchName = branchService.GetBranchNameById(e.BrancheId),
                DepartmentName = departmentService.GetDepartmentNameById(e.DepartmentId)
            }).ToList(); ;
            return ServiceResult.Success(data);
        }

        public ServiceResult GetEmployeesByBranchId(int branchId)
        {
            var data = _repo.AllUntracked.Where(e => e.BrancheId == branchId).Select(e=> new EmployeeVM
            {
                MobilePhone=e.MobilePhone,
                Name=e.Name,
                NationalId=e.NationalId,
                BranchName = branchService.GetBranchNameById(e.BrancheId),
                DepartmentName = departmentService.GetDepartmentNameById(e.DepartmentId)
            }).ToList();

            return ServiceResult.Success(data);
        }

        public ServiceResult GetEmployeesByDepartmentId(int departmentId)
        {
            var data = _repo.AllUntracked.Where(e => e.DepartmentId == departmentId).Select(e => new EmployeeVM
            {
                MobilePhone = e.MobilePhone,
                Name = e.Name,
                NationalId = e.NationalId,
                BranchName = branchService.GetBranchNameById(e.BrancheId),
                DepartmentName = departmentService.GetDepartmentNameById(e.DepartmentId)
            }).ToList();

            return ServiceResult.Success(data);
        }
    }
}
