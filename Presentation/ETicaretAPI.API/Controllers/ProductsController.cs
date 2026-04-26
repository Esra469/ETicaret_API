using ETicaretAPI.Application.Abstractions;
using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        readonly private IProductWriteRepository _productWriteRepository;
        readonly private IProductReadRepository _productReadRepository;

        readonly private IOrderWriteRepository _orderWriteRepository;
        readonly private IOrderReadRepository _orderReadRepository;

        readonly private ICustomerWriteRepository _customerWriteRepository;

        public ProductsController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository, ICustomerWriteRepository customerWriteRepository,IOrderWriteRepository orderWriteRepository, IOrderReadRepository orderReadRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
            _customerWriteRepository = customerWriteRepository;
            _orderWriteRepository = orderWriteRepository;
            _orderReadRepository = orderReadRepository;
            
        
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
        public async Task Get()
        {
            //var customerId = Guid.NewGuid();
            //await _customerWriteRepository.AddAsync(new() { Id = customerId, Name = "Muiidddiiin" });
            //await _orderWriteRepository.AddAsync(new() { Description = "bla bla bla 1", Address = "Ankara,çankaya", CustomerId = customerId });
            //await _orderWriteRepository.AddAsync(new() { Description = "bla bla bla 2", Address = "Ankara,pursaklar", CustomerId = customerId });
            //await _orderWriteRepository.SaveAsync();

            Order order = await _orderReadRepository.GetByIdAsync("a8e64f7b-f507-4bee-a1ad-573618c8e3d1");
            order.Address = "İstanbul";
            await _orderWriteRepository.SaveAsync();

        }
    }
}
