using ETicaretAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Domain.Entities
{
    public  class Customer:BaseEntity
    {
        public string Name { get; set; }
        //order ile bire çok bir ilişki var.
        public ICollection<Order> Orders { get; set; }//bir müşterinin birden çok siparişi olabilir.ama bir orderin birden fazla customeri olamaz.
    }
}
