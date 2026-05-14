using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Abstractions.Storage
{
    //en basedeki storage olacak
    public interface IStorage
    {
        //tüm servislerde olmaısnı beklediğimiz fonksiyonumuz.
        Task<List<(string fileName, string pathOrContainerName)>> UploadAsync(string pathOrContainerName, IFormFileCollection files);

        //belirtilen path den veya belirtilen containerden o dosyayı silmek için 
        Task DeleteAsync(string pathOrContainerName, string fileName);
        //o dosyanın tüm iismlerni getirsin diyoruz.
        List<string> GetFiles(string pathOrContainerName);
        bool HasFile(string pathOrContainerName, string fileName);
    }
}
