using MongoDB.Driver;
using SistemaColecionador.Domain.Entities;
using SistemaColecionador.Domain.Interfaces;
using SistemaColecionador.Domain.Interfaces.Repositories;

namespace SistemaColecionador.Infra.Mongo;

public sealed class BookRepository : IBookRepository
{
    private readonly IMongoCollection<Book> _repo;

    public BookRepository(IMongoSettings settings)
    {
        var client = new MongoClient(settings.ConnectionString);
        var database = client.GetDatabase(settings.DatabaseName);
        _repo = database.GetCollection<Book>(settings.BookCollectionName);
    }

    public void CreateBook(Book book) => _repo.InsertOne(book);

    public void DeleteBook(Guid id) => _repo.DeleteOne(book => book.Id == id);

    public List<Book> ListBooks(string filter)
    {
        if (string.IsNullOrWhiteSpace(filter))
            return _repo.Find(book => true).ToList();

        return _repo.Find(book => book.Nome!.ToUpper().Contains(filter.ToUpper())).ToList();
    }
}