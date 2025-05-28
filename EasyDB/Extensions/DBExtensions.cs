﻿using EasyDB.Abstractions;
using System.Data.Common;

namespace EasyDB.Extensions;

public static class DBExtensions
{
    public static int Write(this IDataBase db, string sql)
    {
        using IDBContext ctx = db.Write();
        return ctx.Execute(sql);
    }

    public static object? Scalar(this IDataBase db, string sql)
    {
        using IDBContext ctx = db.Read();
        return ctx.Scalar(sql);
    }

    public static T ReaderWrapper<T>(this IDataBase db, string sql, Func<DbDataReader, T> action)
    {
        using IDBContext ctx = db.Read();
        return ctx.ReaderWrapper(sql, action);
    }

    public static T ReaderWrapper<T>(this IDataBase db, string sql, Func<DbDataReader, IDBContext, T> action)
    {
        using IDBContext ctx = db.Read();
        return ctx.ReaderWrapper(sql, action);
    }

    public static T ReaderWrapper<T>(this IDBContext context, string sql, Func<DbDataReader, IDBContext, T> action)
        => context.ReaderWrapper(sql, reader => action(reader, context));
}
