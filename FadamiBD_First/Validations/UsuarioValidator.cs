using FadamiBD_First.Models;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FadamiBD_First.Validations
{
    public class UsuarioValidator : AbstractValidator<Usuario>
    {
        public UsuarioValidator()
        {
            RuleFor
                (u => u.Nome)
                .MaximumLength(50).WithMessage("{PropertyName} pode ter no máximo 50 caracteres.")
                .NotEmpty().WithMessage("{PropertyName} é obrigatório");

            RuleFor
                (u => u.Login)
                .MaximumLength(20).WithMessage("{PropertyName} pode ter no máximo 20 caracteres.")
                .NotEmpty().WithMessage("{PropertyName} é obrigatório");

            RuleFor
                (u => u.Cpf)
                .MaximumLength(14).WithMessage("{PropertyName} pode ter no máximo 14 caracteres.")
                .NotEmpty().WithMessage("{PropertyName} é obrigatório");

            RuleFor
                (u => u.Senha)
                .MaximumLength(20).WithMessage("{PropertyName} pode ter no máximo 20 caracteres.")
                .NotEmpty().WithMessage("{PropertyName} é obrigatória");
        }
    }
}