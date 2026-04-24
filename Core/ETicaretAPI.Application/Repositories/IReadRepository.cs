using ETicaretAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Repositories
{
    //Generic olarak bu şekilde belirtmem lazım. spesifik bir entity veremem çünkü bu soyut bir yapı. spesifik/ özel ifadeleri kendi concrete lerinde yazacağız.
    public  interface IReadRepository<T>:IRepository<T> where T : BaseEntity 
    {
        IQueryable<T> GetAll(bool tracking = true);//Tüm verileri getir demek.
        IQueryable<T> GetWhere(Expression<Func<T,bool>>method, bool tracking = true);//method yerine Ahmet de yazılabilr sorun değil. BU ifade getwhere yerine yazılan özel fonsiyonlar yazılan ifadenin doğru olanları getiriliyor demek. (bool doğru yanlış olma durumunu tartıyor.)


        //Bu ikisi asenkron çalışacak.
        Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true); //Koşula göre dışarda uygun olan ilkini getirecek.
        Task<T> GetByIdAsync(string id,bool tracking=true);//id ye uygun olan hangisiyse onu getirecek.
    }
}
