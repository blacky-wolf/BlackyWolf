namespace BlackyWolf.Data.Interfaces;

/// <summary>
///     Represents an implementation that can asynchronously read data from a
///     source using a primary identifier.
/// </summary>
/// <typeparam name="TKey">
///     The primary identifier used to find the data.
/// </typeparam>
/// <typeparam name="TData">
///     The type of data being returned.
/// </typeparam>
public interface IReadByKeyAsync<in TKey, TData>
{
    /// <summary>
    ///     Retrieves data from a source using the given key.
    /// </summary>
    /// <param name="key">The primary identifier used to find the data.</param>
    /// <returns>
    ///     An awaitable task of type <see cref="TData" />.
    /// </returns>
    Task<TData?> ReadAsync(TKey key);
}
