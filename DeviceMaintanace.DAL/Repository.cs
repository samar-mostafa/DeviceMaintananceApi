using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DeviceMaintanace.DAL
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public DeviceMaintanaceContext db;
        protected IQueryable<T> data;


        public Repository(DeviceMaintanaceContext db)
        {
            this.db = db;
            data = this.db.Set<T>();
        }

        #region All
        public IQueryable<T> All => data;
        public IQueryable<T> AllUntracked => data.AsNoTracking();

        #endregion
        #region Insert
        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException();
            }

            db.Add(entity);
            db.SaveChanges();
        }

        public void InsertRange(IEnumerable<T> entities)
        {
            if(entities == null)
            {
                throw new ArgumentNullException();
            }
            db.AddRange(entities);
            db.SaveChanges();
        }

        public void InsertWithoutSaveChange(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException();
            }

            db.Add(entity);
        }

        public void InsertRangeWithoutSaveChange(IEnumerable<T> entities)
        {
            if (entities == null)
            {
                throw new ArgumentNullException();
            }
            db.AddRange(entities);
        }

        public async Task InsertAsync(T entity)
        {
            db.AddRange(entity);
            await db.SaveChangesAsync();
        }

        #endregion
        #region Update
        public void Update(T entity)
        {
           db.Update(entity);
            db.SaveChanges();
        }
       public void UpdateRange(IEnumerable<T> entities)
        { 
            if (entities == null)
                return;
            db.UpdateRange(entities);
            db.SaveChanges();
        }
        public void UpdateWithoutSaveChange(T entity)
        {
            db.Update(entity);
        }

        public async Task UpdateAsync(T entity)
        {
            db.Update(entity);
           await db.SaveChangesAsync();
        }

        #endregion
        #region Delete
        public void Delete(T entity)
        {
            db.Remove(entity);
            db.SaveChanges();
        }

        public void DeleteWithoutSaveChange(T entity) => db.Remove(entity);
       

        public void DeleteRange(IEnumerable<T> entities)
        {
            db.RemoveRange(entities);
            db.SaveChanges();
        }

        public void DeleteRangeWithoutSaveChange(IEnumerable<T> entities) => db.RemoveRange(entities);
         

        public async Task DeleteAsync(T entity)
        {
            db.Remove(entity);
            await  db.SaveChangesAsync();
        }
        #endregion

        #region Save
        public void SaveChange()
        {
             db.SaveChanges() ;
        }

        public async Task SaveChangeAsnc()
        {
            await db.SaveChangesAsync();
        }
        #endregion

        

    }
}
