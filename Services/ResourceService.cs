namespace Services;
public class ResourceService
{
    private readonly ApplicationDatabaseContext _dbContext;
    public ResourceService(ApplicationDatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Post(Resource resource)
    {
        await _dbContext.Resources.AddAsync(resource);
        await _dbContext.SaveChangesAsync();
    }

    public List<Resource> Get ()
    {
        return _dbContext.Resources.ToList();
    }
}