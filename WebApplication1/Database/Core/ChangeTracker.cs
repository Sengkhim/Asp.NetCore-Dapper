namespace WebApplication1.Database.Core;

public enum ChangeState
{
    Unchanged,
    Added,
    Modified,
    Deleted
}

public class ChangeTracker<T> where T : class
{
    private readonly Dictionary<T, ChangeState> _changes = new ();

    public void Track(T entity, ChangeState state)
    {
        _changes[entity] = state;
    }

    public ChangeState GetState(T entity)
    {
        return _changes.TryGetValue(entity, out var state) ? state : ChangeState.Unchanged;
    }
}