using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RiscSegPre.Domain.IRepositories
{
    public interface IBaseRepository<TEntity>
        where TEntity : class
    {
        void Insert(TEntity obj);
        Task<int> InsertAsync(TEntity obj);
        void Update(TEntity obj);
        Task UpdateAsync(TEntity obj);
        void Delete(TEntity obj);

        IQueryable<TEntity> GetAll();
        List<TEntity> GetAll(Func<TEntity, bool> where);

        TEntity GetById(int id);
        TEntity Get(Func<TEntity, bool> where);

        IDictionary<int, string> GetDictionary();
    }
}
