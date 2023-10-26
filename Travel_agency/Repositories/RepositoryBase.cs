using AspNetCoreServicesApp.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Travel_agency.Models;

namespace AspNetCoreServicesApp.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
       

        protected AgencyContext AgencyContext { get; set; }

        public RepositoryBase(AgencyContext agencyContext)
        {
            this.AgencyContext = agencyContext;
        }

        

        public IQueryable<T> FindAll()
        {
            return this.AgencyContext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.AgencyContext.Set<T>().Where(expression).AsNoTracking();
        }

        public void Create(T entity)
        {
            this.AgencyContext.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            this.AgencyContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            this.AgencyContext.Set<T>().Remove(entity);
        }
    }
}