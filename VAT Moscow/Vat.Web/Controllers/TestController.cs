using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VAT;

namespace Vat.Web.Controllers
{
    public class TestController : Controller
    {
        private ITestService _testService;

        public TestController(ITestService testService)
        {
            _testService = testService;
        }
        // GET: Test
        public ActionResult Index()
        {
            var test = _testService.GetTestService("acesta este un test");
            return View(test);
        }
    }
}