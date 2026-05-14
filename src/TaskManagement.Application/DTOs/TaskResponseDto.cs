namespace TaskManagement.Application.DTOs;

public class TaskResponseDto
{
    /// <summary>
    /// Unique identifier of the task.
    /// </summary>
    /// <example>8f5f4f65-7d9a-4a6e-9a2d-3fbb0c123456</example>
    public Guid Id { get; set; }
    /// <summary>
    /// Task title.
    /// </summary>
    /// <example>Criar API TaskManagement</example>
    public string Title { get; set; } = string.Empty;
    /// <summary>
    /// Detailed task description.
    /// </summary>
    /// <example>Criar API TaskManagement para Teste Tecnico</example>
    public string? Description { get; set; }
    /// <summary>
    /// Task due date.
    /// </summary>
    /// <example>2026-05-15</example>
    public DateTime? DueDate { get; set; }
    /// <summary>
    /// Current task status.
    /// </summary>
    /// <example>InProgress</example>
    public string Status { get; set; } = string.Empty;
}