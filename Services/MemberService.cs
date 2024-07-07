namespace Services;

public class MemberService
{
    private readonly ApplicationDatabaseContext _dbContext;
    public MemberService(ApplicationDatabaseContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Post(Member member)
    {
        await _dbContext.Members.AddAsync(member);
        await _dbContext.SaveChangesAsync();
    }

    public List<Member> Get() => _dbContext.Members.ToList();
}