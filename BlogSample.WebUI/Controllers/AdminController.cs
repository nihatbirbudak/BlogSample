using BlogSample.BLL.Abstract;
using BlogSample.DTO;
using Microsoft.AspNetCore.Mvc;

namespace BlogSample.WebUI.Controllers
{
    public class AdminController : Controller
    {
        private readonly ICategoryService categoryService;
        public AdminController(ICategoryService _categoryService)
        {
            categoryService = _categoryService;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CategoryList()
        {
            return View(categoryService.getAll());
        }
        public IActionResult CategoryAdd()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CategoryAdd(CategoryDTO categoryDTO)
        {
            categoryService.newCategory(categoryDTO);
            return RedirectToAction("CategoryList");
        }
        public IActionResult CategoryDelete(int id)
        {
            TempData["message"] = "Silme işlemi başarılı";
            categoryService.deleteCategory(id);
            return RedirectToAction("CategoryList");
        }
        
        public IActionResult CategoryEdit(int id)
        {
            return View(categoryService.getCategory(id));
        }
        [HttpPost]
        public IActionResult CategoryEdit(CategoryDTO categoryDTO)
        {
            TempData["message"] = "Günceleme Başarılı";
            categoryService.updateCategory(categoryDTO);
            return RedirectToAction("CategoryList");
        }

    }
}
