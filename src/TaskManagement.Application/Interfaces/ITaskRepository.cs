using TaskManagement.Domain.Enums;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Application.Interfaces;

public interface ITaskRepository
{
    Task<TaskItem> AddAsync(TaskItem task);
    Task<IEnumerable<TaskItem>> GetAllAsync(
        Domain.Enums.TaskStatus? status,
        DateTime? dueDate);

    Task<TaskItem?> GetByIdAsync(Guid id);

    Task UpdateAsync(TaskItem task);

    Task DeleteAsync(TaskItem task);
}