﻿using Lazy.Captcha.Core;
using Lazy.Captcha.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Lazy.Captcha.Web.Controllers
{
    public class CaptchaController : Controller
    {
        private readonly ILogger<CaptchaController> _logger;
        private readonly ICaptcha _captcha;

        public CaptchaController(ILogger<CaptchaController> logger, ICaptcha captcha)
        {
            _logger = logger;
            _captcha = captcha;
        }

        [HttpGet]
        [Route("/captcha")]
        public IActionResult Captcha(string id)
        {
            var info = _captcha.Generate(id);
            var stream = new MemoryStream(info.Bytes);
            return File(stream, "image/gif");
        }

        [HttpGet]
        [Route("/captcha/validate")]
        public bool Validate(string id, string code)
        {
            if (!_captcha.Validate(id, code))
            {
                throw new Exception("无效验证码");
            }

            // 具体业务

            // 为了演示，这里仅做返回处理
            return true;
        }
    }
}