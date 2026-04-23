using ETicaretAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Domain.Entities
{
    public class Order:BaseEntity
    {
        public int CustomerId { get; set; }//Bunu neden tanımaladığımıza bak
        public string Description  { get; set; }
        public string  Address { get; set; }
        //product ile aralarında bire çok ilişki olduğu için collectionlar ile bunu belirleyeceğiz
        public ICollection<Product> Products { get; set; } //bir orderin birden çok ürünü olabilir demek oluyor.

        public Customer Customer { get; set; }//Customer ile bire çok bir ilişki olduğunu bu şekilde belirtiyoruz.
    }
}
