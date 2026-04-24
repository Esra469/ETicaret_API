using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities;
using ETicaretAPI.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Repositories
{
    public class CustomerReadRepository : ReadRepository<Customer>, ICustomerReadRepository //ReadRepository<Customer> bu Readrepository içerisindeki metodların hepsini customere göre ayarla demek ve buraya uygulama demek. sonrasında ICustomerReadRepository bunu da yazmamız bunu customer için doğruladı anlamına geliyor.

    {
        public CustomerReadRepository(ETicaretAPIDbContext context) : base(context)
        {

        }
    }
}
