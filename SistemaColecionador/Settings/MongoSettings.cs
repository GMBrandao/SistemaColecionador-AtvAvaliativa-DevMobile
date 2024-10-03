using SistemaColecionador.Domain.Interfaces;

namespace SistemaColecionador.Api.Settings;

public sealed class MongoSettings : IMongoSettings
{
    public string BookCollectionName { get; set; }

    public string UserCollectionName { get; set; }

    public string ConnectionString { get; set; }

    public string DatabaseName { get; set; }
}