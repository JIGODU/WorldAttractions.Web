using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using WorldAttractionsExplorer.DataAccess;
using WorldAttractionsExplorer.DataAccess.Models;
using WorldAttractionsExplorer.Services.Contracts;


namespace WorldAttractionsExplorer.Services.Access
{
    public class AttractionService(ServerDbContext context) : IAttractionContract
    {
        private readonly ServerDbContext _context = context;

        public async Task<IEnumerable<Attractions>> GetAllAsync()
        {
            return await _context.Attractions
                    .Include(c => c.Country)
                    .Include(t => t.AttractionTags)
                    .ToListAsync();
        }

        public async Task<Attractions?> GetByIdAsync(int id)
        {
            return await _context.Attractions
                    .Include(c => c.Country)
                    .Include(t => t.AttractionTags)
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

            var reviews = _context.Reviews.Where(review => review.AttractionId == attraction.AttractionId);

            var images = _context.Images.Where(image => image.AttractionId == attraction.AttractionId);

            _context.Reviews.RemoveRange(reviews);

            _context.Images.RemoveRange(images);

            _context.Attractions.Remove(attraction);

            
            await _context.SaveChangesAsync();
            return true;
        }
    }

}
