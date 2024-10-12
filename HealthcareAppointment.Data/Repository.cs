using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthcareAppointment.Data
{
    internal class Repository
    {
        public class Repository1<T> : IRepository<T> where T : class
        {
            private readonly HealthcareDbContext _context;
            private readonly DbSet<T> _dbSet;

            public Repository1(HealthcareDbContext context)
            {
                _context = context;
                _dbSet = context.Set<T>();
            }

            public async Task<IEnumerable<T>> GetAll() => await _dbSet.ToListAsync();
            public async Task<T> GetById(Guid id) => await _dbSet.FindAsync(id);
            public async Task Add(T entity) => await _dbSet.AddAsync(entity);
            public async Task Update(T entity) => _dbSet.Update(entity);
            public async Task Delete(Guid id)
            {
                var entity = await _dbSet.FindAsync(id);
                if (entity != null) _dbSet.Remove(entity);
            }
        }

    }
}
