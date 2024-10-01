using FluentValidation;
using SistemaColecionador.Domain.Dto;
using SistemaColecionador.Domain.Resource;

namespace SistemaColecionador.Domain.Validator;

public sealed class BookDtoValidator : AbstractValidator<BookDto>
{
    public BookDtoValidator()
    {
        RuleFor(book => book.Nome)
            .NotEmpty().WithMessage(Message.RequiredName)
            .MaximumLength(150).WithMessage(Message.NameMaximumCharacters);

        RuleFor(book => book.Ano)
            .NotNull().WithMessage(Message.RequiredYear)
            .InclusiveBetween(1, DateTime.Now.Year).WithMessage(Message.InvalidYear);

        RuleFor(book => book.Autor)
            .NotEmpty().WithMessage(Message.RequiredAuthor)
            .MaximumLength(100).WithMessage(Message.AuthorMaximumCharacters);

        RuleFor(book => book.Editora)
            .NotEmpty().WithMessage(Message.RequiredPublisher)
            .MaximumLength(100).WithMessage(Message.PublisherMaximumCharacters);

        RuleFor(book => book.Ilustrador)
            .MaximumLength(100).WithMessage(Message.IlustratorMaximumCharacters);

        RuleFor(book => book.Paginas)
            .NotNull().WithMessage(Message.PagesRequired)
            .GreaterThan(0).WithMessage(Message.PagesGreaterThanZero);
    }
}