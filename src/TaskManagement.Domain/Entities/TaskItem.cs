namespace TaskManagement.Domain.Entities;

public class TaskItem
{
    #region Properties
    public Guid Id { get; private set; }
    public string Title { get; private set; }
    public string? Description { get; private set; }
    public DateTime? DueDate { get; private set; }
    public Domain.Enums.TaskStatus Status { get; private set; }
    public DateTime CreatedAt { get; private set; }
    #endregion
    #region Methods
    public TaskItem(string title, string? description, DateTime? dueDate, Domain.Enums.TaskStatus status)
    {
        Id = Guid.NewGuid();
        Title = title;
        Description = description;
        DueDate = dueDate;
        Status = status;
        CreatedAt = DateTime.UtcNow;
    }

    public void Update(string title, string? description, DateTime? dueDate, Domain.Enums.TaskStatus status)
    {
        Title = title;
        Description = description;
        DueDate = dueDate;
        Status = status;
    }
    #endregion
}