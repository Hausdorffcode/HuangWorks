using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HuangWeb.Models;
using Microsoft.AspNetCore.Http;

namespace HuangWeb.Controllers
{
    public class TryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// use ViewDate to pass message from Controller to View
        /// </summary>
        /// <returns></returns>
        public IActionResult UseViewData()
        {
            ViewData["刻意学习"] = "从新手到大师";
            return View();
        }

        /// <summary>
        /// use ViewBag to pass message from Controller to View
        /// </summary>
        /// <returns></returns>
        public IActionResult UseViewBag()
        {
            ViewBag.StudyMethod = "学习之道";
            return View();
        }

        /// <summary>
        /// use ViewModel to pass message from Controller to View
        /// </summary>
        /// <returns></returns>
        public IActionResult UseViewModel()
        {
            TryInfoViewModel tm = new TryInfoViewModel
            {
                IntValue = 10,
                StringValue = "ViewModel",
                Datetime = DateTime.Now
            };
            return View(tm);
        }

        /// <summary>
        /// 利用get方法的模型绑定从View向Controller中传递信息
        /// </summary>
        /// <param name="one"></param>
        /// <param name="two"></param>
        /// <returns></returns>
        public IActionResult Add(int one, int two)
        {
            ViewBag.Result = one + two;
            return View();
        }

        /// <summary>
        /// 利用post方法从View向Controller中传递信息
        /// 注意get，post的编程方式
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAndPost()
        {
            return View();
        }
        [HttpPost]
        public IActionResult GetAndPost(GetAndPostViewModel model)
        {
            return View("GetAndPostResult", model);
        }

        /// <summary>
        /// use TempData to pass message from Action to Action
        /// </summary>
        /// <returns></returns>
        public IActionResult UseTempData()
        {
            return View();
        }
        [HttpPost]
        public IActionResult UseTempData(string message)
        {
            TempData["info"] = message;
            return RedirectToAction("ShowMessage");
        }
        public IActionResult ShowMessage()
        {
            if (TempData["info"] != null)
            {
                return Content(TempData["info"].ToString());
            }
            return Content("No Message!");
        }

        /// <summary>
        /// 在多次http请求中记住状态
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult UseSession()
        {
            ViewBag.Message = "please click the button";
            return View();
        }
        [HttpPost]
        public IActionResult UseSessionPostBack()
        {
            int? clickCnt = HttpContext.Session.GetInt32("ClickCount");
            if (!clickCnt.HasValue)
            {
                HttpContext.Session.SetInt32("ClickCount", 0);
                clickCnt = 0;
            }
            clickCnt++;
            HttpContext.Session.SetInt32("ClickCount", clickCnt.Value);
            ViewBag.Message = $"had clicked {clickCnt} times.";
            return View("UseSession");
        }
    }
}
