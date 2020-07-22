using BlogSample.BLL.Abstract;
using BlogSample.DTO;
using BlogSample.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogSample.WebUI.Controllers
{
    public class AdminController : Controller
    {
        private readonly ICategoryService categoryService;
        private readonly IUserService userService;
        private readonly IRoleService roleService;
        private readonly IArticleService articleService;
        public AdminController(ICategoryService _categoryService, IUserService _userService, IRoleService _roleService, IArticleService _articleService)
        {
            categoryService = _categoryService;
            userService = _userService;
            roleService = _roleService;
            articleService = _articleService;
        }
        public IActionResult Index()
        {
            return View();
        }



        #region Role İşlemleri
        public IActionResult RoleList()
        {
            return View(roleService.getAll());
        }
        public IActionResult RoleAdd()
        {
            return View();
        }
        [HttpPost]
        public IActionResult RoleAdd(RoleDTO role)
        {
            roleService.newRole(role);
            return RedirectToAction("RoleList");
        }
        public IActionResult RoleDelete(int id)
        {
            TempData["message"] = "Role başarı ile silindi.";
            roleService.deleteRole(id);
            return RedirectToAction("RoleList");
        }
        public IActionResult RoleEdit(int id)
        {
            return View(roleService.getRole(id));
        }
        [HttpPost]
        public IActionResult RoleEdit(RoleDTO role)
        {
            TempData["message"] = "Role başarı ile güncellendi";
            roleService.updateRole(role);
            return RedirectToAction("RoleList");
        }
        #endregion



        #region Category İşlemler
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
        #endregion



        #region User İşlemleri
        public IActionResult UserList()
        {
            return View(userService.getAll());
        }
        public IActionResult UserAdd()
        {
            return View();
        }
        [HttpPost]
        public IActionResult UserAdd(UserDTO userDTO)
        {
            TempData["message"] = "Kullanıcı başarı ile eklendi";
            userService.newUser(userDTO);
            return RedirectToAction("UserList");
        }

        #endregion



        #region Article İşlemleri
        public IActionResult ArticleList()
        {
            ArticleViewModel model = new ArticleViewModel();
            model.ArticleDTOs = articleService.getAll();
            model.CategoryDTOs = categoryService.getAll();
            return View(model);
        }
        public IActionResult ArticleAdd()
        {
            ArticleViewModel model = new ArticleViewModel();
            model.CategoryDTOs = categoryService.getAll();
            return View(model);
        }
        [HttpPost]
        public IActionResult ArticleAdd(ArticleDTO articleDTO)
        {
            ArticleViewModel model = new ArticleViewModel();
            model.ArticleDTOs = articleService.getAll();
            model.CategoryDTOs = categoryService.getAll();
            articleService.newArticle(articleDTO);
            return RedirectToAction("ArticleList");
        }


        #endregion
    }
}
