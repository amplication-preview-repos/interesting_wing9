using Microsoft.AspNetCore.Mvc;

namespace NetRes.APIs;

[ApiController()]
public class TestEntitiesController : TestEntitiesControllerBase
{
    public TestEntitiesController(ITestEntitiesService service)
        : base(service) { }
}
