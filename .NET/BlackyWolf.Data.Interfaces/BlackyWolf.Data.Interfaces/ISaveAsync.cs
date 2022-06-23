namespace BlackyWolf.Data.Interfaces;

/// <summary>
///     Represents an implementation that can persist data to a source.
/// </summary>
/// <typeparam name="TData">The type of data to persist.</typeparam>
public interface ISaveAsync<in TData>
{
    /// <summary>
    ///     Persists the given data to a source.
    /// </summary>
    /// <param name="data">The data to persist.</param>
    /// <returns>An awaitable void task.</returns>
    Task SaveAsync(TData data);
}

/// <summary>
///     Represents an implementation that can persist data to a source and
///     return a result.
/// </summary>
/// <typeparam name="TData">The type of data to persist.</typeparam>
/// <typeparam name="TResult">
///     The type of result to return once the data has been persisted.
/// </typeparam>
public interface ISaveAsync<in TData, TResult>
{
    /// <summary>
    ///     Persists the given data to a source and returns the result.
    /// </summary>
    /// <param name="data">The data to persist.</param>
    /// <returns>An awaitable task of type <see cref="TResult" />.</returns>
    Task<TResult> SaveAsync(TData data);
}