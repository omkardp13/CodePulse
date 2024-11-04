using CodePulseAPI.Data;
using CodePulseAPI.Models.Domain;
using CodePulseAPI.Repositories.Interface;

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
    }
}
