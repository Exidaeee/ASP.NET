using Microsoft.AspNetCore.Mvc;
using ShopRazor_Temp.Data;
using ShopRazor_Temp.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ShopRazor_Temp.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public List<Category> categories { get; set; }
        public IndexModel(ApplicationDbContext db)
        {
            _db= db;
        }
        public void OnGet()
        {
            categories = _db.Categories.ToList();
        }
    }
}
