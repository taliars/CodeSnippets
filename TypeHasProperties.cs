namespace CodeSnippets;

public static bool TypeHasProperties<T>(string fields) where T : class
{
    if (string.IsNullOrWhiteSpace(fields))
    {
        return true;
    }

    var propertyNames = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance).Select(x => x.Name).ToArray();

    if (propertyNames.Length == 0)
    {
        return false;
    }

    return fields
        .Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
        .All(x => propertyNames.Contains(x, StringComparer.InvariantCultureIgnoreCase));
}