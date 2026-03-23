using Microsoft.AspNetCore.Mvc;
using NetRes.APIs.Common;
using NetRes.Infrastructure.Models;

namespace NetRes.APIs.Dtos;

[BindProperties(SupportsGet = true)]
public class TestEntityFindManyArgs : FindManyInput<TestEntity, TestEntityWhereInput> { }
