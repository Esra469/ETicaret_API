using ETicaretAPI.Persistence; 

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddPersistenceServices(); //oluþturduðumuz tüm servisler IoC containere eklenmiþ bir halde geldi.

builder.Services.AddCors(options=>options.AddDefaultPolicy(policy=>
 // policy.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod() //gelen istekleri kabul etme üzerne 
    policy.WithOrigins("http://localhost:4200","https://localhost:4200").AllowAnyMethod().AllowAnyHeader()
    ));

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//midleware olarak çaðýrýlacak.
app.UseCors();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
