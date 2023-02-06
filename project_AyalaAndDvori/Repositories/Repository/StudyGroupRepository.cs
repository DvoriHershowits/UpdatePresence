using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Repositories.Entity;
using Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repository
{
    public class StudyGroupRepository : IDataRepository<StudyGroup>
    {
        private readonly IContext _context;

        public StudyGroupRepository(IContext context)
        {
            _context = context;
        }

        public async Task<StudyGroup> AddDataAsync(StudyGroup entity)
        {
            EntityEntry<StudyGroup> newOne = _context.StudyGroups.Add(entity);
            await _context.SaveChangesAsync();
            return newOne.Entity;
        }

        public async Task DeleteDataAsync(int id)
        {
            _context.StudyGroups.Remove(_context.StudyGroups.FirstOrDefault(p => p.StudyGroupId == id));
            await _context.SaveChangesAsync();
        }
        public async Task<List<StudyGroup>> GetAllAsync()
        {
            return await _context.StudyGroups.ToListAsync();
        }

        public async Task<StudyGroup> GetDataByIdAsync(int id)
        {
            return await _context.StudyGroups.FindAsync(id);
        }

        public async Task<StudyGroup> UpdateDataAsync(StudyGroup entity)
        {
            EntityEntry<StudyGroup> newEntity = _context.StudyGroups.Update(entity);
            await _context.SaveChangesAsync();
            return newEntity.Entity;
        }
    }
}
