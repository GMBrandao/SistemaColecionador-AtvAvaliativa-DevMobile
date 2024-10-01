namespace SistemaColecionador.Domain.Interfaces;

public interface IMongoSettings
{
    string BookCollectionName { get; set; }
    string ConnectionString { get; set; }
    string DatabaseName { get; set; }
}