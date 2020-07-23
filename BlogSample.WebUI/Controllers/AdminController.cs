using BlogSample.BLL.Abstract;
using BlogSample.DTO;
using BlogSample.WebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;

namespace BlogSample.WebUI.Controllers
{
    [Authorize(Roles = "Admin,Yonetici")]
    public class AdminController : BaseController
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
            UserViewModel model = new UserViewModel();
            model.UserDTOs = userService.getAll();
            model.RoleDTOs = roleService.getAll();
            return View(model);
        }
        public IActionResult UserAdd()
        {
            UserViewModel model = new UserViewModel();
            model.RoleDTOs = roleService.getAll();
            return View(model);
        }
        [HttpPost]
        public IActionResult UserAdd(UserDTO userDTO)
        {
            TempData["message"] = "Kullanıcı başarı ile eklendi";
            userService.newUser(userDTO);
            return RedirectToAction("UserList");
        }
        public IActionResult UserDelete(int id)
        {
            userService.deleteUser(id);
            return RedirectToAction("UserList");
        }
        public IActionResult UserEdit(int id)
        {
            var model = new UserViewModel();
            model.RoleDTOs = roleService.getAll();
            model.UserDTO = userService.getUser(id);
            return View(model);
        }
        [HttpPost]
        public IActionResult UserEdit(UserDTO userDTO)
        {
            userService.updateUser(userDTO);
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
        public async Task<IActionResult> ArticleAdd(ArticleDTO articleDTO, IFormFile file)
        {
            if (file != null)
            {
                var extention = Path.GetExtension(file.FileName);
                var randomName = string.Format($"{Guid.NewGuid()}{extention}");
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\img", randomName);
                articleDTO.Picture = randomName;
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }
            articleDTO.UserDTO = CurrentUser;
            articleService.newArticle(articleDTO);
            return RedirectToAction("ArticleList");
        }
        public IActionResult ArticleDelete(int id)
        {
            articleService.deleteArticle(id);
            return RedirectToAction("ArticleList");
        }
        public IActionResult ArticleEdit(int id)
        {
            ArticleViewModel model = new ArticleViewModel();
            model.ArticleDTO = articleService.getArticle(id);
            model.CategoryDTOs = categoryService.getAll();
            return View(model);
        }
        [HttpPost]
        public IActionResult ArticleEdit(ArticleDTO articleDTO,IFormFile file)
        {
            ArticleViewModel model = new ArticleViewModel();
            model.CategoryDTOs = categoryService.getAll();
            return View(model);
        }


        #endregion
    }
}
