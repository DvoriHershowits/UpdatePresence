using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Repositories.Entity;
using Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Repositories.Repository
{
    public class CourseRepository : IDataRepository<Course>
    {
        IContext _context;

        public CourseRepository(IContext context)
        {
            _context = context;
        }

        public async Task<Course> AddDataAsync(Course entity)
        {
            EntityEntry<Course> e = await _context.Coureses.AddAsync(entity);
            await _context.SaveChangesAsync();
            return e.Entity;
        }

        public async Task DeleteDataAsync(int id)
        {
            _context.Coureses.Remove(_context.Coureses.FirstOrDefault(p => p.CourseId == id));
            await _context.SaveChangesAsync();
        }

        public async Task<List<Course>> GetAllAsync()
        {
          return await _context.Coureses.ToListAsync();
        }

        public async Task<Course> GetDataByIdAsync(int id)
        {
            return await _context.Coureses.FindAsync(id);
        }

        public async Task<Course> UpdateDataAsync(Course entity)
        {
            EntityEntry<Course> e= _context.Coureses.Update(entity);
            await _context.SaveChangesAsync();
            return e.Entity;
        }
    }
}
