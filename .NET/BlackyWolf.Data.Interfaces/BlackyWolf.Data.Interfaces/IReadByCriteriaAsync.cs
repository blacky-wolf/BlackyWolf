namespace BlackyWolf.Data.Interfaces;

/// <summary>
///     Represents an implementation that can asynchronously read an
///     enumeration of data from a source using a set of criteria.
/// </summary>
/// <typeparam name="TCriteria">
///     The criteria used to find the data.
/// </typeparam>
/// <typeparam name="TData">
///     The type of data being returned.
/// </typeparam>
public interface IReadByCriteriaAsync<in TCriteria, TData>
{
    /// <summary>
    ///     Retrieves an enumeration ofdata from a source using the given
    ///     criteria.
    /// </summary>
    /// <param name="criteria">The criteria used to find the data.</param>
    /// <returns>
    ///     An awaitable task of type <see cref="IEnumerable{TData}" />.
    /// </returns>
    Task<IEnumerable<TData>> ReadAsync(TCriteria criteria);
}
