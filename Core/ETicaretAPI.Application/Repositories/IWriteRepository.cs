using ETicaretAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Repositories
{
    public  interface IWriteRepository<T>:IRepository<T> where T : BaseEntity
    {
        //bool verme sebebimiz yaptığımız işlem doğru ise true ya da false dönecek bu kadar.
        Task<bool> AddAsync(T model);
        Task<bool> AddRangeAsync(List<T> datas);
        bool Remove(T model);
        bool RemoveRange(List<T> datas);//birden fazla silme işlemi yapmak istersek
        Task<bool> RemoveAsync(string id);
        bool Update(T model);

        Task<int> SaveAsync();
    }
}
