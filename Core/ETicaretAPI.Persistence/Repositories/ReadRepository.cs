using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities.Common;
using ETicaretAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        private readonly ETicaretAPIDbContext _context;
        public ReadRepository(ETicaretAPIDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> GetAll()
                => Table;

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method)
                => Table.Where(method);

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method)
                 =>await Table.FirstOrDefaultAsync(method); //asenkron olduğu için await ekledim.

        public async Task<T> GetByIdAsync(string id)
             // =>await Table.FirstOrDefaultAsync(data=>data.Id==Guid.Parse(id));//Generic T olarak belirtiğimzde Id belirtmezdik çünkü burası hala spesifik değil genl bir fonksiyon yazmaya çalışıyoruz. T:class yerine T:BaseEntity yazdık bu da dmek oluyor ki çağrılan en kötü bir baseentitydir. yani illaki onun içinde olan bir prop burada görünecektir.

             => await Table.FindAsync(Guid.Parse(id));
    }
}
