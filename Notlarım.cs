/*NOTLARIM
 * Entity Framework ORM Nedir?
 * .NET tabanlı uygulamalarda veritabanı işlemlerini kolaylaştırır. 
 * EF, nesne-ilişkisel eşleme sağlar, LINQ desteği sunar, veritabanı bağımsızlığına olanak tanır, 
 * "Code First" ve "Database First" yaklaşımlarıyla esnekliği artırır, 
 * hızlı geliştirme imkanı sunar ve bağlantı yönetimi gibi performansı artırmak için özelliklere sahiptir. 
 * 
 * 
 * Models Ekledik ve adını KitapTuru olarak koyduk Sonra içerisini doldurduk lazım olacaklar ile
 * Utility Adlı dosyayı oluşturduk VT ile bağlamak için ve içine kodları yazdık
 * appsettings.json adlı dosyaya ise ConnectionString ekledik Sql bağlantısı için
 * program.cs e ise KOD EKLEDİK ONU AÇIKLAMASI İLE YAZIYORUM ;

    builder.Services.AddDbContext<UygulamaDbContext>(options=>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

Bu satır, uygulamanızın veritabanı bağlantısını yapılandırdığı bir Entity Framework Core (EF Core) ORM özelliği ekler. 
Bu bağlantı, `UygulamaDbContext` adlı bir DbContext sınıfıyla ilişkilidir ve `VarsayılanBağlantı` adlı bağlantı dizesini 
kullanır. Eğer başka bir bağlantı dizesi kullanmak istiyorsanız, "VarsayılanBağlantı" yerine kendi bağlantı adınızı belirtmelisiniz.
 
 * PM yerine update-database yazdık ve kurduk VT nımızı
 * Tablo Oluşturacağız Şimdi ; UygulamaDbContext sınıfını kullancaz (publici oluşturduk DbSet ile **
 * Migration oluşturucaz şimdi PM ile 
 * Migration'lar, uygulamanızın veritabanının evrimini yönetmenize yardımcı olur ve farklı ortamlarda 
 * (geliştirme, test, üretim) veritabanı şemalarını senkronize etmenize olanak tanır.
 * add-migrations KitapTurleriTablosuEkle  kodunu yazdık
 * şimdi PM yerine update-database yazarak yeniden güncelliyoruz VT mizi
 * 
 * Controller oluşturacağız
 * Index oluşturduk sonra layout içine ekledik onu
 * Controller da kodları yazdık 
 * VT de Kitap Türlerini Doldurduk örneğin
 * 
 * Controller kısmına kitap türü eklemek için controller oluşturduk ve içini doldurduk
 * şimdi o kısmın içini doldurduk ve butonlarını aktif hale getireceğiz
 * Ekle.cshtml kısmında label yerinde Modelden Ad alıyor fakat biz onu değiştirmek istediğimizde yani
 * istediğimiz yazı gözüksün diye Model->KitapTuru sonra Adın üstüne Display ekleyip paranteze gözükmesini istediğimiz şeyi yazdık
 * 
 * Controller tarafına HTTPPOST Ekliyoruz Ekle.cshtml da form method içine post yazdığımızdan dolayı
 * HTTPPOST ne işe yaradığı kodun yanında yazıyor olacak..
 * İçerisini doldurduk
 * 
 * Models kısmını düzelttik Özellik Ekledik
 * Controller kısmında if(....) ekledik çünkü modelstekilerin doğruluğunu kontrol etmesi için.
 * Hata Mesajını Ekle.cshtml de kod olarak ekledik yanında açıklama halinde yazıyor.
 * Hata mesajını Türkçe yapmak için models kısmında requiredın içine kendimiz yazdık Türkçe halde...
 * 
 *  Validation işlemi yaptık yani Ekle.cshtml içine alt tarafa section koduyla ekledik validation ismi aynı olmalı sharedta ki ile
 *  Controller kısmına Guncelle ekledik sonra view oluşturduk ve onun içini doldurduk
 *  Güncelleme Butonumuzu ekledik düzenledik
 *  silme butonunu ve içerisini yapıyoruz şimdi.
 *  KitapTuru Controller da SilPOST kısmımızı hallettik çünkü silme işlemi yapıyoruz
 *  Get action gelicek yani onuda kodlarla ayarladık 
 *  Silme İşlemimiz Gerçekleşiyor
 *  Şimdi Sildikten Ekledikten ve Güncelledikten sonra bilgi mesajı vermesesini istiyoruz
 *  Bunun için Controller kısmında TempData ekleyeceğiz kodlarına bakarsın.
 *  TempData kodumuzu Index.cshtml de modelin altına yeniden yazıyoruz ki oraya da yansısın
 *  C# koduna gittiğimiz için başına @ işareti koyuyoruz.
 *  
 *  
 *  
 *  
 *  
 *  
 *  Repository Design Pattern Kullanacağız!!
 *  Nedir: Veri kaynaklarına erişim kodunu soyutlamak için kullanılan bir tasarım desenidir.
 *  
 *  Veri Erişimini Soyutlama:
    Repository, uygulamanın geri kalan kısmına veri kaynaklarına erişim sağlar. İş mantığı, veri kaynaklarına doğrudan erişmek yerine Repository üzerinden erişim sağlar.

    İş Mantığından Bağımsızlık:
    Repository, iş mantığı kodunu veri erişim kodundan izole eder. Bu, iş mantığının değiştirilmesi veya geliştirilmesi durumunda veri erişim kodunu etkilemez.

    CRUD Operasyonları:
    Repository, genellikle CRUD (Create, Read, Update, Delete) operasyonlarını sağlar. Bu operasyonlar, veri kaynakları üzerindeki temel işlemleri temsil eder.

    Veri Modellerinin Dönüşümü:
    Repository, veri tabanı veya diğer veri kaynaklarından alınan verileri iş mantığı için uygun veri modellerine dönüştürme sorumluluğunu üstlenir.

    Test Edilebilirlik:
    Repository tasarım deseni, iş mantığı ve veri erişimi arasındaki sınırları belirler, bu da uygulamanın daha iyi test edilebilir olmasını sağlar.

    Birim Testleri:
    Repository, birim testlerinin daha kolay yazılmasına olanak tanır. Çünkü veri erişimi işlemleri, iş mantığından ayrı bir şekilde test edilebilir.
    
    ASP.NET Core'da, Entity Framework gibi ORM (Object-Relational Mapping) araçları sıklıkla Repository Design Pattern ile birlikte kullanılır. 
    Bu, veritabanı etkileşimlerini soyutlamak ve yönetmek için daha yüksek seviyeli bir arabirim sağlar.
 *  
 *  
 *  
 * Uygulamaya Başlıyoruz
 * Modelsten sınıf oluşturduk Interface
 * İçerisini Hazır Kalıplarla istediğim Komutları vererek yazıyoruz.
 * 
 * Şimdi Yeni bir class oluşturucaz arabirim değil bu sefer implement alıcaz Repository.cs olcak adı bakarsın.
 * Repository kısmının altı kırmızı olcak arabirim uygulayacağız ampulden sonra otomatik yazılacak
 * güncelleyeceğiz kendimize göre
 * throw new NotImplementedException(); kodlarını silip içine kodları kendimiz yazıcaz
 * 
 *         private readonly UygulamaDbContext _uygulamaDbContext;  Controllerda ilk bu kodumuz vardı notlara ben kodu kopyalacağım yeni tasarımlara geçmeden önceki halini göreceğiz.
 *    NOT: KODLARIN REPOSİTORY GEÇMEDEN ÖNCEKİ HALLERİ MEVCUT 
 * 
 * ŞİMDİ;
 * private readonly UygulamaDbContext _uygulamaDbContext;
        internal DbSet<T> dbSet;

        public Repository(UygulamaDbContext uygulamaDbContext)
        {
            _uygulamaDbContext = uygulamaDbContext; 
            this.dbSet=_uygulamaDbContext.Set<T>();
        }

    YAZDIK EKLEDİK DEVAM EDİYORUZ.

    KitapTuru Repository oluşturuyoruz şimdi
    Interface açıyoruz adıda IKıtapTuruRepository
    Models kısmına şimdi sınıf ekliyoruz
    KitapTuruRepository adı
İçerisini dolduruyoruz.
Yeniden :         private  UygulamaDbContext _uygulamaDbContext;
ekliyoruz

CONTROLLER KISMINDA DEĞİŞİM !!!
Değişim yapıyoruz uygulamadbContext siliyoruz artık IKitapTuruRepository kullanıcaz onun yerine.
Her kodu ordaki buna göre düzenliyoruz.
Düzenledik şimdi Progra.cs dosyasına Dependency Injection ekliyoruz nesne oluşturmak için 
builder.Services.AddScoped<IKitapTuruRepository, KitapTuruRepository>(); bu kodu ekledik 

Kitap sınıfı ekledik modele ve içerisini doldurduk ardından EF ile bağlamak tablo açmak için
Utility kısmına geldik ve tablo adımızı ekledik
migration yazıcaz packet console
PM> add-migration KitaplarTablosuEkle
PM> update-database

VT ye gidip içini doldurduk kitapların

KitapRepository ve IKitapRepository ekledik 

KitapController oluşturacağız ve Turu olanları silcez kitap çünkü
views de de aynısını yapıyoruz
sil de validationları sildik ihtiyaç yok

Program Cs de ekledik KitapRepository kısmımızıda çalışması için

Kitap=> Index de KitapTuru sütunu ekledik
Kitap.Cs kısmına ForeignKey ekledik (araştır bu sql konusunu)

Migration kullandık  packet console >> PM> add-migration ForeignKeyEkle
update-database kullan
hata alırsan içerideki verileri sil birdaha dene.

sonra içini doldurduk kitaptüründen bakarak aynılarını 

Kitaplar için Resim Ekleyeceğiz Gerekli düzenlemeler yapılacak ilk
Kitap.cs açıldı
Resim Url eklendi publice sonra add-migraion ResimUrlEkle + update-database yapıldı

kitapcontroller açtık ındexe geldin actionda farklı repodan veri çekmek istiyoruz

        private readonly IKitapTuruRepository _kitapTuruRepository;  kodunu KitapControllera ekledik sonra altı yeşil çizili yere context yanına ekledik publicKitapController yerine parantexe
sonra context yazısını silip onada kitapRepository dedik

Ekle içine IEnumarable ekledik ve kodumuzu yazdık.

Viewbag kodumuzu ekledik

Ekle.cshtml içine 1 tane daha div class ekledik sonra kitapturuıd yazdık ve input kodu yerine;
                <select asp-for="KitapTuruId" asp-items="ViewBag.KitapTuruList" class="form-select"></select>
yazdık ve bitirdik.

ResimUrl ekledik kodlarını yazdık
en üste post un yanına   enctype="multipart/form-data"  ekledik yoksa hata verir

clean code vidoesuna geçtim.
58.video bunu izle not çok olur.
59. DA uzun izlersin kendi projen için

58-59. video da baya bir işlem yaptık.

Şimdi devam ediyoruz

Kitap Güncelle kısmında Yanda Fotoğraf gösterilsin diye kod yazdık 2 div açıp 10-2 böldük 

ekle ve guncelle için controller kısmında if açıp ayrı ayrı mesaj çıksın diye ayarladık

EkleGuncelle kısmında hidde satırı ekledik gözükmeden null değerinde foto girelim diye
Repository kısmını doldurduk Get ve GetAll kısımlarınınn içini ve Interface kısmınada parametre ekledik.
Include metodunu ekledik araştırırsın.
Index.cshtml de kitapturu.ad kodunu ekledik td kısmına

Kiralama.cs ekledik sonra uygulamadbcontext kısmımıza onu tanımladık

migration olarak ekledik sonra update-database vs...

Kiralama ile ilgili olan bütün eklemeleri yaptık views controller models vs

Program.cs kısmınada service ekledik

Projemize enjekte ediyoruz şimdi kiralama kısmını

Projemize Authentıcatıon ve authorızatıon ekleyeceğiz
72.videoyu dinle 
Scaffold ıdnetity araştır.

projemize ıdentity ekledik
projeye sağ tıklayıp ekle kısmından iskelete gelip ordan kimlik diyip sonra tüm hepsini seçip uygulamadbcontexti seçip kurduk

Layout kısmına LoginPartial Ekledik.

builder.Services.AddRazorPages(); program.cs ekledik Razor pageslarımızı aktifleştirdik
Razor sayfalarını kullanabilmek için gerekli olan hizmetleri ekler. 

app.MapRazorPages(); ekledik.

yeniden migration yaptık identity ekleme tablosu

Models Oluşturduk ApplıcatıonUser adında ve içini doldurduk

uygulamadbcontext içine onu ekledik
migration oluşturduk yeniden
updateledik sonra yine

Register kısmında controllera indik ve ordaki createUser kısmının altına return yerine kendi applicationUserımızı ekledik

veritabanında işlemler yaptık onu 79.videosunda görebilirsin.

program.cs kısmına geldik

builder.Services.AddIdentity<IdentityUser,IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<UygulamaDbContext>();
kodumuzu düzenledik ilk halinde AddDefaultIdentity vardı ve Role yoktu içerisindeki onları düzelttik

Layout kısmımızda UserRoles ekleyip hangi rolde hangi kısımlar gelmeli onu ayarladık
controllerda authorization ekledik hepsine baş kısma

EMailSender utility de açtık ve kodumuzu yazdık açıklamada detaylı araştır deniyor.

program.cs açtık şimdi
builder.Services.AddScoped<IEmailSender,EmailSender>();
ekledik.

builder.Services.AddIdentity<IdentityUser,IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<UygulamaDbContext>().AddDefaultTokenProviders();
sondaki token kısmını ekledik hata almamak için

Kullanıcı bilgilerini register razor sayfalarına ekleyeceğiz

userapp kısmındaki kodları alıyoruz required ve içerisini sonra register kısmına geliyoruz ıdentity de
100.satır sonrasına ekliyoruz.

şimdi onun cshtml kısmına geliyoruz ve oraya div içine ekliyoruz ogrencino vb şeyleri aynı şekilde

sonra yine diğer kısma geçiyoruz OnPostAsync kısmının altına user.ogrencino vb kodlarımızı ekliyoruz yine neler varsa yani içerisinde
sql içinde kodlamalar yaptık aktarmalar yani adminuser ve adminroleuser gibi yerlerde


Berke.3641 berke olanın şifresi bu  
diğeri de /Berke!3641/Berke.2002/Berke$2002/Berke.3641 admin şifreleri bunlar olabilir

Öğrencilerin kullanacağı alanları ayarlıyoruz
layout kısmında user roles öğrenci kısmı açıp yazıyoruz kodları
KitapController geldik gerekli yerlere authorize ekledik ve ındex kısmına farklı yazdık !!!!


Öğrencilerin görmemesi gereken yerleri düzenliyoruz kitap>ındex.cshtml kısmında if ekliyoruz userRoles kısımları ile

Index.cshtml düzenliyoruz veeee


PROJE BİTTİ SON DÜZENLEMELERİ YAPIYORUZ HOME/PRİVACY KISIMLARINI FALAN




 */