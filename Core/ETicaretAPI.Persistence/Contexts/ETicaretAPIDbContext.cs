using ETicaretAPI.Domain.Entities;
using ETicaretAPI.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Contexts
{
    public class ETicaretAPIDbContext:DbContext
    {
        public ETicaretAPIDbContext(DbContextOptions options):base(options) { }

        //Şu şekilde bir mantık kurmaya çalışıyoruz. DbSet bizim veritabanıymış gibi davranan yapımız olacak.products diye bir tablo oluşturuyoruz gibi varsayıyorz. bu yapı da Product türüne benzer bir tablo oluşturacak. yani tablo adları birleştirmesi gibi
        public DbSet<Product> products { get; set; }//Product entitiy sine karşılık products diye bir tablo oluştur. products entitisinde hangi prop lar varsa products tablosunda da o proplar ile aynı sütunlar oluşacak.

        public DbSet<Order> Orders   { get; set; }
        public DbSet<Customer> Customers { get; set; }


        //interceptor işlemleri için, update, delete vb  edilen işlemler savechanges dediğinde bu yapıya takılıyor. burda da yapmak istediğimz işlem olduktan sonra yolunda devam ediyor. SaveChanges işle gerçekleşiyor.
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            //ChangeTracker: Entityler üzerinden yapılan değişiklikler ya da eklenen verinin yakalnamasını sağlayan propertylerdir.Track edilen verileri yakalayıp elde etmemizi sağlar.

            var datas = ChangeTracker.Entries<BaseEntity>();
            foreach (var data in datas)
            {
                _ = data.State switch//datayı tutmamak için _ = yaptık
                {
                    //demek data state(durumu) ekleme (added) veya güncellem (modified) durumları kontrol edilir.yeni değer yani ilgili gelen verinin somut verisine entity üzerinden erişiyoruz. duruma göre de düzenleme işlemini yapıyoruz.
                    EntityState.Added => data.Entity.CreatedDate = DateTime.UtcNow,
                    EntityState.Modified=>data.Entity.UpdateDate = DateTime.UtcNow,
                    _=>DateTime.UtcNow//Yukarıdakilerden herhangi biri değilse bunu döndür diyoruz.
                };
            
            }

            return await base.SaveChangesAsync(cancellationToken); //saveChanges tetiklerken task olduğu için await yazdık.
        }

    }
}
