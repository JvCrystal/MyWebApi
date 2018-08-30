using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MyWebApi.Entity;
using MyWebApi.Token;
using NLog;

namespace MyWebApi.Controllers
{
    public class StudentController : Controller
    {
        private readonly MyContext _context;
        private readonly Logger nlog = LogManager.GetCurrentClassLogger();

        public StudentController(MyContext context)
        {
            _context = context;
           
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Student")]
        public JsonResult Add(Student entity = null)
        {
            if (entity == null)
                return Json("参数为空");
            _context.Add(entity);
            _context.SaveChanges();
            return Json(true);
        }

        /// <summary>
        /// 获取所有的学生
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Student")]
        public JsonResult Index()
        {
            List<Student> stu = null;


            if (!MemoryCacheHelp.Exists("GetAllStu"))
            {

                nlog.Log(NLog.LogLevel.Info, $"未找到缓存，去数据库查询");

                stu = _context.Students
                    .AsNoTracking()
                    .ToList();


                MemoryCacheHelp.AddMemoryCache("GetAllStu", stu, 30, 1);
            }
            else {
                stu = ((List<Student>)MemoryCacheHelp.Get("GetAllStu"));
            }
            return Json(stu);

        }
    }
}