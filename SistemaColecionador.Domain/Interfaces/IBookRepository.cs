using SistemaColecionador.Domain.Entities;

namespace SistemaColecionador.Domain.Interfaces;

public interface IBookRepository
{
    void CreateBook(Book book);

    void DeleteBook(Guid id);

    List<Book> ListBooks(string filter);
}