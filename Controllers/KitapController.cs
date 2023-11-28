using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebUygulamaProje1.Models;
using WebUygulamaProje1.Utility;

namespace WebUygulamaProje1.Controllers
{

    public class KitapController : Controller
    {
        // UygulamaDbContext türünde özel bir alan tanımlanır. Bu, veritabanı işlemleri için DbContext sınıfının bir örneğini temsil eder.
        private readonly IKitapRepository _kitapRepository;
        private readonly IKitapTuruRepository _kitapTuruRepository;
        public readonly IWebHostEnvironment _webHostEnvironment;


        // KitapController sınıfının kurucu metodudur.
        // Parametre olarak UygulamaDbContext alır, bu da dependency injection aracılığıyla sağlanır.
        public KitapController(IKitapRepository kitapRepository, IKitapTuruRepository kitapTuruRepository, IWebHostEnvironment webHostEnvironment)
        {
            // UygulamaDbContext örneği, sınıfın özel alanına atanır, böylece bu controller içinde veritabanına erişim sağlanabilir.
            _kitapRepository = kitapRepository;
            _kitapTuruRepository = kitapTuruRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        [Authorize(Roles = "Admin,Ogrenci")]
        public IActionResult Index()
        {
            //List<Kitap> objKitapList = _kitapRepository.GetAll().ToList();
            List<Kitap> objKitapList = _kitapRepository.GetAll(includeProps: "kitapTuru").ToList();
            return View(objKitapList);
        }
        [Authorize(Roles = UserRoles.Role_Admin)]
        public IActionResult EkleGuncelle(int? id)
        {
            IEnumerable<SelectListItem> KitapTuruList = _kitapTuruRepository.GetAll().Select(k => new SelectListItem
            {
                Text = k.Ad,
                Value = k.Id.ToString()
            });
            ViewBag.KitapTuruList = KitapTuruList;  //controllerdan viewa veri aktarır

            if (id == null || id == 0)
            {
                //ekle
                return View();
            }
            else
            {
                //guncelleme
                Kitap? kitapVt = _kitapRepository.Get(u => u.Id == id); //Expression<Func<T, bool>> filtre
                if (kitapVt == null)
                {
                    return NotFound();
                }
                return View(kitapVt);

            }
        }

        [HttpPost]
        [Authorize(Roles = UserRoles.Role_Admin)]
        public IActionResult EkleGuncelle(Kitap kitap, IFormFile? file)
        {
            //var errors=ModelState.Values.SelectMany(x=>x.Errors);

            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                string kitapPath = Path.Combine(wwwRootPath, @"img");

                if (file == null)
                {
                    using (var fileStream = new FileStream(Path.Combine(kitapPath, file.FileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    kitap.ResimUrl = @"\img\" + file.FileName;
                }


                if (kitap.Id == 0)
                {
                    _kitapRepository.Ekle(kitap);
                    TempData["basarili"] = "Yeni Kitap Türü Başarıyla Oluşturuldu ! ";

                }
                else
                {
                    _kitapRepository.Guncelle(kitap);
                    TempData["basarili"] = "Kitap Güncelleme Başarıyla Oluşturuldu ! ";

                }

                _kitapRepository.Kaydet(); //SaveChanges yapmazsanız bilgiler veritabanına eklenmez!!!
                return RedirectToAction("Index", "Kitap"); //Action adı Sonra Controller adı (aynı controllerda ise gerek yok aslında)
            }
            return View();
        }

        /*
        public IActionResult Guncelle(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Kitap? kitapVt = _kitapRepository.Get(u => u.Id == id); //Expression<Func<T, bool>> filtre
            if (kitapVt == null)
            {
                return NotFound();
            }
            return View(kitapVt);
        }
        */
        /*
        [HttpPost]
        public IActionResult Guncelle(Kitap kitap)
        {
            if (ModelState.IsValid)
            {
                _kitapRepository.Guncelle(kitap);
                _kitapRepository.Kaydet(); //SaveChanges yapmazsanız bilgiler veritabanına eklenmez!!!
                TempData["basarili"] = "Yeni Kitap Türü Başarıyla Güncellendi ! ";
                return RedirectToAction("Index", "Kitap"); //Action adı Sonra Controller adı (aynı controllerda ise gerek yok aslında)
            }
            return View();
        }
        */

        //GET ACTION 
        [Authorize(Roles = UserRoles.Role_Admin)]
        public IActionResult Sil(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Kitap? kitapVt = _kitapRepository.Get(u => u.Id == id);
            if (kitapVt == null)
            {
                return NotFound();
            }
            return View(kitapVt);
        }

        [HttpPost, ActionName("Sil")]
        [Authorize(Roles = UserRoles.Role_Admin)]
        public IActionResult SilPOST(int? id)
        {
            Kitap? kitap = _kitapRepository.Get(u => u.Id == id);
            if (kitap == null)
            {
                return NotFound();
            }
            _kitapRepository.Sil(kitap);
            _kitapRepository.Kaydet();
            TempData["basarili"] = "Kayıt Silme İşlemi Başarılı ! ";
            return RedirectToAction("Index", "Kitap"); //Action adı Sonra Controller adı (aynı controllerda ise gerek yok aslında)

        }

    }
}
