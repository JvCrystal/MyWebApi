using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NLog;

namespace MyWebApi.Controllers
{
    /// <summary>
    /// 测试NLog日志框架
    /// </summary>
    public class TestLogController : Controller
    {
        private readonly Logger nlog = LogManager.GetCurrentClassLogger();

        // GET api/values
        [HttpGet("{id}")]
        public string Get(int id)
        {
            nlog.Log(NLog.LogLevel.Debug, $"测试Debug日志");
            nlog.Log(NLog.LogLevel.Info, $"测试Info日志");
            try
            {
                throw new Exception($"故意抛出的异常");
            }
            catch (Exception ex)
            {
                nlog.Log(NLog.LogLevel.Error, ex, $"异常的额外信息");
            }
            return "返回信息";
        }

    }
}