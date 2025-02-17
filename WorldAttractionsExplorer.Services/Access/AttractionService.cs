using Microsoft.EntityFrameworkCore;
using System;
using WorldAttractionsExplorer.DataAccess;
using WorldAttractionsExplorer.DataAccess.Models;
using WorldAttractionsExplorer.Services.Contracts;


namespace WorldAttractionsExplorer.Services.Access
{
    public class AttractionService(ServerDbContext context) : IAttractionService
    {
        private readonly ServerDbContext _context = context;

        public async Task<IEnumerable<Attractions>> GetAllAsync()
        {
            return await _context.Attractions
                    .Include(i => i.PrimaryImage)
                    .Include(i => i.OptionalImages)
                    .Include(a => a.Reviews)
                    .ToListAsync();
        }

        public async Task<Attractions?> GetByIdAsync(int id)
        {
            return await _context.Attractions
                    .Include(a => a.Reviews)
                    .FirstOrDefaultAsync(a => a.AttractionId == id);
        }

        public async Task<Attractions> CreateAsync(Attractions attraction)
        {
            _context.Attractions.Add(attraction);
            await _context.SaveChangesAsync();
            return attraction;
        }

        public async Task<bool> UpdateAsync(int id, Attractions attraction)
        {

            _context.Entry(attraction).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                return await _context.Attractions.AnyAsync(a => a.AttractionId == id);
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var attraction = await _context.Attractions.FindAsync(id);
            if (attraction == null) return false;

            _context.Attractions.Remove(attraction);
            await _context.SaveChangesAsync();
            return true;
        }
    }

}
