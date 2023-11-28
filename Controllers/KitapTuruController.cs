using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebUygulamaProje1.Models;
using WebUygulamaProje1.Utility;

namespace WebUygulamaProje1.Controllers
{
    [Authorize(Roles = UserRoles.Role_Admin)]
    public class KitapTuruController : Controller
    {
        // UygulamaDbContext türünde özel bir alan tanımlanır. Bu, veritabanı işlemleri için DbContext sınıfının bir örneğini temsil eder.
        private readonly IKitapTuruRepository _kitapTuruRepository;

        // KitapTuruController sınıfının kurucu metodudur.
        // Parametre olarak UygulamaDbContext alır, bu da dependency injection aracılığıyla sağlanır.
        public KitapTuruController(IKitapTuruRepository context)
        {
            // UygulamaDbContext örneği, sınıfın özel alanına atanır, böylece bu controller içinde veritabanına erişim sağlanabilir.
            _kitapTuruRepository = context;
        }

        public IActionResult Index()
        {
            List<KitapTuru> objKitapTuruList = _kitapTuruRepository.GetAll().ToList();
            return View(objKitapTuruList);
        }

        public IActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Ekle(KitapTuru kitapTuru)
        {
            if (ModelState.IsValid)
            {
                _kitapTuruRepository.Ekle(kitapTuru);
                _kitapTuruRepository.Kaydet(); //SaveChanges yapmazsanız bilgiler veritabanına eklenmez!!!
                TempData["basarili"] = "Yeni Kitap Türü Başarıyla Oluşturuldu ! ";
                return RedirectToAction("Index", "KitapTuru"); //Action adı Sonra Controller adı (aynı controllerda ise gerek yok aslında)
            }
            return View();
        }

        public IActionResult Guncelle(int? id)
        {
            if(id==null|| id == 0)
            {
                return NotFound();
            }
            KitapTuru? kitapTuruVt = _kitapTuruRepository.Get(u=>u.Id==id); //Expression<Func<T, bool>> filtre
            if (kitapTuruVt == null)
            {
                return NotFound();
            }
            return View(kitapTuruVt);
        }

        [HttpPost]
        public IActionResult Guncelle(KitapTuru kitapTuru)
        {
            if (ModelState.IsValid)
            {
                _kitapTuruRepository.Guncelle(kitapTuru);
                _kitapTuruRepository.Kaydet(); //SaveChanges yapmazsanız bilgiler veritabanına eklenmez!!!
                TempData["basarili"] = "Yeni Kitap Türü Başarıyla Güncellendi ! ";
                return RedirectToAction("Index", "KitapTuru"); //Action adı Sonra Controller adı (aynı controllerda ise gerek yok aslında)
            }
            return View();
        }

        //GET ACTION 
        public IActionResult Sil(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            KitapTuru? kitapTuruVt = _kitapTuruRepository.Get(u => u.Id == id);
            if (kitapTuruVt == null)
            {
                return NotFound();
            }
            return View(kitapTuruVt);
        }

        [HttpPost, ActionName("Sil")]
        public IActionResult SilPOST(int? id)
        {
            KitapTuru? kitapTuru= _kitapTuruRepository.Get(u => u.Id == id);
            if (kitapTuru == null)
            {
                return NotFound();
            }
            _kitapTuruRepository.Sil(kitapTuru);
            _kitapTuruRepository.Kaydet();
            TempData["basarili"] = "Kayıt Silme İşlemi Başarılı ! ";
            return RedirectToAction("Index", "KitapTuru"); //Action adı Sonra Controller adı (aynı controllerda ise gerek yok aslında)

        }

    }
}
