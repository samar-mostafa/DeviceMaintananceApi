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
    public class BranchService : IBranchService
    {
        private BranchRepository _repo;
        public BranchService(BranchRepository repo)
        {
            _repo = repo;
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

        public async Task<ServiceResult> EditAsync(int id)
        {
            var entity = _repo.GetById(id);
            _repo.Update(entity);
            await _repo.SaveChangeAsnc();
            return ServiceResult.Success(entity);
        }

        public async Task<ServiceResult> AddAsync(AddBranchCommand Command)
        {
            var branch = new Branch { Name=Command.Name};   
             await _repo.InsertAsync(branch);
            var model = new BranchVM
            {
                Id = branch.Id,
                Name = branch.Name,
            };
            return ServiceResult.Success(model);
        }

        public async Task<ServiceResult> GetAllBranches()
        {
            var res = _repo.All.AsEnumerable();
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

        public async Task<ServiceResult> GetBranchById(int id)
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
    }
}
