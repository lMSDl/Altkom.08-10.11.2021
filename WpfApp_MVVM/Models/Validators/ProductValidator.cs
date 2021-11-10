using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp_MVVM.Models.Validators
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(30).NotEqual("12345678901234567890123456789012345").WithName("Nazwa");
            RuleFor(x => x.Price).LessThanOrEqualTo(100).GreaterThan(0).WithName("Cena");
            RuleFor(x => x.ExpirationDate).GreaterThan(DateTime.Now).WithName("Data przydatności");
        }
    }
}
