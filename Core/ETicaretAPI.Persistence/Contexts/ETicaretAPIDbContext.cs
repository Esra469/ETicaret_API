using ETicaretAPI.Domain.Entities;
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

    }
}
