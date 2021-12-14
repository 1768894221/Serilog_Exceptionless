using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace _01_Logging
{
    public class SystemService
    {
        private ILogger<SystemService> logger;
        public SystemService(ILogger<SystemService> logger)
        {
            this.logger = logger;
        }
        public void Logging()
        {
            logger.LogDebug("开始执行数据库同步");
            logger.LogDebug("开始执行数据库同成功");
            logger.LogDebug("connection succed");
            logger.LogWarning("read data faile, retry first");
            //......
            User person = new User { Id="1",Name="lty"};
            logger.LogWarning("read data faile, retry second");
            logger.LogError("read data faile");
            //要记录的结构化数据通过占位符来输出；
            logger.LogDebug("注册一个用户{@person}", person);
        
        }
    }

    public class User
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
