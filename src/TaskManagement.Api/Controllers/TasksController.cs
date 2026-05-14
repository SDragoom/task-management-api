using Microsoft.AspNetCore.Mvc;
using TaskManagement.Application.DTOs;
using TaskManagement.Application.Interfaces;
using TaskManagement.Domain.Enums;

namespace TaskManagement.Api.Controllers;
/// <summary>
/// Manage tasks (create, list, update and delete).
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class TasksController : ControllerBase
{
    private readonly ITaskService _service;

    public TasksController(ITaskService service)
    {
        _service = service;
    }

    /// <summary>
    /// Creates a new task.
    /// </summary>
    /// <param name="dto">Task creation payload.</param>
    /// <returns>The created task.</returns>
    /// <response code="201">Task created successfully</response>
    /// <response code="400">Invalid request</response>
    [HttpPost]
    public async Task<IActionResult> Create(CreateTaskDto dto)
    {
        var result = await _service.CreateAsync(dto);

        return CreatedAtAction(
            nameof(GetById),
            new { id = result.Id },
            result);
    }

    /// <summary>
    /// Returns all tasks with optional filters.
    /// </summary>
    /// <param name="status">Filter by status.</param>
    /// <param name="dueDate">Filter by due date.</param>
    /// <response code="200">Returns all tasks</response>
    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] Domain.Enums.TaskStatus? status, [FromQuery] DateTime? dueDate)
    {
        var result = await _service.GetAllAsync(status, dueDate);

        return Ok(result);
    }

    /// <summary>
    /// Returns a task by id.
    /// </summary>
    /// <response code="200">Task found</response>
    /// <response code="404">Task not found</response>
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await _service.GetByIdAsync(id);

        if (result is null)
            return NotFound();

        return Ok(result);
    }

    /// <summary>
    /// Updates an existing task.
    /// </summary>
    /// <response code="204">Updated successfully</response>
    /// <response code="404">Task not found</response>
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, UpdateTaskDto dto)
    {
        var updated = await _service.UpdateAsync(id, dto);

        if (!updated)
            return NotFound();

        return NoContent();
    }

    /// <summary>
    /// Deletes a task.
    /// </summary>
    /// <response code="204">Deleted successfully</response>
    /// <response code="404">Task not found</response>
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var deleted = await _service.DeleteAsync(id);

        if (!deleted)
            return NotFound();

        return NoContent();
    }
}