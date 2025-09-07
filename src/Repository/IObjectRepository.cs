namespace perla_metro_users_service.Repository;

public interface IObjectRepository<O>
{

    Task<O> StoreAsync(O obj);

    Task<O?> DeleteAsync(string uuid);

    Task<O?> FindByUuid(string uuid);

    Task<O?> Update(string uuid, O obj);

    Task<ICollection<O>> AllAsync();

}