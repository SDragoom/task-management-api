using TaskManagement.Application.DTOs;
using TaskManagement.Domain.Enums;

namespace TaskManagement.Application.Interfaces;

public interface ITaskService
{
    Task<TaskResponseDto> CreateAsync(CreateTaskDto dto);

    Task<IEnumerable<TaskResponseDto>> GetAllAsync(
        Domain.Enums.TaskStatus? status,
        DateTime? dueDate);

    Task<TaskResponseDto?> GetByIdAsync(Guid id);

    Task<bool> UpdateAsync(Guid id, UpdateTaskDto dto);

    Task<bool> DeleteAsync(Guid id);
}