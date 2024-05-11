namespace TeamHost;

public interface IDbSeeder
{
    public Task SeedAsync(CancellationToken cancellationToken);
}