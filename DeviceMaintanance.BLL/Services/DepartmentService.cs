using DeviceMaintanace.DAL.Repositories;
using DeviceMaintanace.Tables;
using DeviceMaintanance.Core.Commands;
using DeviceMaintanance.Core.Interfaces;
using DeviceMaintanance.Core.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceMaintanance.Core.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly DepartmentRepository _repo;
        private readonly BranchDepartmentRepository branchDepartmentRepo;
        private readonly IBranchService branchService;

        public DepartmentService(DepartmentRepository repo, BranchDepartmentRepository branchDepartmentRepo,
            IBranchService branchService)
        {
            _repo = repo;
            this.branchDepartmentRepo = branchDepartmentRepo;
            this.branchService = branchService;
        }
        public async Task<ServiceResult> AddAsync(AddDepartmentCommand Command)
        {
            var department = new Department { Name = Command.Name };
            await _repo.InsertAsync(department);
            var branchDepartment = new BrancheDepartment
            {
                BranchId = Command.BranchId,
                DepartmentId = department.Id
            };

            await branchDepartmentRepo.InsertAsync(branchDepartment);
            var model = new DepartmentVM
            {
                Id = department.Id,
                Name = department.Name
            };
            return ServiceResult.Success(model);
        }

        public async Task<ServiceResult> DeleteAsync(int id)
        {
            var entity = _repo.GetById(id);
            if(entity == null)
                return ServiceResult.Error("id not found");
            _repo.Delete(entity);
            await _repo.SaveChangeAsnc();
            var model = new DepartmentVM
            {
                Id = entity.Id,
                Name = entity.Name,
            };
            return ServiceResult.Success(model);
        }

        public async Task<ServiceResult> EditAsync(int id, string name)
        {
            var entity = _repo.GetById(id);
            if (entity == null)
                return ServiceResult.Error("id not found");
            entity.Name = name;
            _repo.Update(entity);
            var model = new DepartmentVM
            {
                Id = entity.Id,
                Name = entity.Name,
            };
            await _repo.SaveChangeAsnc();
            return ServiceResult.Success(model);
        }

        public ServiceResult GetAllDepartmentsAsSelectList()
        {
            var res = _repo.All;
            var data = new List<DepartmentVM>();
            foreach (var d in res)
            {
                data.Add(new DepartmentVM
                {
                    Id = d.Id,
                    Name = d.Name,
                });
            }
            return ServiceResult.Success(data);
        }

        public ServiceResult GetDepartmentsByBranchId(int id)
        {
            var data = branchDepartmentRepo.All.
                Include(bd => bd.Department).
                Include(bd => bd.Branch).
                Where(bd => bd.BranchId==id).
                GroupBy(bd => bd.Branch.Name).Select(bd => new BranchDepartmentsVM

                {
                    BranchName = bd.Key,
                    Departments = bd.Select(d => new DepartmentVM
                    {
                        Id = d.DepartmentId,
                        Name = d.Department.Name

                    }).ToList()
                });
            return ServiceResult.Success(data);
        }

        public  ServiceResult GetDepartmensWithBranches()
        {
            //var data = branchDepartmentRepo.All.
            //    Include(bd => bd.Department).
            //    Include(bd => bd.Branch).
            //    GroupBy(bd => bd.Department.Name).Select(bd =>new DepartmentBranchsVM
            //    {
            //        DepartmentName = bd.Key,
            //        Branches= bd.Select(d=>new BranchVM
            //        {
            //            Id=d.BranchId,
            //            Name=d.Branch.Name

            //        }).ToList() 
            //    });
            var data = branchDepartmentRepo.All.
                Include(bd => bd.Department).
                Include(bd => bd.Branch).
                GroupBy(bd => bd.BranchId).Select(bd => new BranchsDepartmentsVM
                {
                    Branche = bd.Select(d => new BranchVM
                    {
                        Id = d.BranchId,
                        Name = d.Branch.Name

                    }).FirstOrDefault(),
                    DepartmentsNames = bd.Select(d => d.Department.Name).ToList(),
                }) ;
            return ServiceResult.Success(data);
        }

        public  ServiceResult GetDepartmentById(int id)
        {
            try
            {
                var entity = _repo.GetById(id);
                if (entity == null)
                    return ServiceResult.Error($"{id}--this id doesn't exist");
                var model = new DepartmentVM
                {
                    Id = entity.Id,
                    Name = entity.Name,
                };
                return ServiceResult.Success(model);
            }
            catch (Exception e)
            {
                return ServiceResult.Error(e.Message);
            }
        }
    }
}
