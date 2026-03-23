using Microsoft.EntityFrameworkCore;
using NetRes.APIs;
using NetRes.APIs.Common;
using NetRes.APIs.Dtos;
using NetRes.APIs.Errors;
using NetRes.APIs.Extensions;
using NetRes.Infrastructure;
using NetRes.Infrastructure.Models;

namespace NetRes.APIs;

public abstract class TestEntitiesServiceBase : ITestEntitiesService
{
    protected readonly NetResDbContext _context;

    public TestEntitiesServiceBase(NetResDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one testEntity
    /// </summary>
    public async Task<TestEntity> CreateTestEntity(TestEntityCreateInput createDto)
    {
        var testEntity = new TestEntityDbModel
        {
            CreatedAt = createDto.CreatedAt,
            Name = createDto.Name,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            testEntity.Id = createDto.Id;
        }

        _context.TestEntities.Add(testEntity);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<TestEntityDbModel>(testEntity.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one testEntity
    /// </summary>
    public async Task DeleteTestEntity(TestEntityWhereUniqueInput uniqueId)
    {
        var testEntity = await _context.TestEntities.FindAsync(uniqueId.Id);
        if (testEntity == null)
        {
            throw new NotFoundException();
        }

        _context.TestEntities.Remove(testEntity);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many testEntities
    /// </summary>
    public async Task<List<TestEntity>> TestEntities(TestEntityFindManyArgs findManyArgs)
    {
        var testEntities = await _context
            .TestEntities.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return testEntities.ConvertAll(testEntity => testEntity.ToDto());
    }

    /// <summary>
    /// Meta data about testEntity records
    /// </summary>
    public async Task<MetadataDto> TestEntitiesMeta(TestEntityFindManyArgs findManyArgs)
    {
        var count = await _context.TestEntities.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one testEntity
    /// </summary>
    public async Task<TestEntity> TestEntity(TestEntityWhereUniqueInput uniqueId)
    {
        var testEntities = await this.TestEntities(
            new TestEntityFindManyArgs { Where = new TestEntityWhereInput { Id = uniqueId.Id } }
        );
        var testEntity = testEntities.FirstOrDefault();
        if (testEntity == null)
        {
            throw new NotFoundException();
        }

        return testEntity;
    }

    /// <summary>
    /// Update one testEntity
    /// </summary>
    public async Task UpdateTestEntity(
        TestEntityWhereUniqueInput uniqueId,
        TestEntityUpdateInput updateDto
    )
    {
        var testEntity = updateDto.ToModel(uniqueId);

        _context.Entry(testEntity).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.TestEntities.Any(e => e.Id == testEntity.Id))
            {
                throw new NotFoundException();
            }
            else
            {
                throw;
            }
        }
    }
}
