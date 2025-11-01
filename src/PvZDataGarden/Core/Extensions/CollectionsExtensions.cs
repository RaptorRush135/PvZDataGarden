namespace PvZDataGarden.Extensions;

internal static class CollectionsExtensions
{
    public static SortedDictionary<TKey, TElement> ToSorted<TKey, TElement>(
        this IDictionary<TKey, TElement> dictionary)
        where TKey : notnull
    {
        return new(dictionary);
    }
}
