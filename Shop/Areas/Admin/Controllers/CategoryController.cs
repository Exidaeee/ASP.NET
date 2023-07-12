using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.DataAccess.Data;
using Shop.DataAccess.Repository.IRepository;
using Shop.Models;
using Shop.Utility;

namespace ShopWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles =SD.Role_Admin)]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOdWork;
        public CategoryController(IUnitOfWork db)
        {
            _unitOdWork = db;
        }
        public IActionResult Index()
        {
            List<Category> objCategoryList;
            using (_unitOdWork)
            {
                objCategoryList = _unitOdWork.CategoryRepository.GetAll().ToList();
            }
            return View(objCategoryList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                using (_unitOdWork)
                {
                    _unitOdWork.CategoryRepository.Add(category);
                    _unitOdWork.Save();
                }
                TempData["success"] = "Category created successfilly";
                return RedirectToAction("Index", "Category");
            }
            return View();
        }
        public IActionResult Edit(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            using (_unitOdWork)
            {
                Category? category = _unitOdWork.CategoryRepository.Get(id);
                if (category == null)
                {
                    return NotFound();
                }
                return View(category);
            }
        }
        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                using (_unitOdWork)
                {
                    _unitOdWork.CategoryRepository.Update(category);
                    _unitOdWork.Save();
                }
                TempData["success"] = "Category updated successfilly";
                return RedirectToAction("Index", "Category");
            }
            return View();
        }
        public IActionResult Delete(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            using (_unitOdWork)
            {
                Category? category = _unitOdWork.CategoryRepository.Get(id);
                if (category == null)
                {
                    return NotFound();
                }
                return View(category);
            }
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int id)
        {
            using (_unitOdWork)
            {
                Category? category = _unitOdWork.CategoryRepository.Get(id);
                if (category == null)
                {
                    return NotFound();
                }
                _unitOdWork.CategoryRepository.Delete(category);
                _unitOdWork.Save();
            }
            TempData["success"] = "Category deleted successfilly";
            return RedirectToAction("Index", "Category");
        }
    }
}
