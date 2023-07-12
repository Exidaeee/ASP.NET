using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Shop.DataAccess.Data;
using Shop.DataAccess.Repository.IRepository;
using Shop.Models;
using Shop.Models.NewModels;
using Shop.Utility;
using System.Data;

namespace ShopWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductController(IUnitOfWork db, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = db;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            List<Product> objProductList;
            using (_unitOfWork)
            {
                objProductList = _unitOfWork.ProductRepository.GetAll(includeProperties: "Category").ToList();
            }
            return View(objProductList);
        }
        public IActionResult Upsert(int id)
        {
            ProductVM productVM = new()
            {
                ListItems = _unitOfWork.CategoryRepository.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                }),
                Product = new Product()
            };           
            if (id == 0)
            {               
                return View(productVM);
            }
            else
            {                
                productVM.Product = _unitOfWork.ProductRepository.Get(id);
                return View(productVM);
            }

        }
        [HttpPost]
        public IActionResult Upsert(ProductVM productVM, int id, IFormFile? imageFile)// image
        {           
            productVM.Product.Id = id;
            if (ModelState.IsValid)
            {               
                if (id == 0)
                {
                    _unitOfWork.ProductRepository.Add(productVM.Product);
                }
                else
                {
                    _unitOfWork.ProductRepository.Update(productVM.Product);
                }
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (imageFile != null)
                {                                    
                        string fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
                        string productPath = Path.Combine(wwwRootPath, "images", "product");
                        string filePath = Path.Combine(productPath, fileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        imageFile.CopyTo(fileStream);
                    }
                    productVM.Product.ImgUrl = @"images\product\" + fileName;
                }
                TempData["success"] = "Product created/updated successfully";
                _unitOfWork.Save();
                return RedirectToAction("Index");
            }           
            else
            {
                productVM.ListItems = _unitOfWork.CategoryRepository.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                });
                return View(productVM);
            }
        }
    

        public IActionResult Delete(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            using (_unitOfWork)
            {
                Product? product = _unitOfWork.ProductRepository.Get(id);
                if (product == null)
                {
                    return NotFound();
                }
                return View(product);
            }
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int id)
        {
            using (_unitOfWork)
            {
                Product? product = _unitOfWork.ProductRepository.Get(id);
                if (product == null)
                {
                    return NotFound();
                }
                _unitOfWork.ProductRepository.Delete(product);
                _unitOfWork.Save();
            }
            TempData["success"] = "Product deleted successfilly";
            return RedirectToAction("Index", "Product");
        }
    }
}
