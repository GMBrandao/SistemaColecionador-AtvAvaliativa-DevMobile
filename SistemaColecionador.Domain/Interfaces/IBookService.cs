using SistemaColecionador.Domain.Dto;
using SistemaColecionador.Domain.Entities;

namespace SistemaColecionador.Domain.Interfaces;

public interface IBookService
{
    List<string> CreateBook(BookDto bookDto);
    
    void DeleteBook(Guid id);

    List<Book> ListBooks(string? filter);
}