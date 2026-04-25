using ETicaretAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Domain.Entities
{
    public class Product:BaseEntity
    {
        public string Name { get; set; }
        public int Stock { get; set; }
        public float Price { get; set; }

        //order ile çoka çok ilişki var burada da bağıntı verilmek zorunda
        public ICollection<Order> Orders { get; set; } //bir ürünün birden çok siparişi olur demek oluyor.

    }
}
