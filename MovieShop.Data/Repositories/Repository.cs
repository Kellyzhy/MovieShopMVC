using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MovieShop.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly IDbSet<T> _dbSet; // 
        protected MovieShopDbContext _context; // protected: subclass 

        public Repository(MovieShopDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();// context from dbcontext
        }
        public void Add(T entity) // entity state
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }
        public void Update(T entity)
        {
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            // tell entity framework, to call the entity
            _context.SaveChanges();
        }
        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
            _context.SaveChanges();
        }
        public void Delete(Expression<Func<T, bool>> where)
        {
            var objects = _dbSet.Where(where).AsEnumerable();
            foreach (var obj in objects)
                _dbSet.Remove(obj);
            _context.SaveChanges();
        }

        //virtual method can be override later
        public virtual T GetById(int id)
        {
            return _dbSet.Find(id);
        }
        public virtual T Get(Expression<Func<T, bool>> where)
            // linq, Extention method, type is Iqueryable
            // all the dbset impliment Iqueryable 
        {
            return _dbSet.Where(where).FirstOrDefault();
        }
        public virtual IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
            //.AsNoTracking()
        }
        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
        {
            return _dbSet.Where(where).ToList();
        }
    }
}
