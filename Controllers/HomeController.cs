using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebUygulamaProje1.Models;

namespace WebUygulamaProje1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        // Constructor metodu, HomeController sınıfının bir örneği oluşturulduğunda çalışan ilk metod.
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // Ana sayfa için bir HTTP GET isteğine yanıt veren metod.
        public IActionResult Index()
        {
            return View(); // Index sayfasını döndürür.
        }

        // Gizlilik sayfası için bir HTTP GET isteğine yanıt veren metod.
        public IActionResult Privacy()
        {
            return View(); // Gizlilik sayfasını döndürür.
        }

        // Uygulamada bir hata olduğunda çalışan metod.
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            // Hata sayfasını döndürür ve bir hata kimliği ekler.
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

















//using Microsoft.AspNetCore.Mvc;
//using System.Diagnostics;
//using WebUygulamaProje1.Models;

//namespace WebUygulamaProje1.Controllers
//{
//    public class HomeController : Controller
//    {
//        private readonly ILogger<HomeController> _logger;

//        public HomeController(ILogger<HomeController> logger)
//        {
//            _logger = logger;
//        }

//        public IActionResult Index()
//        {
//            return View();
//        }

//        public IActionResult Privacy()
//        {
//            return View();
//        }

//        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
//        public IActionResult Error()
//        {
//            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
//        }
//    }
//}
