namespace ReactReduxTodo.Entities;

public class TodoTask
{
    public int Id { get; set; }
    public string? Description { get; set; }

    /// <summary>
    /// Priority level of the task. Defaults to Medium if not specified.
    /// </summary>
    public TaskPriority Priority { get; set; } = TaskPriority.Medium;
}