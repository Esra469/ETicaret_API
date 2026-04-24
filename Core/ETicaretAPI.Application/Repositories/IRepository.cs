using ETicaretAPI.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Repositories
{
    // IRepository diğer repositorylerin base si olacak.
    public  interface IRepository<T> where T : BaseEntity //class olduğunu belirmemz lazım. yoksa her türde giriş yapmaya elverişli gibi olacak.
    {
        DbSet<T> Table { get; }
    }
}
