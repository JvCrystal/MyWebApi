using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyWebApi.Controllers
{
    /// <summary>
    /// 测试session
    /// </summary>
    public class SessionController : Controller
    {

        /// <summary>
        /// 测试Session
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Session")]
        public IActionResult Index()
        {
            var username = "subendong";
            var bytes = System.Text.Encoding.UTF8.GetBytes(username);
            HttpContext.Session.Set("username", bytes);

            Byte[] bytesTemp;
            HttpContext.Session.TryGetValue("username", out bytesTemp);
            var usernameTemp = System.Text.Encoding.UTF8.GetString(bytesTemp);

            //扩展方法的使用
            HttpContext.Session.SetString("password", "123456");
            var password = HttpContext.Session.GetString("password");

            var data = new
            {
                usernameTemp,
                password
            };

            return Json(data);
        }  
    }
}