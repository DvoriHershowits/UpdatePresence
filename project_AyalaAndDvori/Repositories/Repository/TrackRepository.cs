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
    internal class TrackRepository : IDataRepository<Track>
    {
        private readonly IContext _context;
        public TrackRepository(IContext context)
        {
            _context = context;
        }

        public async Task<Track> AddDataAsync(Track entity)
        {
            EntityEntry<Track> e = _context.Tracks.Add(entity);
            await _context.SaveChangesAsync();
            return e.Entity;
        }

        public async Task DeleteDataAsync(int id)
        {
            _context.Tracks.Remove(_context.Tracks.FirstOrDefault(p => p.TrackId == id));
            await _context.SaveChangesAsync();
        }

        public async Task<List<Track>> GetAllAsync()
        {
            return await _context.Tracks.ToListAsync();

        }

        public async Task<Track> GetDataByIdAsync(int id)
        {
            return await _context.Tracks.FindAsync(id);
        }

        public async Task<Track> UpdateDataAsync(Track entity)
        {
            EntityEntry<Track> e = _context.Tracks.Add(entity);
            await _context.SaveChangesAsync();
            return e.Entity;
        }
    }
}
