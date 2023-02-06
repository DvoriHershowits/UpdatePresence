using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Repositories.Entity;
using Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repository
{
    public class GroupOfCourseRepository : IDataRepository<GroupOfCourse>
    {
         private readonly IContext _context;
        public GroupOfCourseRepository(IContext context)
        {
            _context = context;
        }
     
        public async Task<GroupOfCourse> AddDataAsync(GroupOfCourse entity)
        {
            EntityEntry<GroupOfCourse> e = _context.GroupOfCourses.Add(entity);
            await _context.SaveChangesAsync();
            return e.Entity;
        }

        public async Task DeleteDataAsync(int id)
        {
            _context.GroupOfCourses.Remove(_context.GroupOfCourses.FirstOrDefault(p => p.GroupOfCourseId == id));
            await _context.SaveChangesAsync();
        }

        public async Task<List<GroupOfCourse>> GetAllAsync()
        {
            return await _context.GroupOfCourses.ToListAsync();

        }

        public async Task<GroupOfCourse> GetDataByIdAsync(int id)
        {
            return await _context.GroupOfCourses.FindAsync(id);
        }

        public async Task<GroupOfCourse> UpdateDataAsync(GroupOfCourse entity)
        {
            EntityEntry<GroupOfCourse> e = _context.GroupOfCourses.Add(entity);
            await _context.SaveChangesAsync();
            return e.Entity;
        }
    }
}
