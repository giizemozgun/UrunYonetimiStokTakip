using Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace DAL
{
    public class DatabaseContext : DbContext
    {
       
        public DatabaseContext()
            : base("name=DatabaseContext")
        {
            Database.SetInitializer(new DatabaseInitializer());  //Entity frameworkde database sýnýfý içerisinde yer alan SetInitializer metoduna kendi yazdýðýmýz DatabaseInitializer sýnýfýný yolluyoruz,böylece bu sýnýf içerisindeki yapýlandýrma ayarlarý iþlenecek 
        }

       
         public virtual DbSet<Kategori> Kategoriler { get; set; }  //veritabaný tablolarýmýzý temsil eden yapýlar

        public virtual DbSet<Kullanici> Kullanicilar{ get; set; }
        public virtual DbSet<Marka> Markalar { get; set; }
        public virtual DbSet<Urun> Urunler { get; set; }

        public virtual DbSet<Musteri> Musteriler { get; set; }

        public virtual DbSet<Siparis> Siparisler { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();  //veritabanýnda oluþacak olan tablolarýn isimlerine s takýsý gelmemesi için
            base.OnModelCreating(modelBuilder);
        }

        //Migration : Veri tabaný güncelleme 
        public class DatabaseInitializer : CreateDatabaseIfNotExists <DatabaseContext> //DropCreateDatabaseIfModelChanges, CreateDatabaseIfNotExists eðer veritabaný yoksa oluþtur, <DatabaseContext> içerisindeki dbsetlere göre
        {
            protected override void Seed(DatabaseContext context)  //seed metodu veritabaný oluþturulduktan sonra devreye girip iþlem yapmamýzý saðlar.
            {
                if (!context.Kullanicilar.Any())
                {
                    context.Kullanicilar.Add(
                        new Kullanici()
                        {
                            Aktif = true,
                            Soyadi = "Admin",
                            Sifre = "123456"
                        }
                        );
                    context.SaveChanges();  //yapýlanlarý kaydediyor.
                }
                base.Seed(context);
            }
        }
    }
    
}


/*
  Migration Ýþlemleri ile veritabanýný silmeden tablolarý güncelleyebilir veya tabloda class larda yaptýðýmýz deðiþiklikleri kullanarak güncelleme yapabiliyoruz.

Migrationu Aktif etmek için yapýlacaklar
1- Öncelikle PMC package manager console kapalý ise onu VS'nun üst menüsünde view>other windows>Pmc yolunu kullanarak aktif ediyoruz.Pmc ile komutlar kullanarak paket yükleme(entity framework vb),migration iþlemler vs yapabilmek için.
2- PMC ekranýnda komut çalýþtýracaðýmýz projeyi (DAL katmaný) default project alanýndan seçtik . Ef'nin bu katmanda yüklü olmasý gerekir.
3- Komut satýrýna enable-migrations komutunu yazýp enter ile çalýþtýrdýk ve Dal katmanýnda Migrations klasörü ve içindeki classlar oluþmasý lazým iþlem baþarýlý iþe, iþlem baþarýsýz olursa Ef sürümünü son sürüme almayý dene, yine çalýþmazsa sürüm düþürerek dene,katmanlardaki EF sürümlerinin ayný sürüm olduðundan emin ol
4- Oluþan migrations'ý veri tabanýna uygulamak için Pmcye update-database yazýp entera basmamýz gerek
5- Daha sonra model class larýmýzda yapacaðýmýz deðiþiklik sonrasý veritabanýný güncellemek için Add-Migration Migrationismi þeklinde Migrationa bir isim vererek enter diyoruz.
6-Eklediðimiz Migration 'ý iþlemek için yine update-database komutunu calýstýrýyoruz.
 */