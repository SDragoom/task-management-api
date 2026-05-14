using TaskManagement.Domain.Enums;

namespace TaskManagement.Application.DTOs;

public class UpdateTaskDto
{
    /// <summary>
    /// Title of the task.
    /// </summary>
    /// <example>Criar API</example>
    public string Title { get; set; } = string.Empty;
    /// <summary>
    /// Detailed task description.
    /// </summary>
    /// <example>Criar API para Teste Tecnico</example>
    public string? Description { get; set; }
    /// <summary>
    /// Task due date.
    /// </summary>
    /// <example>2026-05-15</example>
    public DateTime? DueDate { get; set; }
    /// <summary>
    /// Current task status.
    /// </summary>
    /// <example>3</example>
    public Domain.Enums.TaskStatus Status { get; set; }
}