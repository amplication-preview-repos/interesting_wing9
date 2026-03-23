using NetRes.Infrastructure;

namespace NetRes.APIs;

public class TestEntitiesService : TestEntitiesServiceBase
{
    public TestEntitiesService(NetResDbContext context)
        : base(context) { }
}
