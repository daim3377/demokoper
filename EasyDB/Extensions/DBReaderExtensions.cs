using System.Data.Common;

namespace EasyDB.Extensions;

public static class DBReaderExtensions
{
    [Obsolete("Can be deleted in next version")]
    public static (DateTime start, DateTime end) DateToWeek(DateTime date)
    {
        while (date.DayOfWeek != DayOfWeek.Monday)
            date = date.AddDays(-1);
        return (date, date.AddDays(6));
    }

    [Obsolete("Can be deleted in next version")]
    public static string CreateConditionByDate(DateTime start, DateTime? end)
        => end.HasValue ? $"date BETWEEN '{start:yyyy-MM-dd}' AND '{end:yyyy-MM-dd}'" : $"date='{start:yyyy-MM-dd}'";

    public static IEnumerable<T> GetScalars<T>(this DbDataReader reader)
    {
        while (reader.Read())
            yield return reader.GetFieldValue<T>(0);
    }

    public static Dictionary<TKey, TValue>? GetDictionary<TKey, TValue>(this DbDataReader reader) where TKey : notnull
    {
        if (!reader.HasRows)
            return null;
    
        var result = new Dictionary<TKey, TValue>();
        while (reader.Read())
            result.Add(reader.GetFieldValue<TKey>(0), reader.GetFieldValue<TValue>(1));
    
        return result;
    }
}
