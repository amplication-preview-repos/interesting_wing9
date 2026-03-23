using NetRes.APIs.Dtos;
using NetRes.Infrastructure.Models;

namespace NetRes.APIs.Extensions;

public static class TestEntitiesExtensions
{
    public static TestEntity ToDto(this TestEntityDbModel model)
    {
        return new TestEntity
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            Name = model.Name,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static TestEntityDbModel ToModel(
        this TestEntityUpdateInput updateDto,
        TestEntityWhereUniqueInput uniqueId
    )
    {
        var testEntity = new TestEntityDbModel { Id = uniqueId.Id, Name = updateDto.Name };

        if (updateDto.CreatedAt != null)
        {
            testEntity.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            testEntity.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return testEntity;
    }
}
