namespace ReactReduxTodo.Entities;

/// <summary>
/// Defines priority levels for todo tasks.
/// Lower numeric values indicate higher priority.
/// </summary>
public enum TaskPriority
{
    /// <summary>
    /// High priority - requires immediate attention
    /// </summary>
    High = 1,

    /// <summary>
    /// Medium priority - default level for most tasks
    /// </summary>
    Medium = 2,

    /// <summary>
    /// Low priority - can be deferred if needed
    /// </summary>
    Low = 3
}
