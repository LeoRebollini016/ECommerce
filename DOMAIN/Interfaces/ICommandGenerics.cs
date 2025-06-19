namespace DOMAIN.Interfaces;

public interface ICommandGenerics
{
    public Task AddAsync<T>(T entity, CancellationToken ct) where T : class;
    public Task SaveChangeAsync(CancellationToken ct);
    public void Update<T>(T entity) where T : class;
}
