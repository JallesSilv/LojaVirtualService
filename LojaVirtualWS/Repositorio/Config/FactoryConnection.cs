using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Repositorio.Config
{
    public static class FactoryConnection
    {
        public static MySqlConnection connection => new MySqlConnection(new MySqlConnectionStringBuilder()
        {

            Server = XConfig.Server,
            UserID = XConfig.UserID,
            Password = XConfig.Password,
            Port = 3306,
            Database = XConfig.DataSouce
        }.ConnectionString);

        public static MySqlCommand NewCommand()
        {
            var command = connection.CreateCommand();
            if (command.Connection.State == ConnectionState.Closed)
            {
                command.Connection.Open();
                return command;
            }
            return command;
        }
        public static void Liberar()
        {
            connection.Close();
        }
    }
}