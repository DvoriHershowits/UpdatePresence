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
    internal class StudentInGroupOfCourseRepository : IDataRepository<StudentInGroupOfCourse>
    {
        private readonly IContext _context;
        public StudentInGroupOfCourseRepository(IContext context)
        {
            _context = context;
        }

        public async Task<StudentInGroupOfCourse> AddDataAsync(StudentInGroupOfCourse entity)
        {
            EntityEntry<StudentInGroupOfCourse> e = _context.StudentInGroupOfCourses.Add(entity);
            await _context.SaveChangesAsync();
            return e.Entity;
        }

        public async Task DeleteDataAsync(int id)
        {
            _context.StudentInGroupOfCourses.Remove(_context.StudentInGroupOfCourses.FirstOrDefault(p => p.StudentInGroupOfCourseId == id));
            await _context.SaveChangesAsync();
        }

        public async Task<List<StudentInGroupOfCourse>> GetAllAsync()
        {
            return await _context.StudentInGroupOfCourses.ToListAsync();
        }

        public async Task<StudentInGroupOfCourse> GetDataByIdAsync(int id)
        {
            return await _context.StudentInGroupOfCourses.FindAsync(id);
        }

        public async Task<StudentInGroupOfCourse> UpdateDataAsync(StudentInGroupOfCourse entity)
        {
            EntityEntry<StudentInGroupOfCourse> e =_context.StudentInGroupOfCourses.Add(entity);
            await _context.SaveChangesAsync();
            return e.Entity;
        }
    }
}
