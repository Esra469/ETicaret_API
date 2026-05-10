using ETicaretAPI.Application.Validators.Products;
using ETicaretAPI.Infrastructure.Filters;
using ETicaretAPI.Persistence;
using FluentValidation.AspNetCore;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddPersistenceServices(); //oluþturduðumuz tüm servisler IoC containere eklenmiþ bir halde geldi.

builder.Services.AddCors(options=>options.AddDefaultPolicy(policy=>
 // policy.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod() //gelen istekleri kabul etme üzerne 
    policy.WithOrigins("http://localhost:4200","https://localhost:4200").AllowAnyMethod().AllowAnyHeader()
    ));

//validasyonlarý buradan bu þekilde çaðýrýyoruz.
builder.Services.AddControllers(options=>options.Filters.Add<ValidationFilter>())
    .AddFluentValidation(configuration=>configuration.RegisterValidatorsFromAssemblyContaining<CreateProductValidator>()
     )
     .ConfigureApiBehaviorOptions(options=>options.SuppressModelStateInvalidFilter=true)
     ;

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseStaticFiles();//wwwroot midleware için kullanýlmasý gerekiyor.
//midleware olarak çaðýrýlacak.
app.UseCors();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
