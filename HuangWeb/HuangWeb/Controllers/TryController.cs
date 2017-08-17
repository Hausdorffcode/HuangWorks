using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HuangWeb.Models;

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
        /// 利用get方法的模型绑定从View向Controller中传输信息
        /// </summary>
        /// <param name="one"></param>
        /// <param name="two"></param>
        /// <returns></returns>
        public IActionResult Add(int one, int two)
        {
            ViewBag.Result = one + two;
            return View();
        }

        [HttpGet]
        public IActionResult GetAndPost()
        {
            return View();
        }
    }
}
