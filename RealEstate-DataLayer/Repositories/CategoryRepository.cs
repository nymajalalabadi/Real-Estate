using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RealEstate_DataLayer.Context;
using RealEstate_Domain.Entities.Category;
using RealEstate_Domain.InterFaces;
using RealEstate_Domain.ViewModels.Admin.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate_DataLayer.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        #region constractor

        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        #endregion

        public async Task<Category?> GetCategoryById(int id)
        {
            return await _context.Categories.FindAsync(id);
        }

        public List<SelectListItem> GetAllCategories()
        {
            return _context.Categories
                .Select(g => new SelectListItem()
                {
                    Text = g.Title,
                    Value = g.Id.ToString()
                }).ToList();
        }

        public async Task<List<CategoryAdminViewModel>> GetAllCategoriesForAdmin()
        {
            return await _context.Categories.Select(c => new CategoryAdminViewModel()
            {
                Id = c.Id,
                Title = c.Title,
                Description = c.Description,
            }).ToListAsync();
        }

        public void AddCategory(Category category)
        {
            _context.Categories.Add(category);
        }

        public void UpdateCategory(Category category)
        {
            _context.Categories.Update(category);
        }

        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }

    }
}
