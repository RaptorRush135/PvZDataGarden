namespace PvZDataGarden.Extensions;

using System.Diagnostics.CodeAnalysis;

internal static class NullableExtensions
{
    public static T? NullIfDefault<T>(this T value)
        where T : struct
        => EqualityComparer<T>.Default.Equals(value, default)
            ? null
            : value;

    public static bool IsNullOrZero(
        [NotNullWhen(false)] this int? value)
        => value is null or 0;
}
