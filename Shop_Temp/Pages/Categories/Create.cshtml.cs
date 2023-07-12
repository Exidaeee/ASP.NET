using Microsoft.AspNetCore.Mvc;
using ShopRazor_Temp.Data;
using ShopRazor_Temp.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ShopRazor_Temp.Pages.Categories
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public Category category { get; set; }
        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
        }

        public IActionResult OnPost(Category category) 
        { 
            _db.Categories.Add(category);
            _db.SaveChanges();
            TempData["success"] = "Category created successfilly";
            return RedirectToPage("Index");
        }
    }
}
