using FluentValidation;
using System.Text.RegularExpressions;

namespace Ecommerce.Application.UseCases.Validators
{
    public class ParticipantValidator : AbstractValidator<Domain.Participant>
    {
        public ParticipantValidator()
        {
            RuleFor(p => p.name)
                .NotEmpty().WithMessage("Nome é obrigatório.")
                .MaximumLength(100).WithMessage("Nome deve ter no máximo 100 caracteres.");

            RuleFor(p => p.document)
                .NotEmpty().WithMessage("Documento é obrigatório.")
                .Must(IsValidCpf).WithMessage("CPF inválido.");

            RuleFor(p => p.email)
                .NotEmpty().WithMessage("E-mail é obrigatório.")
                .EmailAddress().WithMessage("E-mail inválido.");

            RuleFor(p => p.phone)
                .MaximumLength(20).WithMessage("Telefone deve ter no máximo 20 caracteres.")
                .When(p => !string.IsNullOrEmpty(p.phone));
        }

        private static bool IsValidCpf(string cpf)
        {
            if (string.IsNullOrWhiteSpace(cpf))
                return false;

            cpf = Regex.Replace(cpf, "[^0-9]", "");

            if (cpf.Length != 11)
                return false;

            if (new string(cpf[0], cpf.Length) == cpf)
                return false;

            int[] mult1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] mult2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            string tempCpf = cpf.Substring(0, 9);
            int sum = 0;

            for (int i = 0; i < 9; i++)
                sum += int.Parse(tempCpf[i].ToString()) * mult1[i];

            int remainder = sum % 11;
            int firstDigit = remainder < 2 ? 0 : 11 - remainder;

            tempCpf += firstDigit;
            sum = 0;

            for (int i = 0; i < 10; i++)
                sum += int.Parse(tempCpf[i].ToString()) * mult2[i];

            remainder = sum % 11;
            int secondDigit = remainder < 2 ? 0 : 11 - remainder;

            return cpf.EndsWith($"{firstDigit}{secondDigit}");
        }
    }
}
