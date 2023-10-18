using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceMaintanace.DAL
{
    public interface IRepository<T> where T:class
    {
        #region
        IQueryable<T> All { get; }
        IQueryable<T> AllUntracked { get; }
        #endregion

        #region Insert
        void Insert(T entity);
        void InsertRange(IEnumerable<T> entities);
        void InsertWithoutSaveChange(T entity);
        void InsertRangeWithoutSaveChange(IEnumerable<T> entities);
        Task InsertAsync(T entity);
        #endregion

        #region Update
        void Update(T entity);
        void UpdateRange(IEnumerable<T> entities);
        void UpdateWithoutSaveChange(T entity);
        Task UpdateAsync(T entity);
        #endregion

        #region Delete
        void Delete(T entity);
        void DeleteWithoutSaveChange(T entity);
        void DeleteRange(IEnumerable<T> entities);
        void DeleteRangeWithoutSaveChange(IEnumerable<T> entities);
        Task DeleteAsync(T entity);

        #endregion

        #region Save

        void SaveChange();
        Task SaveChangeAsnc();

        #endregion
    }
}
