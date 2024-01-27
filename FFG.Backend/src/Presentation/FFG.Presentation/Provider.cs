
namespace FFG.Presentation
{
    public record Provider(string Name, string Assembly)
    {
        public static Provider Sqlite = new(nameof(Sqlite), typeof(Migrations.Sqlite.Marker).Assembly.GetName().Name!);
        public static Provider PostgreSql = new(nameof(PostgreSql), typeof(Migrations.PostgreSql.Marker).Assembly.GetName().Name!);
    }
}
