using AbbyWeb.Data;
using AbbyWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Categories
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public Category Category { get; set; }

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public void OnGet(int id)
        {
            Category = _context.Categories.SingleOrDefault(x=> x.Id == id);
        }
        public async Task<IActionResult> OnPost()
        {
            
                var dbCategory = _context.Categories.SingleOrDefault(x => x.Id.Equals(Category.Id));
                if (dbCategory != null)
                {
                    _context.Categories.Remove(dbCategory);
                    await _context.SaveChangesAsync();
                    return RedirectToPage("Index");

                }        
            return Page();
        }
    }
}
