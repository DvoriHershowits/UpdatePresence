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
    internal class StudentRepository : IDataRepository<Student>
    {
        private readonly IContext context;
        public StudentRepository(IContext context)
        {
            this.context = context;
        }

        public async Task<Student> AddDataAsync(Student entity)
        {
            EntityEntry<Student> e = context.Students.Add(entity);
            await context.SaveChangesAsync();
            return e.Entity;

        }

        public async Task DeleteDataAsync(int id)
        {
            context.Students.Remove(context.Students.FirstOrDefault(p => p.StudentId == id));
            await context.SaveChangesAsync();
        }

        public async Task<List<Student>> GetAllAsync()
        {
            return await context.Students.ToListAsync();
        }

        public async Task<Student> GetDataByIdAsync(int id)
        {
            return await context.Students.FindAsync(id);
        }

        public async Task<Student> UpdateDataAsync(Student entity)
        {
            EntityEntry<Student> e = context.Students.Update(entity);
            await context.SaveChangesAsync();
            return e.Entity;
        }
    }
}
