namespace Services;

public class VisitService{
    private readonly ApplicationDatabaseContext _dbContext;
    public VisitService(ApplicationDatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Post(Visit visit)
    {
        await _dbContext.Visits.AddAsync(visit);
        await _dbContext.SaveChangesAsync();
    }

    public List<Visit> Get()
    {
        return _dbContext.Visits.ToList();
    }
}