using ETicaretAPI.Persistence; 

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPersistenceServices(); //oluþturduðumuz tüm servisler IoC containere eklenmiþ bir halde geldi.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
