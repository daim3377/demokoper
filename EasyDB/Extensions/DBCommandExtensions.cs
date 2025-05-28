using System.Data.Common;

namespace EasyDB.Extensions;

public static class DBCommandExtensions
{
    public static DbCommand With(this DbCommand command, DbParameter parameter)
    {
        command.Parameters.Add(parameter);
        return command;
    }

    public static DbCommand With(this DbCommand command, string name, object? value)
    {
        DbParameter parameter = command.CreateParameter();
        if (name.Length > 0 && name[0] != '@')
            name = '@' + name;
        parameter.ParameterName = name;
        parameter.Value = value;
        return command.With(parameter);
    }
}
