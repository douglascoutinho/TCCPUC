using Microsoft.EntityFrameworkCore;
using RiscSegPre.Domain.IRepositories;
using RiscSegPre.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace RiscSegPre.Infra.Data.Repositories
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity>
         where TEntity : class
    {
        private readonly DataContext dataContext;

        public BaseRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public virtual void Insert(TEntity obj)
        {
            dataContext.Entry(obj).State = EntityState.Added;
            dataContext.SaveChanges();
        }

        public virtual void Update(TEntity obj)
        {
            dataContext.Entry(obj).State = EntityState.Modified;
            dataContext.SaveChanges();
        }

        public virtual TEntity GetById(int id)
        {
            return dataContext.Set<TEntity>().Find(id);
        }

        public virtual void Delete(TEntity obj)
        {
            dataContext.Entry(obj).State = EntityState.Deleted;
            dataContext.SaveChanges();
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return dataContext.Set<TEntity>().AsNoTracking();
        }

        public virtual async Task UpdateAsync(TEntity obj)
        {
            dataContext.Entry(obj).State = EntityState.Modified;
            await dataContext.SaveChangesAsync();
        }

        public virtual async Task<int> InsertAsync(TEntity obj)
        {
            dataContext.Entry(obj).State = EntityState.Added;
            return await dataContext.SaveChangesAsync();
        }

        public virtual List<TEntity> GetAll(Func<TEntity, bool> where)
        {
            return dataContext.Set<TEntity>().AsNoTracking().Where(where).ToList();
        }

       

        public virtual TEntity Get(Func<TEntity, bool> where)
        {
            return dataContext.Set<TEntity>().SingleOrDefault(where);
        }

        public virtual IDictionary<int, string> GetDictionary()
        {
            var propAtivo = GetPropertyAtivo();
            var propId = GetPropertyId();
            var propDesc = GetPropertyDesc();

            var query = dataContext.Set<TEntity>().AsNoTracking();

            if (propAtivo != null)
            {
                var condition = GetExpression(propAtivo, true);
                query = query.Where(condition);
            }

            return query.ToDictionary(x => (int)propId.GetValue(x), x => (string)propDesc.GetValue(x));
        }

        private PropertyInfo GetPropertyAtivo()
        {
            return typeof(TEntity).GetProperty("ativo")
                   ?? typeof(TEntity).GetProperty("Ativo");
        }

        private PropertyInfo GetPropertyId()
        {
            return typeof(TEntity).GetProperty("id_" + typeof(TEntity).Name.ToLower())
                   ?? typeof(TEntity).GetProperty("Id" + typeof(TEntity).Name)
                   ?? typeof(TEntity).GetProperty("id_batalhao")
                   ?? typeof(TEntity).GetProperty("id_delegacia");
        }

        private PropertyInfo GetPropertyDesc()
        {
            return typeof(TEntity).GetProperty("nm_" + typeof(TEntity).Name.ToLower())
                   ?? typeof(TEntity).GetProperty("ds_" + typeof(TEntity).Name.ToLower())
                   ?? typeof(TEntity).GetProperty("Nm" + typeof(TEntity).Name)
                   ?? typeof(TEntity).GetProperty("Ds" + typeof(TEntity).Name)
                   ?? typeof(TEntity).GetProperty("ds_batalhao")
                   ?? typeof(TEntity).GetProperty("ds_delegacia");
        }

        private Expression<Func<TEntity, bool>> GetExpression(PropertyInfo property, object value)
        {
            var param = Expression.Parameter(typeof(TEntity));

            return Expression.Lambda<Func<TEntity, bool>>(
                Expression.Equal(Expression.Property(param, property), Expression.Constant(value)),
                param);
        }

        public void Dispose()
        {
            dataContext.Dispose();
        }
    }
}
