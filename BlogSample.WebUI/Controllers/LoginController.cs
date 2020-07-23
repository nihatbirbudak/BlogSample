using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BlogSample.BLL.Abstract;
using BlogSample.DTO;
using BlogSample.Model;
using BlogSample.WebUI.Core;
using BlogSample.WebUI.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace BlogSample.WebUI.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserService userService;
        private readonly IRoleService roleService;
        public LoginController(IUserService _userService, IRoleService _roleService)
        {
            userService = _userService;
            roleService = _roleService;
        }
        [HttpGet]
        public ActionResult UserLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UserLogin(LoginViewModel userModel)
        {
            var user = userService.FindwithUsernameandMail(userModel.UserName, userModel.Password);
            if (user != null)
            {
                user.roleDTO = roleService.getRole((int)user.RoleId);
                var userClaims = new List<Claim>()
                {
                       new Claim("UserDTO",BloggerConvert.BloggerJsonSerialize(user))
                };
                var userIdentity = new ClaimsIdentity(userClaims, "User Identity");
                var userPrincipal = new ClaimsPrincipal(new[] { userIdentity });
                HttpContext.SignInAsync(userPrincipal);
                return RedirectToAction("Index","Home");

            }
            return View(user);
        }
        public ActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("UserLogin");
        }
        [HttpGet]
        public ActionResult AccessDenied()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(UserDTO dto)
        {
            userService.newUser(dto);
            return RedirectToAction("UserLogin");
        }
    }
}
