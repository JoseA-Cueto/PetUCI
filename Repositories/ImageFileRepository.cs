using Microsoft.EntityFrameworkCore;
using PetUci.Context;
using PetUci.InterfacesDataBase;
using PetUci.Models;

namespace PetUci.Repositories
{
    public class ImageFileRepository : IImageFileRepository
    {
        private readonly AppDbContext _context;

        public ImageFileRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ImageFiles>> GetAllAsync()
        {
            return await _context.ImageFiles.ToListAsync();
        }

        public async Task<ImageFiles> GetByIdAsync(int id)
        {
            return await _context.ImageFiles.FindAsync(id);
        }

        public async Task<ImageFiles> CreateAsync(ImageFiles imageFile)
        {
            _context.ImageFiles.Add(imageFile);
            await _context.SaveChangesAsync();
            return imageFile;
        }
        public async Task<ImageFiles> CreateImageFile(ImageFiles entity)
        {

            entity.CreateDate = DateTime.Now;
            var imageFileEntry = _context.ImageFiles.Add(entity);
            await _context.SaveChangesAsync();
            return imageFileEntry.Entity;


        }
        public async Task<ImageFiles> GetImageFileByProductIdAsync(int productId)
        {

            return await _context.ImageFiles.FirstOrDefaultAsync(f => f.ProductId == productId);
        }


        public async Task UpdateAsync(ImageFiles imageFile)
        {
            _context.Entry(imageFile).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var imageFile = await _context.ImageFiles.FindAsync(id);
            if (imageFile != null)
            {
                _context.ImageFiles.Remove(imageFile);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<ImageFiles> GetImageByProductIdAsync(int productId)
        {
            return await _context.ImageFiles.FirstOrDefaultAsync(f => f.ProductId == productId);
        }
        public async Task<ImageFiles> GetImageByPetIdAsync (int petId)
        {
            return await _context.ImageFiles.FirstOrDefaultAsync(f => f.PetId == petId);
        }
    }
}
