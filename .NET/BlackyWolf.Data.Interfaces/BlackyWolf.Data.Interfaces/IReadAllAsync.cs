namespace BlackyWolf.Data.Interfaces;

/// <summary>
///     Represents an implementation that can asynchronously read an
///     enumeration of data from a source.
/// </summary>
/// <typeparam name="TData">
///     The type of data being returned.
/// </typeparam>
public interface IReadAllAsync<TData>
{
    /// <summary>
    ///     Retrieves an enumeration of data from a source.
    /// </summary>
    /// <returns>
    ///     An awaitable task of type <see cref="IEnumerable{TData}" />.
    /// </returns>
    Task<IEnumerable<TData>> ReadAsync();
}
