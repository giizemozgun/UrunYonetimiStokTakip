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
            Database.SetInitializer(new DatabaseInitializer());  //Entity frameworkde database s�n�f� i�erisinde yer alan SetInitializer metoduna kendi yazd���m�z DatabaseInitializer s�n�f�n� yolluyoruz,b�ylece bu s�n�f i�erisindeki yap�land�rma ayarlar� i�lenecek 
        }

       
         public virtual DbSet<Kategori> Kategoriler { get; set; }  //veritaban� tablolar�m�z� temsil eden yap�lar

        public virtual DbSet<Kullanici> Kullanicilar{ get; set; }
        public virtual DbSet<Marka> Markalar { get; set; }
        public virtual DbSet<Urun> Urunler { get; set; }

        public virtual DbSet<Musteri> Musteriler { get; set; }

        public virtual DbSet<Siparis> Siparisler { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();  //veritaban�nda olu�acak olan tablolar�n isimlerine s tak�s� gelmemesi i�in
            base.OnModelCreating(modelBuilder);
        }

        //Migration : Veri taban� g�ncelleme 
        public class DatabaseInitializer : CreateDatabaseIfNotExists <DatabaseContext> //DropCreateDatabaseIfModelChanges, CreateDatabaseIfNotExists e�er veritaban� yoksa olu�tur, <DatabaseContext> i�erisindeki dbsetlere g�re
        {
            protected override void Seed(DatabaseContext context)  //seed metodu veritaban� olu�turulduktan sonra devreye girip i�lem yapmam�z� sa�lar.
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
                    context.SaveChanges();  //yap�lanlar� kaydediyor.
                }
                base.Seed(context);
            }
        }
    }
    
}


/*
  Migration ��lemleri ile veritaban�n� silmeden tablolar� g�ncelleyebilir veya tabloda class larda yapt���m�z de�i�iklikleri kullanarak g�ncelleme yapabiliyoruz.

Migrationu Aktif etmek i�in yap�lacaklar
1- �ncelikle PMC package manager console kapal� ise onu VS'nun �st men�s�nde view>other windows>Pmc yolunu kullanarak aktif ediyoruz.Pmc ile komutlar kullanarak paket y�kleme(entity framework vb),migration i�lemler vs yapabilmek i�in.
2- PMC ekran�nda komut �al��t�raca��m�z projeyi (DAL katman�) default project alan�ndan se�tik . Ef'nin bu katmanda y�kl� olmas� gerekir.
3- Komut sat�r�na enable-migrations komutunu yaz�p enter ile �al��t�rd�k ve Dal katman�nda Migrations klas�r� ve i�indeki classlar olu�mas� laz�m i�lem ba�ar�l� i�e, i�lem ba�ar�s�z olursa Ef s�r�m�n� son s�r�me almay� dene, yine �al��mazsa s�r�m d���rerek dene,katmanlardaki EF s�r�mlerinin ayn� s�r�m oldu�undan emin ol
4- Olu�an migrations'� veri taban�na uygulamak i�in Pmcye update-database yaz�p entera basmam�z gerek
5- Daha sonra model class lar�m�zda yapaca��m�z de�i�iklik sonras� veritaban�n� g�ncellemek i�in Add-Migration Migrationismi �eklinde Migrationa bir isim vererek enter diyoruz.
6-Ekledi�imiz Migration '� i�lemek i�in yine update-database komutunu cal�st�r�yoruz.
 */