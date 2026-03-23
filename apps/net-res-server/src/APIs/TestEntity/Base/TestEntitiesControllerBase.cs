using Microsoft.AspNetCore.Mvc;
using NetRes.APIs;
using NetRes.APIs.Common;
using NetRes.APIs.Dtos;
using NetRes.APIs.Errors;

namespace NetRes.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class TestEntitiesControllerBase : ControllerBase
{
    protected readonly ITestEntitiesService _service;

    public TestEntitiesControllerBase(ITestEntitiesService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one testEntity
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<TestEntity>> CreateTestEntity(TestEntityCreateInput input)
    {
        var testEntity = await _service.CreateTestEntity(input);

        return CreatedAtAction(nameof(TestEntity), new { id = testEntity.Id }, testEntity);
    }

    /// <summary>
    /// Delete one testEntity
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteTestEntity(
        [FromRoute()] TestEntityWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeleteTestEntity(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many testEntities
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<TestEntity>>> TestEntities(
        [FromQuery()] TestEntityFindManyArgs filter
    )
    {
        return Ok(await _service.TestEntities(filter));
    }

    /// <summary>
    /// Meta data about testEntity records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> TestEntitiesMeta(
        [FromQuery()] TestEntityFindManyArgs filter
    )
    {
        return Ok(await _service.TestEntitiesMeta(filter));
    }

    /// <summary>
    /// Get one testEntity
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<TestEntity>> TestEntity(
        [FromRoute()] TestEntityWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.TestEntity(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one testEntity
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateTestEntity(
        [FromRoute()] TestEntityWhereUniqueInput uniqueId,
        [FromQuery()] TestEntityUpdateInput testEntityUpdateDto
    )
    {
        try
        {
            await _service.UpdateTestEntity(uniqueId, testEntityUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
