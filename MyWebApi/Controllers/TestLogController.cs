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
        private readonly Logger nlog = LogManager.GetCurrentClassLogger(); //获得日志实;

        // GET api/values
        [HttpGet("{id}")]
        public string Get(int id)
        {
            nlog.Log(NLog.LogLevel.Debug, $"yilezhu测试Debug日志");
            nlog.Log(NLog.LogLevel.Info, $"yilezhu测试Info日志");
            try
            {
                throw new Exception($"yilezhu故意抛出的异常");
            }
            catch (Exception ex)
            {

                nlog.Log(NLog.LogLevel.Error, ex, $"yilezhu异常的额外信息");
            }
            return "yilezhu的返回信息";
        }

    }
}