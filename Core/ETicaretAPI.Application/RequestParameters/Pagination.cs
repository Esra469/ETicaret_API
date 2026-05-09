using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.RequestParameters
{
    public record Pagination //record bak
    {
        public int Page { get; set; } = 0;
        public int Size { get; set; } = 5;//herhangi bir pagination yoksa eğer bu durumda default değer atadık.
    }
}
