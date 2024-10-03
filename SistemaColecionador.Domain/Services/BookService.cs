using SistemaColecionador.Domain.Dto;
using SistemaColecionador.Domain.Entities;
using SistemaColecionador.Domain.Interfaces.Repositories;
using SistemaColecionador.Domain.Interfaces.Services;
using SistemaColecionador.Domain.Validator;

namespace SistemaColecionador.Domain.Services;

public sealed class BookService : IBookService
{
    private readonly IBookRepository _bookRepository;

    public BookService(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public List<string> CreateBook(BookDto bookDto)
    {
        var response = new List<string>();
        var validator = new BookDtoValidator();
        var result = validator.Validate(bookDto);

        if (!result.IsValid)
        {
            result.Errors.ForEach(error => response.Add(error.ErrorMessage));
            return response;
        }

        var book = new Book
        {
            Id = Guid.NewGuid(),
            Nome = bookDto.Nome,
            Ano = (int)bookDto.Ano!,
            Paginas = (int)bookDto.Paginas!,
            Autor = bookDto.Autor,
            Ilustrador = bookDto.Ilustrador,
            Editora = bookDto.Editora
        };

        _bookRepository.CreateBook(book);

        return response;
    }

    public void DeleteBook(Guid id)
    {
        _bookRepository.DeleteBook(id);
    }

    public List<Book> ListBooks(string? filter)
    {
        if (string.IsNullOrWhiteSpace(filter))
            filter = string.Empty;

        return _bookRepository.ListBooks(filter);
    }
}