using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogSample.DAL;
using BlogSample.DTO;
using BlogSample.WebUI.Core;
using Microsoft.AspNetCore.Mvc;

namespace BlogSample.WebUI.Controllers
{
    public class BaseController : Controller
    {
        public UserDTO CurrentUser
        {
            get
            {
                var userDTOjson = HttpContext.User.Claims.FirstOrDefault(z => z.Type == "UserDTO").Value;
                return BloggerConvert.BloggerJsonDeSerializeUserDTO(userDTOjson);
            }
        }
    }
}
