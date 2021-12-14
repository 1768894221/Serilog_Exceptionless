using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace _01_Logging
{
    public class Test
    {
        private ILogger<Test> logger;
        public Test(ILogger<Test> logger)
        {
            this.logger = logger;
        }
        public void Logging()
        {
            logger.LogDebug("开始执行数据库同步");
            logger.LogDebug("connection succed");
            logger.LogWarning("read data faile, retry first");
            //......
            logger.LogWarning("read data faile, retry second");
            logger.LogError("read data faile");
            try
            {
                File.ReadAllText("A:/1.txt");
            }
            catch(Exception ex)
            {
                logger.LogError(ex, "读取文件失败");
            }
        }
    }
}
