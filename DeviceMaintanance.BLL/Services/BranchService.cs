using DeviceMaintanace.DAL.Repositories;
using DeviceMaintanace.Tables;
using DeviceMaintanance.Core.Commands;
using DeviceMaintanance.Core.Interfaces;
using DeviceMaintanance.Core.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace DeviceMaintanance.Core.Services
{
    public class BranchService : IBranchService
    {
        private BranchRepository _repo;
        private readonly BranchDepartmentRepository _branchDepartmentRepo;

        public BranchService(BranchRepository repo , BranchDepartmentRepository branchDepartmentRepo)
        {
            _repo = repo;
            _branchDepartmentRepo = branchDepartmentRepo;
        }
        public async Task<ServiceResult> AddAsync(AddBranchCommand Command)
        {
            var branch = new Branch { Name = Command.Name };
            await _repo.InsertAsync(branch);
            var model = new BranchVM
            {
                Id = branch.Id,
                Name = branch.Name,
            };
            return ServiceResult.Success(model);
        }
        public async Task<ServiceResult> DeleteAsync(int id)
        {
            var entity = _repo.GetById(id);
            _repo.Delete(entity);
            await _repo.SaveChangeAsnc();
            var model = new BranchVM
            {
                Id = entity.Id,
                Name = entity.Name,
            };
            return ServiceResult.Success(model);
        }

        public async Task<ServiceResult> EditAsync(int id, string name)
        {
            var entity = _repo.GetById(id);
            entity.Name = name;
            _repo.Update(entity);
            await _repo.SaveChangeAsnc();
            var model = new BranchVM
            {
                Id = entity.Id,
                Name = entity.Name,
            };
            return ServiceResult.Success(model);
        }

        public ServiceResult GetAllBranchesAsSelectList()
        {
            var res = _repo.All;
            var data = new List<BranchVM>();
            foreach (var branch in res)
            {
                data.Add(new BranchVM
                {
                    Id = branch.Id,
                    Name = branch.Name,
                });
            }
            return ServiceResult.Success(data);

        }

        public ServiceResult GetBranchById(int id)
        {
            try
            {
                var entity = _repo.GetById(id);
                if (entity == null)
                    return ServiceResult.Error($"{id}--this id doesn't exist");
                var model = new BranchVM
                {
                    Id = entity.Id,
                    Name = entity.Name,
                };
                return ServiceResult.Success(model);
            }
            catch(Exception e)
            {
                return ServiceResult.Error(e.Message);
            }
        
                
           
        }

        public  ServiceResult GetBranchsByDepartmentId(int id)
        {
            var data = _branchDepartmentRepo.All.
                Include(bd => bd.Department).
                Include(bd => bd.Branch).
                Where(bd => bd.DepartmentId == id).
                GroupBy(bd => bd.Department.Name).Select(bd => new DepartmentBranchsVM

                {
                    DepartmentName = bd.Key,
                    Branches = bd.Select(d => new BranchVM
                    {
                        Id = d.BranchId,
                        Name = d.Branch.Name

                    }).ToList()
                });
            return ServiceResult.Success(data);
        }

        public ServiceResult GetBranchesWithDepartmens()
        {
            var data = _branchDepartmentRepo.All.
                Include(bd => bd.Department).
                Include(bd => bd.Branch).
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

        public string GetBranchNameById(int id) => _repo.AllUntracked.SingleOrDefault(b => b.Id == id).Name;
        
    }
}
