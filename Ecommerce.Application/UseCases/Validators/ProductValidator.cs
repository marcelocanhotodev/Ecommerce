using FluentValidation;

namespace Ecommerce.Application.UseCases.Validators
{
    public class ProductValidator : AbstractValidator<Domain.Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.ean)
                .NotEmpty().WithMessage("EAN é obrigatório.")
                .Length(8, 13).WithMessage("EAN deve ter entre 8 e 13 caracteres.")
                .Must(ean => ean.Length != 13 || IsValidEan13(ean))
                .WithMessage("EAN-13 inválido.");

            RuleFor(p => p.brandid)
                .GreaterThan(0).WithMessage("BrandId deve ser maior que zero.");

            RuleFor(p => p.name)
                .NotEmpty().WithMessage("Nome é obrigatório.")
                .MaximumLength(100).WithMessage("Nome deve ter no máximo 100 caracteres.");

            RuleFor(p => p.description)
                .MaximumLength(500).WithMessage("Descrição deve ter no máximo 500 caracteres.")
                .When(p => !string.IsNullOrEmpty(p.description));
        }

        private static bool IsValidEan13(string ean)
        {
            if (ean.Length != 13 || !ean.All(char.IsDigit))
                return false;

            int sum = 0;

            for (int i = 0; i < 12; i++)
            {
                int digit = int.Parse(ean[i].ToString());

                // Posições ímpares (i = 0, 2, 4...) soma normal
                // Posições pares (i = 1, 3, 5...) multiplica por 3
                sum += (i % 2 == 0) ? digit : digit * 3;
            }

            int checkDigit = (10 - (sum % 10)) % 10;

            return checkDigit == int.Parse(ean[12].ToString());
        }
    }
}