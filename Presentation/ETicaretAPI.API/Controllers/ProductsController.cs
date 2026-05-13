using ETicaretAPI.Application.Abstractions;
using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Application.RequestParameters;
using ETicaretAPI.Application.Services;
using ETicaretAPI.Application.ViewModels.Products;
using ETicaretAPI.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        readonly private IProductWriteRepository _productWriteRepository;
        readonly private IProductReadRepository _productReadRepository;
        readonly private IWebHostEnvironment _webHostEnvironment;
        readonly IFileService _fileService;


        public ProductsController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository,IWebHostEnvironment webHostEnvironment,IFileService fileService)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
            _webHostEnvironment = webHostEnvironment;
            _fileService = fileService;



        }

        //[HttpGet]
        //public async Task Get()
        //{
        //    // await _productWriteRepository.AddRangeAsync(new()
        //    //{
        //    //    new() {Id=Guid.NewGuid(),Name="Product 1",Price=100,CreatedDate=DateTime.UtcNow,Stock=10},
        //    //    new() {Id=Guid.NewGuid(),Name="Product 2",Price=200,CreatedDate=DateTime.UtcNow,Stock=20},
        //    //    new() {Id=Guid.NewGuid(),Name="Product 3",Price=300,CreatedDate=DateTime.UtcNow,Stock=130},
        //    //});
        //    // var count =await _productWriteRepository.SaveAsync();
        //    Product p = await _productReadRepository.GetByIdAsync("",false); //false yapınca ne kadar değişiklik olursa olsun değişmez.
        //    p.Name = "Ahmet";//Veritabanındaki bir veriyi değiştirmek için.
        //    await _productWriteRepository.SaveAsync();
        //}
        //[HttpGet("{id}")]
        //public async Task<IActionResult> Get(string id)
        //{
        //    Product product=await _productReadRepository.GetByIdAsync(id);
        //    return Ok(product);
        //}

            [HttpGet]
            public async Task<ActionResult> Get([FromQuery] Pagination pagination)
            {
                //var customerId = Guid.NewGuid();
                //await _customerWriteRepository.AddAsync(new() { Id = customerId, Name = "Muiidddiiin" });
                //await _orderWriteRepository.AddAsync(new() { Description = "bla bla bla 1", Address = "Ankara,çankaya", CustomerId = customerId });
                //await _orderWriteRepository.AddAsync(new() { Description = "bla bla bla 2", Address = "Ankara,pursaklar", CustomerId = customerId });
                //await _orderWriteRepository.SaveAsync();


                //Order order = await _orderReadRepository.GetByIdAsync("a8e64f7b-f507-4bee-a1ad-573618c8e3d1");
                //order.Address = "İstanbul";
                //await _orderWriteRepository.SaveAsync();
                


                var totalCount = _productReadRepository.GetAll(false).Count();
                var products= _productReadRepository.GetAll(false).Skip(pagination.Page * pagination.Size).Take(pagination.Size).Select(p => new
                {
                    //Clinet gidcek veriler bu şekilde olsun istiyoruz.
                    p.Id,
                    p.Name,
                    p.Stock,
                    p.Price,
                    p.CreatedDate,
                    p.UpdateDate
                }).ToList();

                //cliente sadece product değil total count tarzında da türünde de veriler gönderiyor.
                return Ok(new { 
                    totalCount,
                    products
                });

            }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            return Ok(await _productReadRepository.GetByIdAsync(id,false));
        }

        [HttpPost]
        public async Task<IActionResult> Post(VM_Create_Product model)//dışarıdan bir şey gelecek bu entity olarak tanımlanmamalı o zamn viewmodel olarak veriyoruz.
        {

          

            await _productWriteRepository.AddAsync(new()
            {
                Name = model.Name,
                Price = model.Price,
                Stock = model.Stock,
            });
            //normalde handle işlemi ile yapılacak
            await _productWriteRepository.SaveAsync();
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPut]
        public async Task<IActionResult> Put(VM_Update_Product model)
        {
            Product product = await _productReadRepository.GetByIdAsync(model.Id);
            product.Stock = model.Stock;
            product.Price = model.Price;
            product.Name = model.Name;

            await _productWriteRepository.SaveAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _productWriteRepository.RemoveAsync(id);
            await _productWriteRepository.SaveAsync();
            return Ok();
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Upload()
        {
            //Burayı artık kullanmayacağız Fileservice oluşturduk.
            ////wwwroot/resource/product-images
            //string uploadPath = Path.Combine(_webHostEnvironment.WebRootPath,"resource/product-images");

            //if(!Directory.Exists(uploadPath))
            //    Directory.CreateDirectory(uploadPath); 

            //Random r = new();
            //foreach (IFormFile  file in Request.Form.Files) 
            //{
            //    string fullPath = Path.Combine(uploadPath, $"{r.Next()}{Path.GetExtension(file.FileName)}");

            //    using FileStream fileStream = new(fullPath, FileMode.Create, FileAccess.Write, FileShare.None, 1024 * 1024, useAsync: false);
            //    await file.CopyToAsync(fileStream);
            //    await fileStream.FlushAsync();
            //}



            await _fileService.uploadAsync("product-images", Request.Form.Files);
            return Ok();
        }
    }
}
