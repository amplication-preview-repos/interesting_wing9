using NetRes.APIs.Common;
using NetRes.APIs.Dtos;

namespace NetRes.APIs;

public interface ITestEntitiesService
{
    /// <summary>
    /// Create one testEntity
    /// </summary>
    public Task<TestEntity> CreateTestEntity(TestEntityCreateInput testentity);

    /// <summary>
    /// Delete one testEntity
    /// </summary>
    public Task DeleteTestEntity(TestEntityWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many testEntities
    /// </summary>
    public Task<List<TestEntity>> TestEntities(TestEntityFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about testEntity records
    /// </summary>
    public Task<MetadataDto> TestEntitiesMeta(TestEntityFindManyArgs findManyArgs);

    /// <summary>
    /// Get one testEntity
    /// </summary>
    public Task<TestEntity> TestEntity(TestEntityWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one testEntity
    /// </summary>
    public Task UpdateTestEntity(
        TestEntityWhereUniqueInput uniqueId,
        TestEntityUpdateInput updateDto
    );
}
