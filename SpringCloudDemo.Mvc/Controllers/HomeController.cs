using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using UOKO.Demo.Api;
using WebApiClient;

namespace SpringCloudDemo.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private  IUserWebApi _userWebApi;

        public HomeController(IUserWebApi userWebApi)
        {
            _userWebApi = userWebApi;
        }
        public  async Task<ActionResult> Index()
        {
            _userWebApi = HttpApiClient.Create<IUserWebApi>();
            var result= await _userWebApi.GetAllAsync();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}