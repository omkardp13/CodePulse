using CodePulseAPI.Data;
using CodePulseAPI.Models.Domain;
using CodePulseAPI.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace CodePulseAPI.Repositories.Implementation
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext dbContext;
        public CategoryRepository(ApplicationDbContext dbContext)
        {
              this.dbContext = dbContext;
        }
        public async Task<Category> CreateAsync(Category category)
        {
           await dbContext.Category.AddAsync(category);
           await dbContext.SaveChangesAsync();

            return category;
        }

        public async Task<Category?> DeleteAsync(Guid id)
        {
            var existingCategory = await dbContext.Category.FirstOrDefaultAsync(x=>x.Id==id);

            if (existingCategory is null)
            {
                return null;
            }

            dbContext.Category.Remove(existingCategory);
            await dbContext.SaveChangesAsync();
            return existingCategory;
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await dbContext.Category.ToListAsync();
        }

        public async Task<Category?> GetByIdAsync(Guid id)
        {
            return await dbContext.Category.FirstOrDefaultAsync(x=>x.Id==id);
        }

        public async Task<Category?> UpdateAsync(Category category)
        {
           var existingCategory=await dbContext.Category.FirstOrDefaultAsync(x=>x.Id ==category.Id);

            if (existingCategory!=null)
            {
                dbContext.Entry(existingCategory).CurrentValues.SetValues(category);
                await dbContext.SaveChangesAsync();
                return category;
            }

            return null;
        }
    }
}
