using TaskManagement.Application.DTOs;
using TaskManagement.Application.Interfaces;
using TaskManagement.Domain.Entities;
using TaskManagement.Domain.Enums;

namespace TaskManagement.Application.Services;

public class TaskService : ITaskService
{
    private readonly ITaskRepository _repository;

    public TaskService(ITaskRepository repository)
    {
        _repository = repository;
    }

    public async Task<TaskResponseDto> CreateAsync(CreateTaskDto dto)
    {
        var task = new TaskItem(
            dto.Title,
            dto.Description,
            dto.DueDate,
            dto.Status);

        await _repository.AddAsync(task);

        return MapToResponse(task);
    }

    public async Task<IEnumerable<TaskResponseDto>> GetAllAsync(Domain.Enums.TaskStatus? status, DateTime? dueDate)
    {
        var tasks = await _repository.GetAllAsync(status, dueDate);

        return tasks.Select(MapToResponse);
    }

    public async Task<TaskResponseDto?> GetByIdAsync(Guid id)
    {
        var task = await _repository.GetByIdAsync(id);

        if (task is null)
            return null;

        return MapToResponse(task);
    }

    public async Task<bool> UpdateAsync(Guid id, UpdateTaskDto dto)
    {
        var task = await _repository.GetByIdAsync(id);

        if (task is null)
            return false;

        task.Update(
            dto.Title,
            dto.Description,
            dto.DueDate,
            dto.Status);

        await _repository.UpdateAsync(task);

        return true;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var task = await _repository.GetByIdAsync(id);

        if (task is null)
            return false;

        await _repository.DeleteAsync(task);

        return true;
    }

    private static TaskResponseDto MapToResponse(TaskItem task)
    {
        return new TaskResponseDto
        {
            Id = task.Id,
            Title = task.Title,
            Description = task.Description,
            DueDate = task.DueDate,
            Status = task.Status.ToString()
        };
    }
}