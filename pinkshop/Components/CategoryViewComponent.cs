using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pinkshop.Data;

namespace pinkshop.Components
{
    public class CategoryViewComponent: ViewComponent
    {
        private readonly AppDBContext _dbContext;
        public CategoryViewComponent(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var CateList = await _dbContext.Categories.ToListAsync();
            return View(CateList);
        }

    }
}
