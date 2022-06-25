namespace BlackyWolf.Data.Interfaces;

/// <summary>
///     Represents an implementation that remove data from a source.
/// </summary>
/// <typeparam name="TData">The type of data to remove.</typeparam>
public interface IRemoveAsync<in TData>
{
    /// <summary>
    ///     Removes the passed data from the source.
    /// </summary>
    /// <param name="data">The data to remove.</param>
    /// <returns>An awaitable void task.</returns>
    Task RemoveAsync(TData data);
}

/// <summary>
///     Represents an implementation that remove data from a source and return
///     a result.
/// </summary>
/// <typeparam name="TData">The type of data to remove.</typeparam>
/// <typeparam name="TResult">
///     The type of result to return once the data has been removed.
/// </typeparam>
public interface IRemoveAsync<in TData, TResult>
{
    /// <summary>
    ///     Removes the passed data from the source and returns the result.
    /// </summary>
    /// <param name="data">The data to remove.</param>
    /// <returns>An awaitable task of type <see cref="TResult" />.</returns>
    Task<TResult> RemoveAsync(TData data);
}