using ETicaretAPI.Application.ViewModels.Products;
using FluentValidation;

namespace ETicaretAPI.Application.Validators.Products
{
    //ürün eklenmesi için doğrulama yapmak 
    public class CreateProductValidator:AbstractValidator<VM_Create_Product>
    {
        public CreateProductValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .NotNull()
                   .WithMessage("Lütfen ürün adını boş geçmeyiniz")
                .MaximumLength(150)
                .MinimumLength(5)
                    .WithMessage("Lütfen ürün adı 5 ve 150 arasında olcak şekile yazınız");

            RuleFor(p => p.Stock)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Lütfen stok bilgisini boş geçmeyin")
                .Must(s => s >= 0)
                    .WithMessage("Stok Bilgisi Negatif Olamaz");

            RuleFor(p => p.Price)
            .NotEmpty()
            .NotNull()
                .WithMessage("Lütfen fiyat bilgisini boş geçmeyin")
            .Must(s => s >= 0)
                .WithMessage("Fiyat Bilgisi Negatif Olamaz");



        }

    }
}
