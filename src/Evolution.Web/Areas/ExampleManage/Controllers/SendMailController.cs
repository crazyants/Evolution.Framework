﻿/*******************************************************************************
 * Copyright © 2016 Evolution.Framework 版权所有
 * Author: Evolution
 * Description: Evolution快速开发平台
 * Website：
*********************************************************************************/
using Evolution.Framework;
using Evolution.Web.Attributes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Evolution.Web.Areas.ExampleManage.Controllers
{
    [Area("ExampleManage")]
    public class SendMailController : EvolutionControllerBase
    {
        private readonly ILogger<SendMailController> _logger;

        public SendMailController(ILogger<SendMailController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [HandlerAjaxOnly]
        [ValidateAntiForgeryToken]
        //[ValidateInput(false)]
        public async Task<IActionResult> SendMail(string account, string title, string content)
        {
            MailHelper mail = new MailHelper();
            //mail.MailServer = Configs.GetValue("MailHost");
            //mail.MailUserName = Configs.GetValue("MailUserName");
            //mail.MailPassword = Configs.GetValue("MailPassword");
            mail.MailName = "Evolution快速开发平台";
            mail.Send(account, title, content);
            await Task.FromResult(0);
            return Success("发送成功。");
        }
    }
}
