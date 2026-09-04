using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Npgsql;

namespace EfClassicBugRepro.Data;

public class PostgresConfiguration : NpgsqlEFConfiguration
{
    public PostgresConfiguration()
    {
        SetManifestTokenResolver(new Postgres15ManifestTokenResolver());
    }
}

public sealed class Postgres15ManifestTokenResolver : IManifestTokenResolver
{
    public string ResolveManifestToken(DbConnection connection) => "15.0";
}
